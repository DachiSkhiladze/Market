﻿using AutoMapper;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.Models.Users;
using MediatR;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserServices : BaseService<User, UserModel>, IUserServices
    {
        public UserServices(IMediator mediator) : base(mediator)
        {
        }
        /*
        public async Task<UserModel> DisableOrEnableUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsDisabled = !user.IsDisabled;
            await _userManager.UpdateAsync(user);
            return ConvertToModel(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.IsDisabled = !user.IsDisabled;
            await _userManager.DeleteAsync(user);
        }

        public async Task<bool> UpdateEmailAsync(string id, string newEmail)
        {
            var test = await _userManager.FindByEmailAsync(newEmail);
            if (test != null)
            {
                return false;
            }
            var user = await _userManager.FindByIdAsync(id);
            user.Email = newEmail;
            await _userManager.UpdateAsync(user);
            return true;
        }
        public async Task<IdentityResult> Register(UserModel model)
        {
            var user = ConvertToDTO(model);
            user.UserName = model.Email;
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.Roles);
            }
            return result;
        }*/

    }
}
