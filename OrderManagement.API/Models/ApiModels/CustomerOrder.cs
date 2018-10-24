using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderProducts = new List<OrderProduct>();
        }
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<OrderProduct> OrderProducts {get;set;} 
    }
}