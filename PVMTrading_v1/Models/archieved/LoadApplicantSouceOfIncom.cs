using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models.archieved
{
    public class LoadApplicantSouceOfIncom
    {
        public int Id { get; set; }
        public int LoadApplicantId { get; set; }
        public string Occupation { get; set; }
        public string PositionTitle { get; set; }
        public string EmplopyerName { get; set; }
        public string EmployerAddress { get; set; }
        public int PhoneNumber { get; set; }
        public double MonthlyIncome { get; set; }

    }
}