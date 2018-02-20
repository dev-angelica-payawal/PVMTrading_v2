using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class CartViewModel
    {
 /*       [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }*/
        [Key]
        public List<TempCart> CartItems { get; set; }
        public decimal CartTotal { get; set; }



    }

  
}