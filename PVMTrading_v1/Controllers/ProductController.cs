
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
 using System.IO;
 using System.Linq;
 using System.Text;
using System.Linq;
 using System.Web;
 using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    /*[AllowAnonymous]*/
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ViewResult Index()
        {
            var products = _context.Products.Include(c => c.Brand)
                .Include(q => q.Branch)
                .Include(w => w.ProductCategory)
                .Include(e => e.ProductCondition)
                .Include(w => w.Warranty).ToList();


            /* For UserRoles Limiting Users who can manage Products*/
            if (User.IsInRole(RoleName.Admin))
                return View(products);


            return View("ReadOnlyView", products);

        }

        [CustomAuthorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var brands = _context.Brands.ToList();
            var branches = _context.Branches.ToList();
            var productCategories = _context.ProductCategories.ToList();
            var productConditions = _context.ProductConditions.ToList();
            var warranties = _context.Warranty.ToList();

            var viewModels = new ProductViewModel
            {
                Brands = brands,
                Branches = branches,
                ProductCategories = productCategories,
                ProductConditions = productConditions,
                Warranties = warranties

            };
            return View(viewModels);
        }


    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product, ProductInclusion productInclusion, ProductPrice productPrice/*, Product model, HttpPostedFileBase file*/)
        {
            /*var decodedString = Convert.ToBase64String(product.ProductImage)
                .Replace("-", "");
            var bytes = Convert.FromBase64String(decodedString);
            var encodedString = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(encodedString);*/

            var isProductExist = _context.Products.Count(c => c.Name == product.Name);



            /* if (!ModelState.IsValid)
             {
                 var viewModel = new ProductViewModel
                 {
                     Product = product,
                     Brands = _context.Brands.ToList(),
                     Branches = _context.Branches.ToList(),
                     ProductCategories = _context.ProductCategories.ToList(),
                     ProductConditions = _context.ProductConditions.ToList(),
                 };

                 return View("New", viewModel);
             }*/
            /*   else
               {
                   var viewModel = new ProductViewModel
                   {
                       Product = product,
                       Brands = _context.Brands.ToList(),
                       Branches = _context.Branches.ToList(),
                       ProductCategories = _context.ProductCategories.ToList(),
                       ProductConditions = _context.ProductConditions.ToList(),
                   };
                   return View("New", viewModel);
               }*/




            if (product.Id == 0)
            {
                if (isProductExist == 0)
                {
                    if (productInclusion.FreeItem != null &&
                        (productInclusion.Quantity != 0 || productInclusion.Quantity != null)/* && file != null*/)
                    {
                        /*model.ProductImage = new byte[file.ContentLength];
                        file.InputStream.Read(model.ProductImage, 0, file.ContentLength);*/



                        productInclusion.ProductId = product.Id;
                        _context.ProductInclusions.Add(productInclusion);
                    }
                    /*_context.Products.Add(model);*/
                    productPrice.ProductId = product.Id;
                    productPrice.DateCreated = DateTime.Now;
                    productPrice.UnitPrice = product.OriginalPrice;
                    _context.ProductPrices.Add(productPrice);

                    // product.Image = sadjkladskjasd;
                    product.Quantity = product.AvailableForSelling + product.Reserved;
                    product.DateCreated = DateTime.Now;
                    _context.Products.Add(product);
                }
                else
                {

                    var viewModel = new ProductViewModel
                    {
                        Product = product,
                        Brands = _context.Brands.ToList(),
                        Branches = _context.Branches.ToList(),
                        ProductCategories = _context.ProductCategories.ToList(),
                        ProductConditions = _context.ProductConditions.ToList(),
                    };
                    return View("New", viewModel);
                }
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Description = product.Description;
                // product.Image = sdcnskdfjskdj;
                /*productInDb.LastChangedEmployee = DateTime.Now;*/
                productInDb.BranchId = product.BranchId;
                productInDb.BrandId = product.BrandId;
                productInDb.ProductCategoryId = product.ProductCategoryId;
                productInDb.IsReturned = product.IsReturned;
                productInDb.Model = product.Model;
                productInDb.OriginalPrice = product.OriginalPrice;
                productInDb.ProductConditionId = product.ProductConditionId;
                productInDb.SerialNumber = product.SerialNumber;
                productInDb.Quantity = product.AvailableForSelling + product.Reserved;
                productInDb.WarrantyId = product.WarrantyId;
                productInDb.AvailableForSelling = product.AvailableForSelling;
                productInDb.Reserved = product.Reserved;


                var productInclusionInDb = _context.ProductInclusions.Single(p => p.ProductId == product.Id);
                if (productInclusionInDb.ProductId != 0)
                {
                    productInclusionInDb.FreeItem = productInclusion.FreeItem;
                    productInclusion.Quantity = productInclusion.Quantity;
                }
            }




            _context.SaveChanges();
            Dispose();
            return RedirectToAction("Index");
        }


        //        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {

            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            var productInclsion = _context.ProductInclusions.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = product,
                ProductInclusion = productInclsion,
                Brands = _context.Brands.ToList(),
                Branches = _context.Branches.ToList(),
                ProductConditions = _context.ProductConditions.ToList(),
                ProductCategories = _context.ProductCategories.ToList(),
                Warranties = _context.Warranty.ToList()

            };
            return View(viewModel);

        }


        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Single(p => p.Id == id);
            var productInclusion = _context.ProductInclusions.Single(p => p.ProductId == id);
            var productPrices = _context.ProductPrices.SingleOrDefault(p => p.ProductId == id);
            if (product.Id != 0)
            {
                _context.ProductInclusions.Remove(productInclusion);
                _context.Products.Remove(product);
                _context.ProductPrices.Remove(productPrices);
            }


            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Details(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            var productInclsion = _context.ProductInclusions.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }



            var viewModel = new ProductViewModel
            {
                Product = product,
                ProductInclusion = productInclsion,
                Brands = _context.Brands.ToList(),
                Branches = _context.Branches.ToList(),
                ProductConditions = _context.ProductConditions.ToList(),
                ProductCategories = _context.ProductCategories.ToList(),
                Warranties = _context.Warranty.ToList()

            };

            return View(viewModel);
        }








    }
}