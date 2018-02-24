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
    public class LoanController : Controller
    {
        private ApplicationDbContext _context;

        public LoanController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Loan
         // GET: Loan
        public ActionResult Index()
        {
            
            var loans = _context.Loans.Include(c => c.Customer)
                                       .Include(s => s.LoanStatus).ToList();
           /* var loanstatus = _context.Loans.Where(c => c.LoanStatusId == '1').SelectMany(o => o.Customer).Count();
            var pending = _context.Loans.Count().CompareTo();
            var approved = _context.LoanStatus.SqlQuery("Select Count(2) from dbo.Loans where LoanStatusId = 2");
            var disapproved = _context.LoanStatus.SqlQuery("Select Count(3) from dbo.Loans where LoanStatusId = 3");*/

            /*ViewBag.Pending = pending;
            ViewBag.Approved = approved;
            ViewBag.Disapproved = disapproved;*/
            return View(loans);
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
            var tempCartCount = _context.TempCarts.Count();
            var isProduct = _context.TempCarts.Count(p => p.ProductId == id);

            // var productQuantity = _context.TempCarts.Where(p => p.ProductId == id);
            if (tempCartCount < 1)
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

        public ActionResult Cart()
        {
            var tempCartList = _context.TempCarts.Include(c => c.Product).ToList();
            ViewBag.CountofProducts = _context.TempCarts.Count();
            return View(tempCartList);
        }




        public ActionResult DeleteFromCart(int id)
        {
            var deleteItem = _context.TempCarts.SingleOrDefault(c => c.Id == id);
            if (deleteItem != null)
                _context.TempCarts.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

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

        public ActionResult LessQuantity(int id, int quantity)
        {
            var tempCart = _context.TempCarts.SingleOrDefault(p => p.Id == id);
            if (tempCart != null && tempCart.Quantity > 0)
            {
                --tempCart.Quantity;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Select(int id)
        {
            var count = _context.Loans.Count();
            var loanId = Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month) + "0" + Convert.ToString(count + 1) ;

            var loan = new Loan();

            double totalPrice = 0;

            foreach (var c in _context.TempCarts.ToList())
            {
                totalPrice = totalPrice + (c.ProductPrice * c.Quantity);

            }


            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            loan.Id = loanId;
            loan.CustomerId = selectCustomer.Id;
            loan.LoanDateCreated = DateTime.Now;
            loan.LoanAmount = totalPrice;
            loan.Remarks = "";
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return RedirectToAction("");
        }



        /*  public ActionResult CashTransactionSummary()
          {
              var count = _context.Loans.Count();
              var loanId = Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month) + "0" + Convert.ToString(count + 1);
              var cashTransaction = _context.Loans.SingleOrDefault(c => c.Id == loanId);
              var customer = _context.Customers.SingleOrDefault(c => c.Id == cashTransaction.CustomerId);

              var viewModel = new CashTransactionViewModel
              {
                  CashTransaction = cashTransaction,
                  Customer = customer

              };

              return View(viewModel);
          }


          public ActionResult Save(CashTransaction cashTransaction)

          {
              var cashTransactionItem = new CashTransactionItem();



              foreach (var item in _context.TempCarts.ToList())
              {
                  cashTransactionItem.ProductId = item.ProductId;
                  cashTransactionItem.CashTransactionId = cashTransaction.Id;
                  cashTransactionItem.ProductPrice = item.ProductPrice;
                  cashTransactionItem.Quantity = item.Quantity;
                  _context.CashTransactionItems.Add(cashTransactionItem);
                  //minus product stock to available for selling
                  _context.Products.SingleOrDefault(p => p.Id == item.ProductId).AvailableForSelling = _context.Products.SingleOrDefault(p => p.Id == item.ProductId).AvailableForSelling - item.Quantity;
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
              var transact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == id);
              var customer = _context.Customers.SingleOrDefault(c => c.Id == transact.CustomerId);
              var product = _context.Products.SingleOrDefault(c => c.Id == transact.ProductId);
              var voidItems = _context.LayAwayTransactionReceipts.Where(c => c.LayAwayTransactionId == id);
              /* var product = new Product();#1#

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

          public ActionResult Update(LayAwayTransactionReceipt layAway)
          {
              var transact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == layAway.LayAwayTransactionId);
              transact.TotalPaidAmount = transact.TotalPaidAmount + layAway.AmountPaid;

              _context.LayAwayTransactionReceipts.Add(layAway);
              _context.SaveChanges();
              return View();
          }*/
    }
}