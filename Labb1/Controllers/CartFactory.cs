using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class CartFactory
    {

        public static Cart Create(int cartId)
        {
            _ItemsController itemsController = new _ItemsController();
            CartItemsController cartItemsController = new CartItemsController();
            
            User user = new UserBuilder()
                .SetFirstName("August")
                .SetLastName("Alexandersson")
                .SetAge(21)
                .SetTitle("Dr")
                .SetBillingAddress("Sandlyckevägen 28")
                .SetCountry("Sweden")
                .SetCity("Borås")
                .SetEmail("augustalexandersson@gmail.com")
                .SetId(0)
                .Build();

            List<PickedItem> items = itemsController
                .GetItemsFromCartItems(
                    cartItemsController.GetListOfItems(cartId)
                );

            return new Cart(cartId, items, user);
        }
    }
}