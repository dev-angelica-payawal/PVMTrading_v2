using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class LoanViewModel
    {
        public Loan Loan { get; set; }
        public List<ModeOfPayment> ModeOfPayment { get; set; }
        public List<LoanStatus> LoanStatus { get; set; }
        public LoanDuePayment LoanDuePayment { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}