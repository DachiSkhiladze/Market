using AutoMapper;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Addresses;
using FlatRockTechnology.OnlineMarket.Models.Categories;
using FlatRockTechnology.OnlineMarket.Models.Orders;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;

namespace FlatRockTechnology.OnlineMarket.Models.Mapper
{
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<AddressModel, Address>().ReverseMap();
                CreateMap<CartItemModel, CartItem>().ReverseMap();
                CreateMap<CategoryModel, Category>().ReverseMap();
                CreateMap<OrderModel, Order>().ReverseMap();
                CreateMap<OrderProductModel, Order>().ReverseMap();
                CreateMap<ProductModel, Product>().ReverseMap();
                CreateMap<ProductCategoryModel, ProductCategory>().ReverseMap();
                CreateMap<SubCategoryModel, SubCategory>().ReverseMap();
                CreateMap<CategoryModel, Category>().ReverseMap();
                CreateMap<UserModel, User>().ReverseMap();
                CreateMap<UserLoginModel, UserModel>().ReverseMap();
                CreateMap<UserRegisterModel, UserModel>().ReverseMap();
                CreateMap<Role, RoleModel>().ReverseMap();
                CreateMap<UserRole, UserRoleModel>().ReverseMap();
        }
        }
}
