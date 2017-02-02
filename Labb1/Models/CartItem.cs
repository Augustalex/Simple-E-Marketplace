using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class CartItem
    {
        [Key, Column(Order = 0)]
        public int CartId { get; set; }

        [Key, Column(Order = 1)]
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class CartItemDbContext : DbContext
    {
        public CartItemDbContext() : base("CartItemDbContext")
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
    }
}