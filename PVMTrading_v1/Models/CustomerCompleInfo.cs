using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class CustomerCompleInfo
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }


        [DataType(DataType.PhoneNumber)]
        public int? Telephone { get; set; }


        public CustomerType CustomerType { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM:dd:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }

        public CivilStatus CivilStatus { get; set; }
        [Required]
        [Display(Name = "Civil Satus")]
        public int CivilStatusId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Tax Identification Number")]
        public int? TaxIdentificationNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Lot/House Number/Street")]
        public string LotHouseNumberAndStreet { get; set; }

        [Required]
        [StringLength(255)]
        public string Barangay { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City/Municipality")]
        public string CityMunicipality { get; set; }

        [Required]
        [StringLength(255)]
        public string Province { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Display(Name = "Zip Code")]
        public int? ZipCode { get; set; }

     
        public string Image { get; set; }

        
    }
}