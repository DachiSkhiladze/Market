using AutoMapper;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.Address;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.Category;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.Order;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Models.Product;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressModel, Address>();
            CreateMap<Address, AddressModel>();
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
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
        }
    }
}
