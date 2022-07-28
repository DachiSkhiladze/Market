﻿

namespace FlatRockTechnology.OnlineMarket.Models.Products
{
    public class ProductModel
    {
        internal Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Guid> Categories { get; set; }
    }
}