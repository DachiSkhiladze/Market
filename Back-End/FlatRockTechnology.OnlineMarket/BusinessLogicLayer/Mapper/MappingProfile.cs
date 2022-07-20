using AutoMapper;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Category;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Order;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.Product;
using FlatRockTech.OnlineMarket.BusinessLogicLayer.Models.User;
using FlatRockTechnology.OnlineMarket.BusinessLogicLayer.Models.Address;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;

namespace FlatRockTech.OnlineMarket.BusinessLogicLayer.Mapper
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
            }
        }
}
