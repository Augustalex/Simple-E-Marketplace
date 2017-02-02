using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb1.Models
{
    public class ShopItem
    {

        public ShopItem(string name)
        {
            this.name = name;
            this.image = "../Content/java.jpg";
            this.description = "a fucking asshole.";
        }

        public string description { get; set; }
        public string name { get; set; }
        public string image { get; set; }

        public ShopItem(string name, string description) : this(name)
        {
            this.description = description;
        }
    }
}