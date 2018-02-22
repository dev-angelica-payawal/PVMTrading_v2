using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using PVMTrading_v1.Migrations;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;


namespace PVMTrading_v1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

/*
        public ViewResult CosCount(int id)
        {

            var C = _context.Customers.SqlQuery("SELECT COUNT Id FROM dbo.Customers");

            return View(C);
        }
*/

        public ActionResult Index()
        {

            var customer = _context.Customers.Include(s => s.Sex).ToList();

            return View(customer);
            /*List<Customer> customers = new List<Customer>();
            List<CustomerCompleInfo> customerCompleteInfos = new List<CustomerCompleInfo>();*/
            /*var customers = _context.Customers.Include(c => c.CustomerType)
                                              .Include(p=> p.CivilStatus)
                                              .Include(s => s.Sex).ToList();*/





            /*var customers = _context.Customers.Include(s => s.Sex).ToList();*/
            
            /*var customerInfo = from s in customers

                join st in customerCompleteInfos on s.Id equals st.CustomerId into st2
                from st in st2.DefaultIfEmpty()
                select new CustomerViewModel { Customer = s, CustomerCompleInfo = st };

            List<CustomerViewModel> customerCompleteList = new List<CustomerViewModel>();
            customerCompleteList = customerInfo.ToList();   */



            /* var details = from customer in _context.Customers
                 join customerCompleInfo in _context.CustomerCompleInfos
                     on customer.Id equals customerCompleInfo.Id
                 where customerCompleInfo.CustomerId == customer.Id
                 select new
                 {
                     id = customer.Id,
                     firstname = customer.FirstName,
                     middleName = customer.MiddleName,
                     lastName = customer.LastName,
                     nameExtension = customer.NameExtension,
                     mobile = customer.Mobile,
                     sexid = customer.Sexid,
                     registeredDateCreated = customer.RegisteredDateCreated,
                     telephone = customerCompleInfo.Telephone,
                     customerTypeId = customerCompleInfo.CustomerTypeId,
                     email = customerCompleInfo.Email,
                     birthdate = customerCompleInfo.Birthdate,
                     civilStatusId = customerCompleInfo.CivilStatusId,
                     placeOfBirth = customerCompleInfo.PlaceOfBirth,
                     nationality = customerCompleInfo.Nationality,
                     taxIdentificationNumber = customerCompleInfo.TaxIdentificationNumber,
                     lotHouseNumberAndStreet = customerCompleInfo.LotHouseNumberAndStreet,
                     barangay = customerCompleInfo.Barangay,
                     cityMunicipality = customerCompleInfo.CityMunicipality,
                     province = customerCompleInfo.Province,
                     country = customerCompleInfo.Country,
                     zipCode = customerCompleInfo.ZipCode
                 };

             var info = details.ToList();


             return View(info);*/

        }



        public ActionResult New()
        {
            var customersTypes = _context.CustomerTypes.ToList();
            var civilstatus = _context.CivilStatus.ToList();
            var sex = _context.Sex.ToList();
            /*var customerCompleInfo = new CustomerCompleInfos();*/

            var viewModels = new CustomerViewModel
            {
                CustomerTypes = customersTypes,
                CivilStatuses = civilstatus,
                Sexs = sex,
               /* CustomerCompleInfo = customerCompleInfo*/
            };
            

            return View(viewModels);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer,CustomerCompleInfo customerCompleInfo)
        {
            var isCustomerExist =
                _context.Customers.Count(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName);
            if (customer.Id == 0)
            {
                if (isCustomerExist != 0)
                {
                    TempData["notice"] = "Successfully registered";
                    return RedirectToAction("New");
                }
                else
                {
                    
                
                customer.RegisteredDateCreated = DateTime.Now;
                _context.Customers.Add(customer);

                if (customerCompleInfo.CivilStatusId !=0 && customerCompleInfo.Id ==0)
                {
                     customerCompleInfo.CustomerId = customer.Id;
                    _context.CustomerCompleInfos.Add(customerCompleInfo);
                }
                }
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.MiddleName = customer.MiddleName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Mobile = customer.Mobile;
                customerInDb.Sexid = customer.Sexid;
                customerInDb.NameExtension = customer.NameExtension;

                var customerCompleteInfo = _context.CustomerCompleInfos.Single(i => i.CustomerId == customer.Id);
                customerCompleteInfo.Telephone = customerCompleInfo.Telephone;
                customerCompleteInfo.Email = customerCompleInfo.Email;
                customerCompleteInfo.Birthdate = customerCompleInfo.Birthdate;
                customerCompleteInfo.CivilStatusId = customerCompleInfo.CivilStatusId;
                customerCompleteInfo.PlaceOfBirth = customerCompleInfo.PlaceOfBirth;
                customerCompleteInfo.Nationality = customerCompleInfo.Nationality;
                customerCompleteInfo.TaxIdentificationNumber = customerCompleInfo.TaxIdentificationNumber;
                customerCompleteInfo.CivilStatusId = customerCompleInfo.CustomerTypeId;
                customerCompleteInfo.LotHouseNumberAndStreet = customerCompleInfo.LotHouseNumberAndStreet;
                customerCompleteInfo.Barangay = customerCompleInfo.Barangay;
                customerCompleteInfo.CityMunicipality= customerCompleInfo.CityMunicipality;
                customerCompleteInfo.Province = customerCompleInfo.Province;
                customerCompleteInfo.Country = customerCompleInfo.Country;
                customerCompleteInfo.ZipCode = customerCompleInfo.ZipCode;

            }


            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
                


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customerCompleteInfo = _context.CustomerCompleInfos.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = new CustomerViewModel
            { 

                Customer = customer,
                CustomerCompleInfo = customerCompleteInfo,
                CustomerTypes =  _context.CustomerTypes.ToList(),
                CivilStatuses = _context.CivilStatus.ToList(),
                Sexs = _context.Sex.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var customerCompleteInfo = _context.CustomerCompleInfos.Single(c => c.CustomerId == id);

            if (customer.Id != 0)
                _context.Customers.Remove(customer);
            _context.CustomerCompleInfos.Remove(customerCompleteInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customerInfo = _context.CustomerCompleInfos.SingleOrDefault(ci => ci.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customerComplete = new CustomerViewModel
            { 
                Customer = customer,
                CustomerCompleInfo = customerInfo,
                CustomerTypes = _context.CustomerTypes.ToList(),
                CivilStatuses = _context.CivilStatus.ToList()
            };


            return PartialView(customerComplete);
        }

        /* public ActionResult OderByCustomer()
         {
             var oder = from c in _context.Customers
                 orderby c.NameExtension ascending
                 select c;

             return View(oder.ToList());

         }*/
        public ActionResult CustomerView(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customerInfo = _context.CustomerCompleInfos.SingleOrDefault(ci => ci.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var customerComplete = new CustomerViewModel
            {
                Customer = customer,
                CustomerCompleInfo = customerInfo,
                CustomerTypes = _context.CustomerTypes.ToList(),
                CivilStatuses = _context.CivilStatus.ToList()
            };
            return View(customerComplete);
        }


        public ActionResult CustomerReg()
        {
            
            var viewModel = new CustomerViewModel
            {
                Sexs = _context.Sex.ToList(),
                
            };
            return View(viewModel);
        }

        public ActionResult CustomerReg(Customer customer,CustomerCompleInfo customerCompleInfo)
        {

            var isCustomerExist =
                 _context.Customers.Count(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName);
            if (customer.Id == 0)
            {
                if (isCustomerExist != 0)
                {
                    TempData["notice"] = "Successfully registered";
                    return RedirectToAction("New");
                }
                else
                {
                    
                    customer.RegisteredDateCreated = DateTime.Now;
                    _context.Customers.Add(customer);

                    if (customerCompleInfo.Id == 0)
                    {
                        customerCompleInfo.CustomerId = customer.Id;
                        _context.CustomerCompleInfos.Add(customerCompleInfo);
                    }
                }
            }

            _context.SaveChanges();
          

            return View();
        }
    }
}