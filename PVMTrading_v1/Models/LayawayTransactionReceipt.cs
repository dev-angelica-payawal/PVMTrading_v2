﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class LayAwayTransactionReceipt
    {
        [Key]
        public int Id { get; set; }

        public LayAwayTransaction LayAwayTransaction { get; set; }
        [Required]
        public string LayAwayTransactionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM:dd:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime DateTransaction { get; set; }

        public double AmountPaid { get; set; }

        /*public int EmployeeId { get; set; }*/
        [Range(0, int.MaxValue, ErrorMessage = "Does not accept negative")]
        [Required]
        public int OR { get; set; }

    }
}