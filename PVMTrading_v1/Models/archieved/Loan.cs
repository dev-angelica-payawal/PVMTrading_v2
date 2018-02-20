using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int LoadAppplicantId { get; set; }
        public double Downpayment { get; set; }
        public double LoanAmount { get; set; }
        public int ModeOfPaymentId { get; set; }
        public int Terms { get; set; }
        public int InterestRate { get; set; }
        public double DuePayment { get; set; }
        public double LoadTotalPayment { get; set; }
        public int LoadStatusId { get; set; }
        public string Remarks { get; set; }
        public int CreditInvestigatorId { get; set; }
        public DateTime LoanDateCreated { get; set; }
        public int ApprovingEmployee { get; set; }
        public DateTime DateProductTaken { get; set; }
        public bool WithBrgyClearance { get; set; }
        public bool WithValidId { get; set; }
        public bool WithPaySlip { get; set; }
        public bool WithCertificateOfEmployment { get; set; }
        public int DeliveryChargeId { get; set; }


    }
}