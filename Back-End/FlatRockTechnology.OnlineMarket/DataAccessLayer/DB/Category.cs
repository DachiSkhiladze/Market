﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using FlatRockTechnology.OnlineMarket.DataAccessLayer.Database.Abstractions;
using System;
using System.Collections.Generic;

namespace FlatRockTechnology.OnlineMarket.DataAccessLayer.DB
{
    public partial class Category : IEntity
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}