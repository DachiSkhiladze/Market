using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.User;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;
        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var expirations = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expirations,
                signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.NameIdentifier, _user.Id)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public async Task<User> GetUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("JWT").GetSection("Key");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.Value));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<bool> IsDisabled(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return (bool)user.IsDisabled;
        }

        public async Task<bool> ValidateUser(UserLoginModel userLoginModel)
        {
            _user = await _userManager.FindByEmailAsync(userLoginModel.Email);
            if (_user == null)
            {
                return false;
            }
            else if (await IsDisabled(_user.Id))
            {
                return false;
            }
            else
            {
                return (_user != null && await _userManager.CheckPasswordAsync(_user, userLoginModel.Password));
            }
        }
    }
}
