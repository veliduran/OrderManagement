using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.API.Models
{
    public class ProductApiModel
    {
        public int Id { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}