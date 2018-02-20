using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class ProductPriceViewModel
    {
        public ProductPrice ProductPrices { get; set; }
        public Product Products { get; set; }
    }
}