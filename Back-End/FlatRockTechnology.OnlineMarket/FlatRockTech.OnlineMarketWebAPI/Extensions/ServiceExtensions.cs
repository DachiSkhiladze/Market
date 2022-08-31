using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.UserServices;
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
using EmailLayer.Abstractions;
using EmailLayer;
using Queries.Declarations.Individual;
using Queries.Handlers.Individual;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CartServices;
using AuthenticationLayer.Token.Redis;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.ProductServices;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CategoryServices;
using OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Implementations.CategoryServices;
using FlatRockTechnology.OnlineMarket.Models.Addresses;
using FlatRockTechnology.OnlineMarket.Models.Orders;

namespace FlatRockTech.OnlineMarket.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(
                  x => x.UseSqlServer("Server=tcp:shopfrt.database.windows.net,1433;Initial Catalog=Shop;Persist Security Info=False;MultipleActiveResultSets=true;User ID=Dachi;Password=Bubunita34;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                  ServiceLifetime.Transient); // Adding DB Context To The Container
        }

        private static Dictionary<Type, Type> cqrsModels;

        private static void InitializeCQRSModels(this IServiceCollection services)
        {
            cqrsModels = new Dictionary<Type, Type>()
            {
                { typeof(Address), typeof(AddressModel) },
                { typeof(CartItem), typeof(CartItemModel) },
                { typeof(Order), typeof(OrderModel) },
                { typeof(OrderProduct), typeof(OrderProductModel) },
                { typeof(Product), typeof(ProductModel) },
                { typeof(ProductCategory), typeof(ProductCategoryModel) },
                { typeof(ProductPictures), typeof(ProductPicturesModel) },
                { typeof(Role), typeof(RoleModel) },
                { typeof(Category), typeof(CategoryModel) },
                { typeof(SubCategory), typeof(SubCategoryModel) },
                { typeof(User), typeof(UserModel) },
                { typeof(UserRole), typeof(UserRoleModel) },
            };
            IEnumerable<MethodInfo?> cqrsMethods = new List<MethodInfo?>() {
                typeof(ServiceExtensions)?.GetMethod(nameof(ServiceExtensions.CQRSSharedCreateGeneric))
            };
            foreach (var modelsTypes in cqrsModels)
            {
                foreach (var method in cqrsMethods)
                {
                    var genericMethod = method.MakeGenericMethod(new Type[] { modelsTypes.Key, modelsTypes.Value });
                    services = (IServiceCollection?)genericMethod?.Invoke(null, new object[] { (services) });
                }
            }
        }

        public static void InjectionFacade(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.ConfigureServicesInjections();

            services.ConfigureCQRSInjections();

            services.ConfigureUnitOfWorkInjections();

            services.ConfigureRepositoryInjections();

            services.ConfigureIMapper();

            services.ConfigureJWT(configuration);

            services.AddSignalR();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IRedisDB, RedisDB>();
        }

        public static IServiceCollection CQRSSharedCreateGeneric<TEntity, TModel>(IServiceCollection services) where TEntity : class, new() where TModel : class, new()
        {
            services.AddTransient(typeof(IRequestHandler<CreateCommand<TEntity, TModel>, TModel>),
                typeof(CreateHandler<TEntity, TModel>));

            services.AddTransient(typeof(IStreamRequestHandler<GetQuery<TEntity, TModel>, TModel>),
                typeof(GetHandler<TEntity, TModel>));

            services.AddTransient(typeof(IRequestHandler<GetSingleQuery<TEntity, TModel>, TModel>),
                typeof(GetSingleHandler<TEntity, TModel>));

            services.AddTransient(typeof(IRequestHandler<GetAllQuery<TEntity, TModel>, IEnumerable<TModel>>),
                typeof(GetAllHandler<TEntity, TModel>));

            services.AddTransient(typeof(IRequestHandler<DeleteCommand<TEntity, TModel>, bool>),
                typeof(DeleteHandler<TEntity, TModel>));

            services.AddTransient(typeof(IRequestHandler<IsExistsQuery<TEntity>, bool>),
                typeof(IsExistsHandler<TEntity, TModel>));

            services.AddTransient(typeof(IRequestHandler<UpdateCommand<TEntity, TModel>, TModel>),
                typeof(UpdateHandler<TEntity, TModel>));

            return services;
        }
        public static void CQRSCustomInjections(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRequestHandler<GetRoleQuery, IEnumerable<RoleModel>>),
                typeof(GetRoleHandler));

            services.AddTransient(typeof(IRequestHandler<GetProductPicturesByProductIDQuery, IEnumerable<ProductPicturesModel>>),
                typeof(GetProductPicturesByProductIDHandler));

            services.AddTransient(typeof(IRequestHandler<GetProductsBySubCategoryIDQuery, IEnumerable<ProductModel>>),
                typeof(GetProductsBySubCategoryIDHandler));

            services.AddTransient(typeof(IRequestHandler<CreateProductCommand, ProductModel>),
                typeof(CreateProductHandler));
        }

        public static void ConfigureCQRSInjections(this IServiceCollection services)
        {
            services.InitializeCQRSModels();
            services.CQRSCustomInjections();
        }

        public static void ConfigureUnitOfWorkInjections(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork<Order>, UnitOfWork<Order>>();
            services.AddTransient<IUnitOfWork<OrderProduct>, UnitOfWork<OrderProduct>>();
            services.AddTransient<IUnitOfWork<Address>, UnitOfWork<Address>>();
            services.AddTransient<IUnitOfWork<ProductPictures>, UnitOfWork<ProductPictures>>();
            services.AddTransient<IUnitOfWork<User>, UnitOfWork<User>>();
            services.AddTransient<IUnitOfWork<CartItem>, UnitOfWork<CartItem>>();
            services.AddTransient<IUnitOfWork<UserRole>, UnitOfWork<UserRole>>();
            services.AddTransient<IUnitOfWork<Product>, UnitOfWork<Product>>();
            services.AddTransient<IUnitOfWork<ProductCategory>, UnitOfWork<ProductCategory>>();
            services.AddTransient<IUnitOfWork<Role>, UnitOfWork<Role>>();
            services.AddTransient<IUnitOfWork<Category>, UnitOfWork<Category>>();
            services.AddTransient<IUnitOfWork<SubCategory>, UnitOfWork<SubCategory>>();
        }

        public static void ConfigureRepositoryInjections(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, Repository<Order>>();
            services.AddTransient<IRepository<OrderProduct>, Repository<OrderProduct>>();
            services.AddTransient<IRepository<Address>, Repository<Address>>();
            services.AddTransient<IRepository<ProductPictures>, Repository<ProductPictures>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
            services.AddTransient<IRepository<UserRole>, Repository<UserRole>>();
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<ProductCategory>, Repository<ProductCategory>>();
            services.AddTransient<IRepository<Role>, Repository<Role>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<SubCategory>, Repository<SubCategory>>();
        }

        public static void ConfigureIMapper(this IServiceCollection services)
        {
            services.AddTransient<IMapperConfiguration<OrderProduct, OrderProductModel>, MapperConfiguration<OrderProduct, OrderProductModel>>();
            services.AddTransient<IMapperConfiguration<Address, AddressModel>, MapperConfiguration<Address, AddressModel>>();
            services.AddTransient<IMapperConfiguration<ProductPictures, ProductPicturesModel>, MapperConfiguration<ProductPictures, ProductPicturesModel>>();
            services.AddTransient<IMapperConfiguration<User, UserModel>, MapperConfiguration<User, UserModel>>();
            services.AddTransient<IMapperConfiguration<CartItem, CartItemModel>, MapperConfiguration<CartItem, CartItemModel>>();
            services.AddTransient<IMapperConfiguration<UserRole, UserRoleModel>, MapperConfiguration<UserRole, UserRoleModel>>();
            services.AddTransient<IMapperConfiguration<Product, ProductModel>, MapperConfiguration<Product, ProductModel>>();
            services.AddTransient<IMapperConfiguration<ProductCategory, ProductCategoryModel>, MapperConfiguration<ProductCategory, ProductCategoryModel>>();
            services.AddTransient<IMapperConfiguration<Role, RoleModel>, MapperConfiguration<Role, RoleModel>>();
            services.AddTransient<IMapperConfiguration<Category, CategoryModel>, MapperConfiguration<Category, CategoryModel>>();
            services.AddTransient<IMapperConfiguration<SubCategory, SubCategoryModel>, MapperConfiguration<SubCategory, SubCategoryModel>>();
            services.AddTransient<IMapperConfiguration<CartItem, CartItemModel>, MapperConfiguration<CartItem, CartItemModel>>();
            services.AddTransient<IMapperConfiguration<ProductPictures, ProductPicturesModel>, MapperConfiguration<ProductPictures, ProductPicturesModel>>();
            services.AddTransient<IMapperConfiguration<Product, ProductModel>, MapperConfiguration<Product, ProductModel>>();
            services.AddTransient<IMapperConfiguration<Category, CategoryModel>, MapperConfiguration<Category, CategoryModel>>();
            services.AddTransient<IMapperConfiguration<Order, OrderModel>, MapperConfiguration<Order, OrderModel>>();
            services.AddTransient<IMapperConfiguration<SubCategory, SubCategoryModel>, MapperConfiguration<SubCategory, SubCategoryModel>>();
            services.AddTransient<IMapperConfiguration<User, UserModel>, MapperConfiguration<User, UserModel>>();
            services.AddTransient<IMapperConfiguration<UserRegisterModel, UserModel>, MapperConfiguration<UserRegisterModel, UserModel>>();
            services.AddTransient<IMapperConfiguration<Role, RoleModel>, MapperConfiguration<Role, RoleModel>>();
            services.AddTransient<IMapperConfiguration<UserRole, UserRoleModel>, MapperConfiguration<UserRole, UserRoleModel>>();
            services.AddTransient<IMapperConfiguration<UserRegisterModel, UserModel>, MapperConfiguration<UserRegisterModel, UserModel>>();
        }

        public static void ConfigureServicesInjections(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();

            services.AddTransient<ICartItemServices, CartItemServices>();

            services.AddTransient<IUserRoleServices, UserRoleServices>();

            services.AddTransient<ISubCategoryServices, SubCategoryService>();

            services.AddTransient<ICategoryServices, CategoryService>();

            services.AddTransient<IUserRoleServices, UserRoleServices>();

            services.AddTransient<IUserServiceProxy, UserServiceProxy>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IProductServices, ProductServices>();

            services.AddTransient<IProductPicturesServices, ProductPicturesService>();

            services.AddScoped<IServicesFlyweight, ServicesFlyWeight>(); // Service Factory
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/hubs/chat")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddMvc();
        }
    }
}
