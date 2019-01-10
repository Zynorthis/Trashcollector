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


        [Display(Name = "Address Line 1")]
        public int Address1 { get; set; }


        [Display(Name = "Address Line 2")]
        public int Address2 { get; set; }


        [Display(Name = "Zip Code")]
        public int Zipcode { get; set; }


        [ForeignKey("States")]
        [Display(Name = "State")]
        public int StateRefID { get; set; }
        public States States { get; set; }
    }
}