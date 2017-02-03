using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Labb1.Models;

namespace Labb1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Shop()
        {
            ViewBag.Message = "Your shopping page.";
            _ItemsController itemsController = new _ItemsController();
            List<Item> items = itemsController.FetchAllItems();
            return View(items);
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your cart page.";
            
            CartItemsController controller = new CartItemsController();
            //63839
            return View(CartFactory.Create(0));
        }
    }
}