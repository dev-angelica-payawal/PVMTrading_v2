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


namespace PVMTrading_v1.Controllers
{


    public class UsersController : Controller
    {
       
        private ApplicationDbContext _application;

        public UsersController(ApplicationDbContext application)
        {

            _application = application;
        }

        protected override void Dispose(bool disposing)
        {
            _application.Dispose();
        }
        // GET: Users
        public ActionResult Index()
        {
            var userList = _application.Users.ToList();



            return View(userList);
        }
        
    }
}