using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.TransferModels
{
    public class OrderTransferModel
    {
        public OrderTransferModel()
        {
            OrderDetails = new HashSet<OrderDetailTransferModel>();
        }
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Address { get; set; }

        public CustomerTransferModel Customer { get; set; }

        public virtual ICollection<OrderDetailTransferModel> OrderDetails { get; set; }
    }
}
