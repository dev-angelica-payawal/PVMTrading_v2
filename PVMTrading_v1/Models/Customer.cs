using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PVMTrading_v1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(255)]
        [Display(Name = "Name Extension")]
        public string NameExtension { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public int Mobile { get; set; }
       

        public Sex Sex { get; set; }
        [Display(Name = "Sex")]
        public int Sexid { get; set; }

        [Column(TypeName = "DateTime2")]
        [Display(Name = "Registered Date Created")]
        public DateTime RegisteredDateCreated { get; set; }

        /*public int Count { get; set; }*/
    }
}