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
        public string ID { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressRefID { get; set; }
        public Address Address { get; set; }


        [ForeignKey("Pickups")]
        [Display(Name = "Pickup Day")]
        public int PickupRefID { get; set; }
        public Pickups Pickups { get; set; }


        // public IEnumerable<Pickups> PickupDay { get; set; }
        // public List<Days> PickupDays { get; set; }
    }
}