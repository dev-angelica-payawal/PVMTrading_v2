using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class CashTransactionViewModel
    {
        public CashTransaction CashTransaction { get; set; }

        public CashTransactionItem CashTransactionItem { get; set; }

        public Product Product { get; set; }

        public List<Customer> Customer { get; set; }
        public ProductPrice ProductPrice { get; set; }

      
      


    }
}