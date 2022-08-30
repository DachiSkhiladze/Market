﻿using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions
{
    public interface ICartItemServices : IBaseService<CartItem, CartItemModel>
    {
        Task<CartItemModel> InsertAsync(CartItemModel model, int quantity);
        IAsyncEnumerable<CartItemModel> GetModels(Func<CartItem, bool> predicate);
        Task<CartItemModel> DecreaseQuantity(CartItemModel model);
    }
}
