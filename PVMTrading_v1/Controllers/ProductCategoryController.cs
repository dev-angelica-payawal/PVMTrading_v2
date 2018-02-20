using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext _context;

        public ProductCategoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            var productCategory = _context.ProductCategories;
            return View(productCategory.ToList());
        }


     /*   public ActionResult loaddata()
        {
            
                var data = _context.ProductCategories.OrderBy(a => a.Name).ToList();
                return Json(new {data = data}, JsonRequestBehavior.AllowGet);
            
        }*/

        public ActionResult New()
        {
            var productCategories = new ProductCategory();

            return View(productCategories);
        }

        public ActionResult Edit(int id)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(p => p.Id == id);

            if (productCategory == null)
            {
                return HttpNotFound();
            }

            return View("New", productCategory);
        }
        [HttpPost]
        public ActionResult Save(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                var productCateg = new ProductCategory();

                return View("New", productCateg);
            }


            if (productCategory.Id == 0)
            {

                _context.ProductCategories.Add(productCategory);
            }
            else
            {
                var productCategoryInDb = _context.ProductCategories.Single(p => p.Id == productCategory.Id);
                productCategoryInDb.Name = productCategory.Name;
                //  productCategoryInDb.BufferStock = productCategory.BufferStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return Content("Not yet Available");
        }

        public ActionResult Delete(int id)
        {
            var productCategory = _context.ProductCategories.Single(p => p.Id == id);
            if (productCategory.Id != 0)
                _context.ProductCategories.Remove(productCategory);


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}