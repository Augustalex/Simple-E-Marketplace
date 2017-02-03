using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class _ItemsController
    {
        private ItemContext _itemContext = new ItemContext();

        public List<PickedItem> GetItemsFromCartItems(List<CartItem> cartItems)
        {
            if (!cartItems.Any())
                throw new Exception("No items in cart");

            List<PickedItem> pickedItems = new List<PickedItem>();
            foreach (var item in cartItems)
            {
                pickedItems.Add(
                    new PickedItem(
                        _itemContext.Items.Find(item.ItemId),
                        item.Quantity
                    )
                );
            }

            return pickedItems;
        }

        public List<Item> FetchAllItems()
        {
            return _itemContext.Items.ToList();
        }
    }
}