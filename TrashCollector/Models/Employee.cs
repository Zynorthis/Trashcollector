using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int Zipcode { get; set; }

        [ForeignKey("AspUser")]
        public string AspNetUserID { get; set; }
        public ApplicationUser AspUser { get; set; }
    }
}