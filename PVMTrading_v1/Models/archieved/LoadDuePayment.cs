using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models.archieved
{
    public class LoadDuePayment
    {
        public int Id { get; set; }
        public int LoadId { get; set; }
        public DateTime DueDateTime { get; set; }
        public bool IsPaid { get; set; }
        public double PenaltyAmount { get; set; }
        public double TotalAmountDue { get; set; }
        public int EmployeeId { get; set; }
        public int CollectorId { get; set; }
        public string Remarks { get; set; }

    }
}