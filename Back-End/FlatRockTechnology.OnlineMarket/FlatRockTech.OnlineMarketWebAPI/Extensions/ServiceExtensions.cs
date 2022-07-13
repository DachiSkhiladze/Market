using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FlatRockTech.OnlineMarket.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(
                  x => x.UseSqlServer("Data Source=localhost;Initial Catalog=Market;Integrated Security=True")
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                  ServiceLifetime.Transient); // Adding DB Context To The Container
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(q =>
            {
                q.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<MarketContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.GetSection("Key").Value))
                };
            });
        }
    }
}
