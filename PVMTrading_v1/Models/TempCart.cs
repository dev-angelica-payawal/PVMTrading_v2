using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PVMTrading_v1.Models
{
    public class TempCart
    {
        [Key]
        public int Id { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }

        public double Discount { get; set; }
    }

    
}