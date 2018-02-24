using System;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace PVMTrading_v1.Models
{
    public class Loan
    {
        public string Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should not be negative")]
        [LessThanOrEqualTo("LoanAmount", ErrorMessage = "Value should Less Than or Equal To Loan Amount")]
        [Required]
        [Display(Name = "Down Payment")]
        public double Downpayment { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should not be negative")]
        [GreaterThanOrEqualTo("Downpayment", ErrorMessage = "Value should greater Than or Equal To Downpayment")]
        [Required]
        [Display(Name = "Down Payment")]
        public double LoanAmount { get; set; }

        public ModeOfPayment ModeOfPayment { get; set; }
        public int ModeOfPaymentId { get; set; }


        [Range(0, 20, ErrorMessage = "Value should not be negative")]
        [Required]
        public int Terms { get; set; }

        [Required]
        public double InterestRate { get; set; }

        public double DuePayment { get; set; }

        public double LoanTotalPayment { get; set; }

        public LoanStatus LoanStatus { get; set; }
        [Display(Name = "Loan Status")]
        [Required]
        public int LoanStatusId { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }


        public Customer Customer { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public int CustomerId { get; set; }
        //     public int CreditInvestigatorId { get; set; }

   //     public int CreditInvestigatorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM:dd:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime LoanDateCreated { get; set; }


       // public int ApprovingEmployee { get; set; }

        //public int DeliveryChargeId { get; set; }




/*
        public bool WithBrgyClearance { get; set; }
        public bool WithValidId { get; set; }
        public bool WithPaySlip { get; set; }
        public bool WithCertificateOfEmployment { get; set; }
*/


    }
}