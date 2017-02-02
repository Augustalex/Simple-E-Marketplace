using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class Cart
    {
        public readonly List<PickedItem> items;
        public readonly int cartId;
        public readonly User owner;

        public Cart(int cartId, List<PickedItem> items, User owner)
        {
            this.owner = owner;
            this.cartId = cartId;
            this.items = items;
        }
    }
}