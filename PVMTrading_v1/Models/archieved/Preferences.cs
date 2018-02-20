using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models.archieved
{
    public class Preferences
    {
        public int Id { get; set; }
        public int BufferStockPercentage { get; set; }
        public int InterestRate { get; set; }
        public int PenaltyRate { get; set; }
    }
}