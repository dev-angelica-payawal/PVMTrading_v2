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
    public class LoanTransactionController : Controller
    {
        private ApplicationDbContext _context;

        public LoanTransactionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: LoanTransaction
        public ActionResult Index()
        {
            
            var loantransact = _context.Loans.Include(c => c.Customer).ToList();
            var loanstatus = _context.LoanStatus.Count().Equals("Approved");

        }
    }
}