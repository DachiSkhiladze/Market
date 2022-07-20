using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Repository.Base.Implementations;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.UnitOfWork.Implementations;
using static FlatRockTech.OnlineMarket.BusinessLogicLayer.Mapper.Abstractions.Read;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.User;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Mapper;

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

        public static void ConfigureServicesInjections(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IRequestHandler<FlatRockTech.OnlineMarket.BusinessLogicLayer.Queries.Read.GetAll<User, UserModel>, IEnumerable<UserModel>>),
                typeof(BusinessLogicLayer.Handlers.Read.GetAllHandler<User, UserModel>));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IRepository<User>, Repository<User>>();

            services.AddTransient<IUnitOfWork<User>, UnitOfWork<User>>();

            services.AddTransient<IMapperConfiguration<User, UserModel>, BusinessLogicLayer.Mapper.Read.MapperConfiguration<User, UserModel>>();


            services.AddTransient<IUserServices, UserServices>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<UserManager<User>>();
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
