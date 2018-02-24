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
	public class SearchProductController : Controller
	{
		private ApplicationDbContext _context;

		public SearchProductController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult ProductList()
	    {

	        //selection of product by branch query missing
	        var prod = _context.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
	        ViewBag.productCounts = _context.Products.Count();

	        var product = _context.Products.Include(p => p.ProductCategory);

	        return View(prod.ToList());

	    }


        // GET: SearchProduct
	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Index()
	    {
	        var tempCartList = _context.TempCarts.Include(c => c.Product).ToList();
	        ViewBag.CountofProducts = _context.TempCarts.Count();
	        return View("Cart", tempCartList);
	    }

	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult BuyNow(int id,double price)
	    {
            var tempCart = new TempCart();
	      
	        var isProduct = _context.TempCarts.Count(p => p.ProductId == id);

	        var productQuantity = _context.TempCarts.Where(p => p.ProductId == id);

            if (isProduct == 0)
	        {
	            tempCart.ProductId = id;
	            tempCart.Quantity = 1;
	            tempCart.ProductPrice = price;
	            _context.TempCarts.Add(tempCart);
	        }
	        else
	        {
	            AddQuantity(id,tempCart.Quantity);
	        }

	        _context.SaveChanges();
	       return RedirectToAction("Index");
	    }
	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult DeleteFromCart(int id)
	    {
	        var deleteItem = _context.TempCarts.SingleOrDefault(c => c.Id == id);
            if(deleteItem != null)
	        _context.TempCarts.Remove(deleteItem);
	        _context.SaveChanges();
	        return RedirectToAction("Index");
	    }
	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult DeleteAllProdsInCart()
	    {
	        var temp = _context.TempCarts;
	        
	        foreach (var d in temp.ToList())
	        {
	            _context.TempCarts.Remove(_context.TempCarts.SingleOrDefault(c => c.Id == d.Id));
            }

	      
	        _context.SaveChanges();
	        return RedirectToAction("Index");
	    }



	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult AddQuantity(int id,int quantity)
	    {
	        var tempCart = _context.TempCarts.SingleOrDefault(p => p.Id == id);
            if(tempCart != null && tempCart.Quantity < quantity)
            {  ++tempCart.Quantity;

	        _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
	    [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult LessQuantity(int id,int quantity)
	    {
	        var tempCart = _context.TempCarts.SingleOrDefault(p => p.Id == id);
	        if (tempCart != null && tempCart.Quantity >1) { 
	            --tempCart.Quantity;
            _context.SaveChanges();
	        }

            return RedirectToAction("Index");
        }
        /*public ActionResult BuyNow(int id, double price)
	    {
	        if (Session["cart"] == null)
	        {
	            List<Item> cart = new List<Item>();
	            cart.Add(new Item(_context.Products.Find(id), 1, price));
	            Session["cart"] = cart;
	        }

	        /* else
             {
                 List<Item> cart = (List<Item>)Session["cart"];
                 cart.Add(new Item(_context.Products.Find(id), 1));
                 Session["cart"] = cart;
             }
   #1#
	        else
	        {
	            List<Item> cart = (List<Item>)Session["cart"];
	            int index = IsExisting(id);
	            if (index == -1)
	                cart.Add(new Item(_context.Products.Find(id), 1, price));
	            else
	            {
	                cart[index].Quantity++;
	            }
	            Session["cart"] = cart;
	        }
	        return View("Cart");
	    }*/

































        /*public ActionResult SearchProd()
		{
			/*var product = _context.Products.SingleOrDefault(p => p.Id == id);
			var productInclsion = _context.ProductInclusions.SingleOrDefault(p => p.ProductId == id);
			var productPrices = _context.ProductPrices.OrderByDescending(p => p.DateCreated).FirstOrDefault();
			
			if (product == null)
			{
				return HttpNotFound();
			}
			#1#
			/* Need to get dynamically all prices base to its product id and get only their newest price#1#


			/*
						var productPrices = _context.Products.Join(_context.ProductPrices, c => c.Id, p => p.ProductId,
							(product, productPrice) => new
							{
								Product = product,
								ProductPrice = productPrice
							}).OrderByDescending( p=> p.ProductPrice.DateCreated).FirstOrDefault();



						var prodPrice = _context.Products.ToList();
						foreach (var item in productPrices)
						{
							item.ProductP.Person = (from p in db.People
								where p.BusinessEntityID == item.PersonID
								select p).First();
						}
						return View(departments.ToList());

						/* var prices = _context.ProductPrices.Join(_context.Products, c => c.ProductId, p => p.Id,
							 (productPrice, product) => new
							 {

							 });
			 #2#
						var countProducts =;
					   #1#

			//  _context.ProductPrices.SqlQuery("Select * From ProductPrices,Products Where Products.Id = ProductPrices.ProductId");
		/*   var productPrices= _context.Products.Join(_context.ProductPrices, c => c.Id, p => p.ProductId,
				(product, productPrice) => new SearchProductViewModels()
				{
					Product = product,
					ProductPrice = productPrice
				}).ToList();

			var ss = _context.ProductPrices.Include(s => s.Product).ToList();
		#1#    /*  var price = _context.Products.Join(_context.ProductPrices, product => product.Id, p => p.ProductId,
				  (p, pp) => new
				  {
					  Product = p,
					  ProductPrice = pp}).ToList();

			  var priceList = price.OrderByDescending(p => p.ProductPrice.DateCreated).FirstOrDefault();

		  #1#

			
		  
			var prodList = _context.Database.SqlQuery<SearchProductViewModels>(@"SELECT Products.*, 
												 Amount = (Select top 1 ProductPrices.SellingPrice 
												From ProductPrices
												Where ProductPrices.ProductId = Products.Id
												Order by ProductPrices.Id Desc )
										FROM Products").ToList<SearchProductViewModels>();

			/*   var sample =_context.Database.SqlQuery<SearchProductViewModels>(@"Select Distinct Products.Name, Products.Model, Products.Id SellingPrice 
														   From Products Join  ProductPrices 
														   on Products.Id=ProductPrices.ProductId ");
			#1#
			var prod = _context.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
				ViewBag.productCounts = _context.Products.Count();

		
			return View(prod.ToList());


	  
		}*/


    }
}