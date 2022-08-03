using AutoMapper;
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
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using EmailLayer.Abstractions;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices
{
    public class UserServices : BaseService<User, UserModel>, IUserServices
    {
        private readonly IEmailSender emailSender;
        public UserServices(IMediator mediator, IEmailSender emailSender) : base(mediator)
        {
            this.emailSender = emailSender;
        }

        public async Task<bool> ConfirmEmail(string? code)
        {
            var models = GetModels().ToListAsync().Result;
            var model = models.FirstOrDefault(o => o.EmailVerificationCode.Equals(code));
            if (model != null)
            {
                model.IsEmailConfirmed = true;
                await UpdateAsync(model);
                return true;
            }
            return false;
        }

        public async Task<bool> RecoverPassword(string email, string origin)
        {
            if (await IsExists(o => o.Email.Equals(email)))
            {
                var models = GetModels().ToListAsync().Result;
                var model = models.FirstOrDefault(o => o.Email.Equals(email));
                if (model != null)
                {
                    emailSender.SendRecovery(email, model.FirstName, model.LastName, origin);
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
