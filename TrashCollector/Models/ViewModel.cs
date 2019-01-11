using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class ViewModel
    {
        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Pickups Pickups { get; set; }
        public States States { get; set; }

        public List<Address> AddressList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Pickups> PickupsList { get; set; }
        public List<States> StatesList { get; set; }
    }
}