using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class ProductInclusion
    {

        public int Id { get; set; }

        public Product Product { get; set; }
        [Display(Name = "Product Name")]
        public int ProductId { get; set; }

        [Display(Name = "Free Item")]
        public string FreeItem { get; set; }

        [Display(Name = "Quantity of Free Item")]
        public int? Quantity { get; set; }

        //  public int CreatedByEmployeeId { get; set; }

        //        public int LastChangeByEmployeeId { get; set; }

    }
}