using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
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
using FlatRockTechnology.OnlineMarket.Models.Users;
using FlatRockTechnology.OnlineMarket.Models.Mapper.Abstractions;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Mapper;
using Commands.Handlers.Write.Shared;
using Commands.Declarations.Shared;
using Commands.Declarations.Individual.Products;
using Commands.Handlers.Write.ProductHandlers;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices;
using AuthenticationLayer.Proxy.Abstractions;
using AuthenticationLayer.Proxy;
using Queries.Declarations.Shared;
using Queries.Handlers.Shared;

namespace FlatRockTech.OnlineMarket.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(
                  x => x.UseSqlServer("Data Source=localhost;Initial Catalog=ShopDB;Integrated Security=True")
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                  ServiceLifetime.Transient); // Adding DB Context To The Container
        }

        public static void ConfigureCQRSInjections(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRequestHandler<GetAllQuery<User, UserModel>, IEnumerable<UserModel>>),
                typeof(GetAllHandler<User, UserModel>));

            services.AddTransient(typeof(IRequestHandler<IsExistsQuery<User>, bool>),
                typeof(IsExistsHandler<User, UserModel>));

            services.AddTransient(typeof(IStreamRequestHandler<GetQuery<User, UserModel>, UserModel>),
                typeof(GetHandler<User, UserModel>));

            services.AddTransient(typeof(IRequestHandler<CreateCommand<User, UserModel>, UserModel>),
                typeof(CreateHandler<User, UserModel>));

            services.AddTransient(typeof(IRequestHandler<DeleteCommand<User, UserModel>, bool>),
                typeof(DeleteHandler<User, UserModel>));


            services.AddTransient(typeof(IRequestHandler<UpdateCommand<User, UserModel>, UserModel>),
                typeof(UpdateHandler<User, UserModel>));



            services.AddTransient(typeof(IRequestHandler<CreateCommand<Product, ProductModel>, ProductModel>),
                typeof(CreateHandler<Product, ProductModel>));

            services.AddTransient(typeof(IRequestHandler<CreateProductCommand, ProductModel>),
                typeof(CreateProductHandler));

            services.AddTransient(typeof(IRequestHandler<IsExistsQuery<Product>, bool>),
                typeof(IsExistsHandler<Product, ProductModel>));

            services.AddTransient(typeof(IRequestHandler<GetAllQuery<Product, ProductModel>, IEnumerable<ProductModel>>),
                typeof(GetAllHandler<Product, ProductModel>));

            services.AddTransient(typeof(IStreamRequestHandler<GetQuery<Product, ProductModel>, ProductModel>),
                typeof(GetHandler<Product, ProductModel>));
        }

        public static void ConfigureServicesInjections(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IRepository<User>, Repository<User>>();

            services.AddTransient<IUnitOfWork<User>, UnitOfWork<User>>();

            services.AddTransient<IRepository<Product>, Repository<Product>>();

            services.AddTransient<IUnitOfWork<Product>, UnitOfWork<Product>>();

            services.AddTransient<IMapperConfiguration<Product, ProductModel>, MapperConfiguration<Product, ProductModel>>();

            services.AddTransient<IMapperConfiguration<User, UserModel>, MapperConfiguration<User, UserModel>>();

            services.AddTransient<IMapperConfiguration<UserRegisterModel, UserModel>, MapperConfiguration<UserRegisterModel, UserModel>>();

            services.AddTransient<IUserServices, UserServices>();

            services.AddTransient<IUserServiceProxy, UserServiceProxy>();

            services.AddTransient<IProductServices, ProductServices>();

            services.AddTransient<IServicesFactory, ServicesFlyWeight>(); // Service Factory
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(q =>
            {
                q.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            //builder.AddEntityFrameworkStores<MarketContext>().AddDefaultTokenProviders();
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
