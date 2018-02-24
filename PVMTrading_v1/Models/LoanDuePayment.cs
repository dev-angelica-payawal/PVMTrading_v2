using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class LoanDuePayment
    {
        public int Id { get; set; }

        public Loan Loan { get; set; }
        public string LoanId { get; set; }

        public DateTime DueDateTime { get; set; }

        public bool IsPaid { get; set; }

        public double PenaltyAmount { get; set; }

        public double TotalAmountDue { get; set; }

        public int OR { get; set; }


        /*public int EmployeeId { get; set; }
        public int CollectorId { get; set; }*/

    }
}