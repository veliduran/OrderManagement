using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.TransferModels
{
    public class CustomerTransferModel
    {
        public CustomerTransferModel()
        {
            Orders = new HashSet<OrderTransferModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OrderTransferModel> Orders { get; set; }
    }
}
