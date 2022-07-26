﻿using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.UserServices
{
    public interface IProductServices : IBaseService<Product, ProductModel>
    {
    }
}
