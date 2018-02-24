using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class LayAwayTransactionController : Controller
    {
        private ApplicationDbContext _context;

        public LayAwayTransactionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CashTransaction
        [CustomAuthorize(Roles = "Admin,Cashier,Sales Clerk")]

        public ActionResult Index()
        {
            var layAway = _context.LayAwayTransactions.Include(c => c.Product)
                                                      .Include(c => c.Customer).ToList();
          
            return View(layAway);
        }

        //select customer search
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult SearchCustomer()
        {
            var customers = _context.Customers;

           
            return View(customers.ToList());
        }

        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult ProductList()
        {
            //selection of product by branch query missing
            var prod = _context.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
            ViewBag.productCounts = _context.Products.Count();


            return View(prod.ToList());

        }

        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult BuyNow(int id, double price)
        {
            var tempCart = new TempCart();
            var tempCartCount = _context.TempCarts.Count();
            var isProduct = _context.TempCarts.Count(p => p.ProductId == id);

           // var productQuantity = _context.TempCarts.Where(p => p.ProductId == id);
            if (tempCartCount <1)
            {
                 if (isProduct == 0)
                {
                    tempCart.ProductId = id;
                    tempCart.Quantity = 1;
                    tempCart.ProductPrice = price;
                    _context.TempCarts.Add(tempCart);
                    _context.SaveChanges();
                }

            }
            
            return RedirectToAction("Cart");
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Cart()
        {
            var tempCartList = _context.TempCarts.Include(c => c.Product).ToList();
            ViewBag.CountofProducts = _context.TempCarts.Count();
            return View( tempCartList);
        }



        [CustomAuthorize(Roles = "Admin,CashieR")]

        public ActionResult DeleteFromCart(int id)
        {
            var deleteItem = _context.TempCarts.SingleOrDefault(c => c.Id == id);
            if (deleteItem != null)
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

        public ActionResult AddQuantity(int id, int quantity)
        {
            var tempCart = _context.TempCarts.SingleOrDefault(p => p.Id == id);
            if (tempCart != null && tempCart.Quantity < quantity)
            {
                ++tempCart.Quantity;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult LessQuantity(int id, int quantity)
        {
            var tempCart = _context.TempCarts.SingleOrDefault(p => p.Id == id);
            if (tempCart != null && tempCart.Quantity > 1)
            {
                --tempCart.Quantity;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Select(int id)
        {
            var count = _context.LayAwayTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year) + "00" + Convert.ToString(count + 1) + Convert.ToString(DateTime.Today.Day);

            var layAway = new LayAwayTransaction();

            double totalPrice = 0;
            var product = 0;
            var quantity = 0;
            foreach (var c in _context.TempCarts.ToList())
            {
                totalPrice = totalPrice + (c.ProductPrice * c.Quantity);

                product = c.ProductId;
                quantity = c.Quantity;
            }

            //add product quantity to reserved and minus to available for selling
            var reservedItem = _context.Products.SingleOrDefault(p => p.Id == product);
            reservedItem.AvailableForSelling = reservedItem.AvailableForSelling - quantity;
            reservedItem.Reserved = reservedItem.Reserved + quantity;

            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            layAway.Id = cashId;
            layAway.CustomerId = selectCustomer.Id;
            layAway.TotalAmount = totalPrice;
            layAway.RemainingBalance = totalPrice;
            layAway.Remarks = "";
            layAway.ProductId = product;
            layAway.Quantity = quantity;
            layAway.TotalPaidAmount =0 ;
            _context.LayAwayTransactions.Add(layAway);
            _context.SaveChanges();
            return RedirectToAction("LayAwayTransactionSummary",new {cashId});
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult LayAwayTransactionSummary(string layAwayId)
        {
            var layAwayTransaction = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == layAwayId);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == layAwayTransaction.CustomerId);
            var product = _context.Products.SingleOrDefault(p => p.Id == layAwayTransaction.ProductId);

            var viewModel = new LayAwayTransactionViewModel
            {
                LayAwayTransaction = layAwayTransaction,
                Customer = customer,
                Product = product

            };

            return View(viewModel);
        }


        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Save(LayAwayTransactionViewModel vm)
        {
            var LayAinDb = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == vm.LayAwayTransaction.Id);
            LayAinDb.CustomerId = vm.LayAwayTransaction.CustomerId;
            LayAinDb.TotalPaidAmount = vm.LayAwayTransactionReceipt.AmountPaid;
            LayAinDb.ProductId = vm.LayAwayTransaction.ProductId;
            LayAinDb.Remarks = vm.LayAwayTransaction.Remarks;
            LayAinDb.RemainingBalance = vm.LayAwayTransaction.TotalAmount - vm.LayAwayTransactionReceipt.AmountPaid;

            
            vm.LayAwayTransactionReceipt.DateTransaction = DateTime.Now;
            vm.LayAwayTransactionReceipt.LayAwayTransactionId = vm.LayAwayTransaction.Id;
            _context.LayAwayTransactionReceipts.Add(vm.LayAwayTransactionReceipt);

            var temp = _context.TempCarts;

            foreach (var d in temp.ToList())
            {
                _context.TempCarts.Remove(_context.TempCarts.SingleOrDefault(c => c.Id == d.Id));
            }

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Delete(string id)
        {

            var voidTransact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == id);

            voidTransact.IsVoid = true;


            var product = new Product();

            product = _context.Products.SingleOrDefault(b => b.Id == voidTransact.ProductId);
            product.AvailableForSelling = product.AvailableForSelling + voidTransact.Quantity;
            product.Reserved = product.AvailableForSelling - voidTransact.Quantity;

           
            


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Details(string id)
        {
            var transact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == transact.CustomerId);
            var product = _context.Products.SingleOrDefault(c => c.Id == transact.ProductId);
            var voidItems = _context.LayAwayTransactionReceipts.Where(c => c.LayAwayTransactionId == id);
            /* var product = new Product();*/

            ViewData["ListItem"] = voidItems.ToList();

            var vm = new LayAwayTransactionViewModel()
            {
                LayAwayTransaction = transact,
                Product = product,
                Customer = customer,
            };


            return View(vm);
        }

        public ActionResult Update()
        {

            return View();
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Update(LayAwayTransactionReceipt layAway)
        {
            var transact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == layAway.LayAwayTransactionId);
            transact.TotalPaidAmount = transact.TotalPaidAmount + layAway.AmountPaid;

            _context.LayAwayTransactionReceipts.Add(layAway);
            _context.SaveChanges();
            return View();
        }
    }
}