using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class UsersViewModel
    {
        public ApplicationUser Users { get; set; }
        public List<string> Roles { get; set; }
    }
}