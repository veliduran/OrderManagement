using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.TransferModels
{
    public class ProductTransferModel
    {
        public ProductTransferModel()
        {
            OrderDetails = new HashSet<OrderDetailTransferModel>();
        }
        public int Id { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrderDetailTransferModel> OrderDetails { get; set; }
    }
}
