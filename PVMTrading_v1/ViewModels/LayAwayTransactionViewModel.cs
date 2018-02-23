using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class LayAwayTransactionViewModel
    {
        public Product Product { get; set; }
        public LayAwayTransaction LayAwayTransaction { get; set; }
        public Customer Customer { get; set; }
        public LayAwayTransactionReceipt LayAwayTransactionReceipt { get; set; }
    }
}