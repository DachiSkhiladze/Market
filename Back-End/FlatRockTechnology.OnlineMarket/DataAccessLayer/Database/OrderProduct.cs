﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.Database
{
    public partial class OrderProduct
    {
        public Guid Id { get; set; }
        public long ProductId { get; set; }
        public Guid OrderId { get; set; }
        public long Quantity { get; set; }
        public long PriceOfSingleProduct { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual Order Order { get; set; }
    }
}