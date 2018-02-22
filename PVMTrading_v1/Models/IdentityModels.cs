using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PVMTrading_v1.Models.archieved;

namespace PVMTrading_v1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {
                public Branch Branch { get; set; }
                [Display(Name = "Branch Name"),Required]
                public int BranchId { get; set; }

        /*        public ApplicationUser = new SelectList(

                    Produc)*/


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ProductCondition> ProductConditions { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<BrandType> BrandTypes { get; set; }
        public DbSet<ProductInclusion> ProductInclusions { get; set; }
        public DbSet<CivilStatus> CivilStatus { get; set; }


      
        public DbSet<LoanStatus> LoanStatus { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayment { get; set; }
        public DbSet<Sex> Sex { get; set; }

        /*internal static IEnumerable<Customer> SqlQuery<T>(string query)
        {
            throw new NotImplementedException();
        }*/

        public DbSet<Warranty> Warranty { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerCompleInfo> CustomerCompleInfos { get; set; }


        public DbSet<CashTransaction> CashTransactions { get; set; }
        public DbSet<CashTransactionItem> CashTransactionItems { get; set; }

        public DbSet<TempCart> TempCarts { get; set; }

        public DbSet<LayAwayTransaction> LayAwayTransactions { get; set; }



        public ApplicationDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


       
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PVMTrading_v1.Models.archieved.ProductReturnReason> ProductReturnReasons { get; set; }

      
    }

    



}