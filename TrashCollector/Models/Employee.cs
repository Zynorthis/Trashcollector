﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public string ID { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Zip Code")]
        public int Zipcode { get; set; }
    }
}