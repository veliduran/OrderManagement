using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DataAccess.Entities
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int Id { get; set; }
        
        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
