using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using PVMTrading_v1.Models;


namespace PVMTrading_v1.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<Warranty> Warranties { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<ProductCondition> ProductConditions { get; set; }
        public Product Product { get; set; }

        public ProductInclusion ProductInclusion { get; set; }
        public ProductPrice ProductPrice { get; set; }



        public string Title
        {
            get
            {
               if (Product !=null && Product.Id !=0)
                {
                    return "Edit Product";
                }

                return "New Product";
            }
        }



    }
}

