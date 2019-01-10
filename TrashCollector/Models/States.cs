using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class States
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "State Name")]
        public string State { get; set; }


        [Display(Name = "State Abbrivation")]
        public string StateAbbrivation { get; set; }
    }
}