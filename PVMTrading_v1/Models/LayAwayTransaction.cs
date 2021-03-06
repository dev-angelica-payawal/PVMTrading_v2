﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class LayAwayTransaction
    {
        public string Id { get; set; }
       
        [Display(Name = "Total Paid Amount")]
        public double TotalPaidAmount { get; set; }

        [Display(Name = "Remaining Balance")]
        public double RemainingBalance { get; set; }


        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        //  public int EmployeeId { get; set; }

        public Customer Customer { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public int ProductId { get; set; }


        [Display(Name = "Void Transaction")]
        public bool IsVoid { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public int Quantity { get; set; }


    }
}