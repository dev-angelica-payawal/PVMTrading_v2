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
        public ActionResult Index()
        {

            var layAway = _context.LayAwayTransactions.Include(c => c.Product)
                                                      .Include(c => c.Customer).ToList();


            return View(layAway);
        }

        //select customer search
        public ActionResult SearchCustomer()
        {
            var customers = _context.Customers;

           
            return View(customers.ToList());
        }


        public ActionResult ProductList()
        {
            //selection of product by branch query missing
            var prod = _context.ProductPrices.Include(p => p.Product).OrderByDescending(p => p.Id).DistinctBy(p => p.ProductId);
            ViewBag.productCounts = _context.Products.Count();


            return View(prod.ToList());

        }


        public ActionResult BuyNow(int id, double price)
        {
            var tempCart = new TempCart();

            var isProduct = _context.TempCarts.Count(p => p.ProductId == id);

           // var productQuantity = _context.TempCarts.Where(p => p.ProductId == id);

            if (isProduct == 0)
            {
                tempCart.ProductId = id;
                tempCart.Quantity = 1;
                tempCart.ProductPrice = price;
                _context.TempCarts.Add(tempCart);
            }
          

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LayAwayTransactionSummary()
        {
            var count = _context.CashTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year) + "00" + Convert.ToString(count) + Convert.ToString(DateTime.Today.Day);
            var cashTransaction = _context.CashTransactions.SingleOrDefault(c => c.Id == cashId);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == cashTransaction.CustomerId);

            var viewModel = new CashTransactionViewModel
            {
                CashTransaction = cashTransaction,
                Customer = customer

            };

            return View(viewModel);
        }


        public ActionResult CashTransactionItemListSummary()
        {

            return View(_context.TempCarts.ToList());
        }

        public ActionResult Save(CashTransaction cashTransaction, CashTransactionViewModel viewModel)

        {
            var cashTransactionItem = new CashTransactionItem();
            foreach (var item in _context.TempCarts.ToList())
            {
                cashTransactionItem.ProductId = item.ProductId;
                cashTransactionItem.CashTransactionId = cashTransaction.Id;
                cashTransactionItem.ProductPrice = item.ProductPrice;
                cashTransactionItem.Quantity = item.Quantity;
                _context.CashTransactionItems.Add(cashTransactionItem);
            }

            var cash = _context.CashTransactions.SingleOrDefault(c => c.Id == cashTransaction.Id);
            cash.CustomerId = cashTransaction.CustomerId;
            cash.CashTransactionDate = DateTime.Now;
            cash.OR = cashTransaction.OR;
            cash.TotalAmount = cash.OriginalTotalAmount - cash.TotalDiscountedAmount;
            cash.TotalDiscountedAmount = cashTransaction.TotalDiscountedAmount;
            cash.Remarks = cashTransaction.Remarks;

            var temp = _context.TempCarts;

            foreach (var d in temp.ToList())
            {
                _context.TempCarts.Remove(_context.TempCarts.SingleOrDefault(c => c.Id == d.Id));
            }

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Select(int id)
        {
            var count = _context.CashTransactions.Count();
            var cashId = Convert.ToString(DateTime.Today.Year) + "00" + Convert.ToString(count + 1) + Convert.ToString(DateTime.Today.Day);

            var cashTransaction = new CashTransaction();

            double totalPrice = 0;

            foreach (var c in _context.TempCarts.ToList())
            {
                totalPrice = totalPrice + (c.ProductPrice * c.Quantity);

            }


            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            cashTransaction.Id = cashId;
            cashTransaction.CustomerId = selectCustomer.Id;
            cashTransaction.CashTransactionDate = DateTime.Now;
            cashTransaction.OriginalTotalAmount = totalPrice;
            cashTransaction.Remarks = "";
            _context.CashTransactions.Add(cashTransaction);
            _context.SaveChanges();
            return RedirectToAction("");
        }


        public ActionResult Delete(string id)
        {

            var voidTransact = _context.CashTransactions.SingleOrDefault(c => c.Id == id);
            var voidItems = _context.CashTransactionItems.Where(c => c.CashTransactionId == id);
            var product = new Product();
            foreach (var c in voidItems.ToList())
            {
                product = _context.Products.SingleOrDefault(b => b.Id == c.ProductId);
                product.AvailableForSelling = product.AvailableForSelling + c.Quantity;
            }

            voidTransact.IsVoid = true;



            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var Transact = _context.CashTransactions.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Transact.CustomerId);
            var voidItems = _context.CashTransactionItems.Where(c => c.CashTransactionId == id);
            /* var product = new Product();*/

            ViewData["ListItem"] = voidItems.ToList();

            var vm = new CashTransactionListViewModel
            {
                CashTransaction = Transact,

                Customer = customer
            };


            return View(vm);
        }
    }
}