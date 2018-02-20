using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        public BrandType BrandType { get; set; }
        [Display(Name = "Brand Type")]
        public int BrandTypeId { get; set; }

    }
}