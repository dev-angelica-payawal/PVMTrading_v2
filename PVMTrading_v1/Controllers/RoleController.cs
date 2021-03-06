﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PVMTrading_v1.Models;
using PVMTrading_v1.ViewModels;

namespace PVMTrading_v1.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;
        

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        [CustomAuthorize(Roles = "Admin,Cashier,Sales Clerk")]

        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();

            foreach (var role in RoleManager.Roles)
            {
                list.Add(new RoleViewModel(role));
                
            }
            return View(list);
        }

        [CustomAuthorize(Roles = "Admin,Cashier")]

        public ActionResult Create()
        {
            return View();
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() {Name = model.Name};
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() {Id = model.Id, Name = model.Name};
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "Admin,Cashier")]

        public async Task<ActionResult> Details(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [CustomAuthorize(Roles = "Admin")]

        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }
        [CustomAuthorize(Roles = "Admin")]

        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}