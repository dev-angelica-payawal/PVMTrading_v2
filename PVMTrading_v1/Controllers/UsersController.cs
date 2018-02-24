using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVMTrading_v1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using PVMTrading_v1.ViewModels;


namespace PVMTrading_v1.Controllers
{


    public class UsersController : Controller
    {
       
        private ApplicationDbContext context;

        public UsersController(ApplicationDbContext application)
        {

            context = application;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Users
        [CustomAuthorize(Roles = "Admin,Cashier,Sales Clerk")]

        public ActionResult Index()
        {

            var users = context.Users.ToList();


            return View(users);
        }
        
    }
}