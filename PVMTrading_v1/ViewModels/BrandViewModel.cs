using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class BrandViewModel
    {
        public List<BrandType> BrandTypes { get; set; }
        public Brand Brand { get; set; }
    }
}