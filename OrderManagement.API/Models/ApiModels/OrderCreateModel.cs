using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class OrderCreateModel
    {
        public OrderCreateModel()
        {
            OrderDetails = new HashSet<OrderDetailCreateModel>();
        }

        public string Address { get; set; }

        public virtual ICollection<OrderDetailCreateModel> OrderDetails { get; set; }
    }
}