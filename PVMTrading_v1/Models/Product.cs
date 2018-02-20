using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace PVMTrading_v1.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Input the Name of the Product.")]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the Serial Number of the Product.")]
        public int? SerialNumber { get; set; }

        [Required(ErrorMessage = "Input the Model of the Product.")]
        [MaxLength(255)]
        public string Model { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsReturned { get; set; }

        [Required(ErrorMessage = "Input the Price of the Product.")]
        [DataType(DataType.Currency)]
        public double OriginalPrice { get; set; }
        

        public Warranty Warranty { get; set; }
        [Required(ErrorMessage = "Please Input the Warranty of the Product")]
        [Display(Name = "Warranty")]
        public int WarrantyId { get; set; }
      

        public Brand Brand { get; set; }
        [Required(ErrorMessage = "Choose the Brand Name.")]
        public int BrandId { get; set; }
        
        public ProductCategory ProductCategory { get; set; }
        [Required(ErrorMessage = "Choose the Category of the Product.")]
        public int ProductCategoryId { get; set; }

        public ProductCondition ProductCondition { get; set; }
        [Required(ErrorMessage = "Choose the Condition of the Product.")]
        public int ProductConditionId { get; set; }

        public Branch Branch { get; set; }
        [Required(ErrorMessage = "Choose the Brach Name of the Product.")]
        public int BranchId { get; set; }

        [Required]
        public int Quantity { get; set; }
       

        [Required]
        public int Reserved { get; set; }

        [Required]
        [Display(Name = "Available For Selling")]
        public int AvailableForSelling { get; set; }

        
        public byte[] ProductImage { get; set; }


       // public PvMCart Cart { get; set; }
        //   public int LastChangeByEmployeeId { get; set; }
        //   public int CreatedByEmployeeId { get; set; }


    }
}