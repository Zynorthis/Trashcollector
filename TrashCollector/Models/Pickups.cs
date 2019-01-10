using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickups
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set; }


        [Display(Name = "Completion Status")]
        public bool IsCompleted { get; set; }


        [Display(Name = "Completion Date")]
        public string CompletionDate { get; set; }
    }
}