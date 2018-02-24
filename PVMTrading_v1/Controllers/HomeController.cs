using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Migrations;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [CustomAuthorize(Roles = "Admin,Cashier,Sales Clerk")]

        public ActionResult Index()
        {
            var customer = _context.Customers.Include(s => s.Sex).ToList();
           var prod = _context.Products.Count();
            var cus = _context.Customers.Count();
            ViewBag.Customer = cus;
            ViewBag.Product = prod;

            return View(customer);
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
    }
}