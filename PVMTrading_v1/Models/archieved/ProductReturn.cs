using System;

namespace PVMTrading_v1.Models.archieved
{
    public class ProductReturn
    {
        public int Id { get; set; }
        public int ProductReturnReasonId { get; set; }
        public string Action { get; set; }
        public int VerifiedByEmployeeId { get; set; }
        public int LoadId { get; set; }
        public int CashTransactionId { get; set; }
        public int ProductId { get; set; }
        public int ReturnConditionId { get; set; }
        public DateTime DateReturned { get; set; }
        public string ReturnDescription { get; set; }

    }
}