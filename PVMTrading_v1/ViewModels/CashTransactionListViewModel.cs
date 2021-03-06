﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class CashTransactionListViewModel
    {
        public CashTransaction CashTransaction { get; set; }
        public CashTransactionItem CashTransactionItem { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}