using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace WebApplication5.Models
{
    public class Instagram
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName( "Enter Your Name")]
        public string uname { get; set; }
    
        [Required(ErrorMessage = "*")]
        [DisplayName("Enter Your Email")]
        [DataType(DataType.EmailAddress , ErrorMessage ="Invalid Email......")]
        public string uemail { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Enter Password")]
        public string upass { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "*")]
        [DisplayName("Enter Confirm Password")]
        [Compare("upass", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ucpass { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Gender")]
        public string ugender { get; set; }

        [Required(ErrorMessage ="*")]
        [DataType(DataType.Date,ErrorMessage ="Valid date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Date Of Birth")]
        public string udob { get; set; }
        
    }
}