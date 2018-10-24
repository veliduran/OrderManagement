using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.TransferModels
{
    public class OrderDetailTransferModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public virtual ProductTransferModel Product { get; set; }

        public virtual OrderTransferModel Order { get; set; }
    }
}
