using AutoMapper;
using OrderManagement.Business.TransferModels;
using OrderManagement.Business.UnitOfWorks;
using OrderManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.LogicClasses
{
    public class OrderLogic
    {
        public List<OrderTransferModel> GetOrders(int Id)
        {
            List<OrderTransferModel> model = new List<OrderTransferModel>();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                var entities = uow.OrderRepository.Select(x => x.CustomerId == Id);
                if (entities != null)
                    model = Mapper.Map<List<OrderTransferModel>>(entities);
            }
            return model;
        }

        public OrderTransferModel GetCustomerOrder(int Id)
        {
            OrderTransferModel model = new OrderTransferModel();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                var entity = uow.OrderRepository.FindById(Id);
                model = Mapper.Map<OrderTransferModel>(entity);

            }
            return model;
        }

        public void CreateOrder(OrderTransferModel model)
        {

            Order order = Mapper.Map<Order>(model);
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderRepository.Insert(order);
            }
        }

        public void UpdateOrderAddress(OrderTransferModel model)
        {
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderRepository.Update(Mapper.Map<Order>(model));
            }
        }

        public void DeleteOrder(int id)
        {
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderRepository.Delete(id);
            }

        }
    }
}
