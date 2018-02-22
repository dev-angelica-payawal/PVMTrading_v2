using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Foolproof;


namespace PVMTrading_v1.Models
{
    public class CashTransaction
    {
      
        public string Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should not be negative")]
        [LessThanOrEqualTo("OriginalTotalAmount", ErrorMessage = "Value should Less Than or Equal To Total Amount")]
        [Display(Name = "Total Discount Amount")]
        public double TotalDiscountedAmount { get; set; }

        [Display(Name = "Total Original Amount")]
        [GreaterThanOrEqualTo("TotalDiscountedAmount", ErrorMessage = "Value should Less Than or Equal To Total Amount")]
        public double OriginalTotalAmount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM:dd:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime CashTransactionDate { get; set; }

        [Display(Name = "Total Amount")]
        //[DisplayFormat(DataFormatString = "{0:#.####}", ApplyFormatInEditMode = true)]
        [Range(0, double.MaxValue, ErrorMessage = "Discount Value ")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public double TotalAmount { get; set; }

    //    public int EmployeeId { get; set; }

        public Customer Customer { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "Void Transaction")]
        public bool IsVoid { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        //     public int? DeliveryChargedId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Does not accept negative")]
        public int OR { get; set; }
    }
}