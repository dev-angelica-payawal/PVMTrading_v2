using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models.archieved
{
    public class Delivery
    {

        public int Id { get; set; }
        public int DeliveryIncharge { get; set; }
        public int CashTransactionId { get; set; }
        public int DeliveryStatusId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public DateTime AccomplishDateOfDelivery { get; set; }
        public string Remarks { get; set; }
    }
}