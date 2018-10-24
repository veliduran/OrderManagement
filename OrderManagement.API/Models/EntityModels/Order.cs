using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Address { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}