using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;
using PVMTrading_v1.Controllers;

namespace PVMTrading_v1.Controllers
{
    public class CashTransactionController : Controller
    {

        private ApplicationDbContext _context;

        public CashTransactionController()
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

            var cashtransact = _context.CashTransactions.Include(c => c.Customer).ToList();


            return View(cashtransact);
        }

        //select customer search
        public ActionResult SearchCustomer()
        {
            var customers = _context.Customers;

            var customersList = customers.ToList();
            return View(customersList);
        }

      
        
        public ActionResult CashTransactionSummary()
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

        public ActionResult Save(CashTransaction cashTransaction,CashTransactionViewModel viewModel)

        {   var cashTransactionItem = new CashTransactionItem();
            foreach (var item in _context.TempCarts.ToList())
            {
              cashTransactionItem.ProductId = item.ProductId;
             cashTransactionItem.CashTransactionId =cashTransaction.Id ;
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
            return RedirectToAction("CashTransactionSummary");
        }


        public ActionResult Delete(string id)
        {
          
            var voidTransact = _context.CashTransactions.SingleOrDefault(c => c.Id == id);
            var voidItems = _context.CashTransactionItems.Where(c => c.CashTransactionId == id);
            var product = new Product();
            foreach (var c in voidItems.ToList())
            {
                product =  _context.Products.SingleOrDefault(b => b.Id == c.ProductId);
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
            foreach (var c in voidItems.ToList())
            {

                ViewData["ListItem"] = c;

            }

            var vm = new CashTransactionListViewModel
            {
                CashTransaction = Transact,

                Customer = customer
            };


            return View(vm);
        }

        /*public JsonResult AutocompleteSuggestions(string searchstring)
        {
            
        var suggestions = from s in _context.Customers
            select s.FirstName;
            var suggest = _context.Customers.ToList();
        var namelist = suggestions.Where(n => n.ToLower().StartsWith(searchstring.ToLower()));

            return Json(namelist, JsonRequestBehavior.AllowGet);
    }*/

        /*  public ActionResult Grid()
          {
              var result = (from c in _context.Customers
                  select new Customer
                  {
                      Id = c.Id,
                      FirstName = c.FirstName,
                      MiddleName = c.MiddleName,
                      LastName = c.LastName
                  }).ToList().AsQueryable(); ;
              return View(result);
          }
    */
        /*  protected string RenderRazorViewToString(string viewName, object model)
          {
              if (model != null)
              {
                  ViewData.Model = model;
              }

              using (var sw = new StringWriter())
              {
                  var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                  var viewContext = new ViewContext(ControllerContext,viewResult.View,ViewData,TempData,sw);
                  viewResult.View.Render(viewContext,sw);
                  viewResult.ViewEngine.ReleaseView(ControllerContext,viewResult.View);
                  return sw.GetStringBuilder().ToString();
              }

          }*/



        /*  public ActionResult ProductInfo(int id)
          {

              var product = _context.Products.SingleOrDefault(c => c.Id == id);
              /*if (product == null)
              {
                  return HttpNotFound();
              }
              var productInfo = new ProductViewModel()
              {
                  Product = product

              };


              return PartialView(productInfo);#1#

              /*var order = (Product)Session["Order"];
              return PartialView(order.Model);#1#

              return View(product);
          }*/

        /*       public ActionResult ProductView()
               {
                   var product = _context.Products.ToList();

                   if (product == null)
                   {
                       return HttpNotFound();
                   }
                   var Productsview = new CashTransactionViewModel()
                   {
                       Product = product,
                       CustomerCompleInfo = customerInfo,
                       CustomerTypes = _context.CustomerTypes.ToList(),
                       CivilStatuses = _context.CivilStatus.ToList()
                   };


                   return PartialView(Productsview);

               }*/



    }
}