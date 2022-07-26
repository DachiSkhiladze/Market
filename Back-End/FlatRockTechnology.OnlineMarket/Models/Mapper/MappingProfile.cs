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
                CreateMap<CategoryModel, Category>().ReverseMap();
                CreateMap<OrderModel, Order>();
                CreateMap<Order, OrderModel>();
                CreateMap<OrderProductModel, Order>();
                CreateMap<Order, OrderProductModel>();
                CreateMap<ProductModel, Product>();
                CreateMap<Product, ProductModel>();
                CreateMap<ProductCategoryModel, ProductCategory>();
                CreateMap<ProductCategory, ProductCategoryModel>();
                CreateMap<SubCategoryModel, SubCategory>();
                CreateMap<SubCategory, SubCategoryModel>();
                CreateMap<CategoryModel, Category>();
                CreateMap<Category, CategoryModel>();
                CreateMap<UserModel, User>();
                CreateMap<User, UserModel>();
                CreateMap<UserLoginModel, UserModel>();
                CreateMap<UserModel, UserLoginModel>();
                CreateMap<UserRegisterModel, UserModel>();
                CreateMap<UserModel, UserRegisterModel>();
        }
        }
}
