using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class LandingPageController : Controller
    {
        ApplicationDbContext de = new ApplicationDbContext();

        public LandingPageController()
        {
            de = new ApplicationDbContext();
        }
        // GET: LandingPage
        [AllowAnonymous]
        public ActionResult Index()
        {
            var prod = de.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
            ViewBag.productCounts = de.Products.Count();
            return View(prod.ToList());
        }
    }
}