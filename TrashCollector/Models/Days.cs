using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Days
    {
        [Key]
        public int ID { get; set; }
        [Display (Name = "Day")]
        public string Day { get; set; }
        public bool IsWeekDay { get; set; }
    }
}