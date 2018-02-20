using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class ProductPriceController : Controller
    {
        private ApplicationDbContext _context;

        public ProductPriceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ProductPrice
        public ViewResult Index()
        {
            
            var productPrices = _context.ProductPrices.Include(p => p.Product).ToList();

            return View(productPrices);
        }


        public ActionResult Edit(int id/*,int productId*/)
        {
            


            var productPrice = _context.ProductPrices.SingleOrDefault(p => p.Id == id );
           /* var product = _context.Products.SingleOrDefault(p => p.Id == prodid);

            var viewModels = new ProductPriceViewModel
            {
                ProductPrices =  productPrice,
                Products =  product
            };
*/
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            
            return View(productPrice);
        }

        [HttpPost]
        public ActionResult Save(ProductPrice productPrice)
        {
            var productInDb = _context.ProductPrices.Single(p => p.Id == productPrice.Id);
            if (Convert.ToInt64(productInDb.SellingPrice) != Convert.ToInt64(productPrice.SellingPrice))
            {

            productPrice.ProductId = productInDb.ProductId;
            productPrice.DateCreated = DateTime.Now;
            _context.ProductPrices.Add(productPrice);
            _context.SaveChanges();
            }
            else
            {
                productInDb.Remarks = productPrice.Remarks;

            }

            return RedirectToAction("Index");
        }




    }
}