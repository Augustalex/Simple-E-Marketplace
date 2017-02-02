using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class PickedItem
    {
        public readonly Item Item;
        public readonly int Quantity;

        public PickedItem(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }
}