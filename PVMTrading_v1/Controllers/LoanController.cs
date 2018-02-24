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



        // GET: Loans
        [CustomAuthorize(Roles = "Admin,Cashier,Sales Clerk")]
        public ActionResult Index()
        {

            var loans = _context.Loans.Include(c => c.Customer)
                                       .Include(s => s.LoanStatus)
                                        .Include(s => s.ModeOfPayment)
                                        .Include(e => e.Product).ToList();


            return View(loans);
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        //select customer search
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
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Cart()
        {
            var tempCartList = _context.TempCarts.Include(c => c.Product).ToList();
            ViewBag.CountofProducts = _context.TempCarts.Count();
            return View(tempCartList);
        }



        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult DeleteFromCart(int id)
        {
            var deleteItem = _context.TempCarts.SingleOrDefault(c => c.Id == id);
            if (deleteItem != null)
                _context.TempCarts.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction("Cart");
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
            return RedirectToAction("Cart");
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
            return RedirectToAction("Cart");
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

            return RedirectToAction("Cart");
        }


        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Select(int id)
        {
            var count = _context.Loans.Count();
            var loanId = Convert.ToString(DateTime.Today.Year) + Convert.ToString(DateTime.Today.Month) + "0" + Convert.ToString(count + 1) ;

            var loan = new Loan();

            double totalPrice = 0;

            foreach (var c in _context.TempCarts.ToList())
            {
                totalPrice = totalPrice + (c.ProductPrice * c.Quantity);
                loan.ProductId = c.ProductId;
                loan.Quantity = c.Quantity;
                loan.ProductPrice = c.ProductPrice;
               
            }

            var prod = _context.Products.SingleOrDefault(p => p.Id == loan.ProductId);
            
            prod.AvailableForSelling = prod.AvailableForSelling - loan.Quantity;
            prod.Reserved = prod.Reserved + loan.Quantity;


            var selectCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            loan.Id = loanId;
            loan.ModeOfPaymentId = 4;
            loan.CustomerId = selectCustomer.Id;
            loan.LoanDateCreated = DateTime.Now;
            loan.LoanAmount = totalPrice;
            loan.LoanStatusId = 1;
            loan.Remarks = "";
            loan.InterestRate = 4;
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToAction("LoanSummary",new { loanId});
        }


        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult LoanSummary(string loanId)
          {
              var loan = _context.Loans.SingleOrDefault(c => c.Id == loanId);
              var customer = _context.Customers.SingleOrDefault(c => c.Id == loan.CustomerId);
              var product = _context.Products.SingleOrDefault(p => p.Id == loan.ProductId);
              
              var viewModel = new LoanViewModel
              {
                  Loan = loan,
                  Customer = customer,
                  Product = product,
                  ModeOfPayment = _context.ModeOfPayment.ToList(),
                  LoanStatus = _context.LoanStatus.ToList()

              };

              return View(viewModel);
          }

        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Save(LoanViewModel lvm)
         {
            var loanInDb = _context.Loans.SingleOrDefault(c => c.Id == lvm.Loan.Id);


             loanInDb.LoanAmount = lvm.Loan.LoanAmount;
             loanInDb.Downpayment = lvm.Loan.Downpayment;
             loanInDb.DuePayment = lvm.Loan.DuePayment;
             loanInDb.Remarks = lvm.Loan.Remarks;
             loanInDb.ModeOfPaymentId = lvm.Loan.ModeOfPaymentId;
             loanInDb.Terms = lvm.Loan.Terms;
           
               var temp = _context.TempCarts;
            foreach (var d in temp.ToList())
              {
                _context.TempCarts.Remove(_context.TempCarts.SingleOrDefault(c => c.Id == d.Id));
              }

              _context.SaveChanges();

            Dispose();
              return RedirectToAction("Index");
                       }

        [CustomAuthorize(Roles = "Admin")]

        public ActionResult Delete(string id)
            {
                var voidTransact = _context.Loans.SingleOrDefault(c => c.Id == id);


                voidTransact.LoanStatusId = 3;

                var prod = _context.Products.SingleOrDefault(p => p.Id == voidTransact.ProductId);

                prod.AvailableForSelling = prod.AvailableForSelling + voidTransact.Quantity;
                prod.Reserved = prod.Reserved - voidTransact.Quantity;

                   _context.SaveChanges();
                   return RedirectToAction("Index");
                             }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Details(string id)
           {
            var transact = _context.Loans.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == transact.CustomerId);
            var product = _context.Products.SingleOrDefault(c => c.Id == transact.ProductId);
            var duePayment = _context.LoanDuePayments.Where(c => c.LoanId == id);
          

               ViewData["ListPayment"] = duePayment.ToList();

                                  var vm = new LoanViewModel
                                  {
                                      Loan = transact,
                                      Product = product,
                                      Customer = customer,
                                      LoanStatus = _context.LoanStatus.ToList(),
                                      ModeOfPayment = _context.ModeOfPayment.ToList()
                                  };


                                  return View(vm);
                              }

       public ActionResult Update(string id)
        {
                            
          var duePayment = _context.LoanDuePayments.OrderByDescending(c => c.Id).FirstOrDefault(c => c.LoanId == id);
            

            if (duePayment.DueDateTime.Date.AddMonths(1) <= DateTime.Now.Date && duePayment.DueDateTime.Date.AddMonths(2) > DateTime.Now.Date)
            {
                duePayment.TotalAmountDue = duePayment.TotalAmountDue * (duePayment.TotalAmountDue * 0.03);
                
            }
            if (duePayment.DueDateTime.Date.AddMonths(2) <= DateTime.Now.Date && duePayment.DueDateTime.Date.AddMonths(3) > DateTime.Now.Date)
            {
                duePayment.TotalAmountDue = duePayment.TotalAmountDue * (duePayment.TotalAmountDue * 0.06);

            }
            if (duePayment.DueDateTime.Date.AddMonths(3) <= DateTime.Now.Date && duePayment.DueDateTime.Date.AddMonths(4) > DateTime.Now.Date)
            {
                duePayment.TotalAmountDue = duePayment.TotalAmountDue * (duePayment.TotalAmountDue * 0.09);

            }
            if (duePayment.DueDateTime.Date.AddMonths(4) <= DateTime.Now.Date)
            {
                var blacklisted = _context.Loans.SingleOrDefault(c => c.Id == duePayment.LoanId);
                blacklisted.LoanStatusId = 3;
                var customer = _context.CustomerCompleInfos.SingleOrDefault(c => c.Id == blacklisted.CustomerId);
                customer.CustomerTypeId = 3;
                }

            _context.SaveChanges();
            return View(duePayment);
          
                        }

        [CustomAuthorize(Roles = "Admin,Cashier")]
        public ActionResult SaveUpdateLoan(LoanDuePayment ldp)
        {
            var loanDue = _context.LoanDuePayments.SingleOrDefault(c => c.Id == ldp.Id);
            loanDue.OR = ldp.OR;
            loanDue.TotalAmountDue = ldp.TotalAmountDue;
            loanDue.IsPaid = true;
            loanDue.PenaltyAmount = ldp.PenaltyAmount;

            var loan = _context.Loans.SingleOrDefault(c => c.Id == loanDue.LoanId);
            loan.LoanTotalPayment = loan.LoanTotalPayment + ldp.TotalAmountDue;

            var DueDate = new LoanDuePayment();
            DueDate.LoanId = loanDue.LoanId;
            if (loan.ModeOfPaymentId == 1)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(1);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;

            }

            if (loan.ModeOfPaymentId == 2)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(7);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }

            if (loan.ModeOfPaymentId == 3)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(14);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }

            if (loan.ModeOfPaymentId == 4)
            {
                DueDate.DueDateTime = DateTime.Today.AddMonths(1);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }

            _context.LoanDuePayments.Add(DueDate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Approve(string id)
                {
                         var transact = _context.Loans.SingleOrDefault(c => c.Id == id);
                    transact.LoanStatusId = 2;
                    
                    var downPayment = new LoanDuePayment();

                    downPayment.LoanId = id;
                    downPayment.DueDateTime = DateTime.Now;
                    downPayment.PenaltyAmount = 0;
                    downPayment.TotalAmountDue = transact.Downpayment;
                    downPayment.IsPaid = true;
                    _context.LoanDuePayments.Add(downPayment);
                    _context.SaveChanges();

                     var loandue = _context.LoanDuePayments.SingleOrDefault(c => c.LoanId == id);

                    return View(loandue);

        }
        /*  public ActionResult Update(LayAwayTransactionReceipt layAway)
           {
            var transact = _context.LayAwayTransactions.SingleOrDefault(c => c.Id == layAway.LayAwayTransactionId);
             transact.TotalPaidAmount = transact.TotalPaidAmount + layAway.AmountPaid;
             _context.LayAwayTransactionReceipts.Add(layAway);
                                  _context.SaveChanges();
                                  return View();
                                              }*/
        public ActionResult CreateTrackDuePayment(LoanDuePayment ldp)
        {
            var loanDue = _context.LoanDuePayments.SingleOrDefault(c => c.Id == ldp.Id);
            loanDue.OR = ldp.OR;

            var loan = _context.Loans.SingleOrDefault(c => c.Id == loanDue.LoanId);
            
            var DueDate = new LoanDuePayment();
            DueDate.LoanId = loanDue.LoanId;
            if (loan.ModeOfPaymentId == 1)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(1);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
                
            }

            if (loan.ModeOfPaymentId == 2)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(7);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }

            if (loan.ModeOfPaymentId == 3)
            {
                DueDate.DueDateTime = DateTime.Today.AddDays(14);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }

            if (loan.ModeOfPaymentId == 4)
            {
                DueDate.DueDateTime = DateTime.Today.AddMonths(1);
                DueDate.TotalAmountDue = loan.DuePayment;
                DueDate.LoanId = loan.Id;
            }
            
            _context.LoanDuePayments.Add(DueDate);
            _context.SaveChanges();
            return RedirectToAction("Details",new {loan.Id});
        }




        public ActionResult TrackDuePayment()
        {
            var trackDue = _context.LoanDuePayments.Include(c => c.Loan).ToList();
            return View();
        }

    }
}