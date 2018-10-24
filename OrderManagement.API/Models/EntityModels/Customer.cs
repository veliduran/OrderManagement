using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}