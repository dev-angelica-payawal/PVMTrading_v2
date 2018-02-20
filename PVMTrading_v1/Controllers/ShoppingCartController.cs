using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using System.Data.Entity;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext de = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuyNow(int id,double price)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(de.Products.Find(id), 1,price));
                Session["cart"] = cart;
            }
            else
            {

            }
            return View("Cart");
        }
    }
}