using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [ForeignKey("AspUser")]
        public string AspNetUserID { get; set; }
        public ApplicationUser AspUser { get; set; }

        // public IEnumerable<Pickups> PickupDay { get; set; }
        // public List<Days> PickupDays { get; set; }
    }
}