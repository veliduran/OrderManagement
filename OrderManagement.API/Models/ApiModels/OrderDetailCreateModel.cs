using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class OrderDetailCreateModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}