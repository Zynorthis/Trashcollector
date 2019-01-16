using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }

        
        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int Zipcode { get; set; }

        [Required]
        [ForeignKey("State")]
        [Display(Name = "State")]
        public int StateRefID { get; set; }
        public States State { get; set; }

        [ForeignKey("Customer")]
        public int CustId { get; set; }
        public Customer Customer { get; set; }
    }
}