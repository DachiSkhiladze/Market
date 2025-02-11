﻿using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database;
using FlatRockTechnology.OnlineMarket.DataAccessLayer.DB;
using FlatRockTechnology.OnlineMarket.Models.Products;
using FlatRockTechnology.OnlineMarket.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace OnlineMarket.BusinessLogicAccessLayer.Services.Individual.Abstractions.CartServices
{
    public interface ICartItemServices : IBaseService<CartItem, CartItemModel>
    {
        Task<CartItemModel> InsertAsync(CartItemModel model, int quantity);
        IAsyncEnumerable<CartItemModel> GetModels(Func<CartItem, bool> predicate);
        Task DeleteFromCart(CartItemModel model);
        Task<double> GetPrice(Guid userId);
    }
}
