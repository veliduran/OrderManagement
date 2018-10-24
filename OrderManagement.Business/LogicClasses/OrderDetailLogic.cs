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
    public class OrderDetailLogic
    {
        public OrderDetailTransferModel GetOrderDetail(int Id)
        {
            OrderDetailTransferModel model = new OrderDetailTransferModel();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                model = Mapper.Map<OrderDetailTransferModel>(uow.OrderDetailRepository.FindById(Id));
            }
            return model;
        }

        public List<OrderDetailTransferModel> GetOrderDetails(int orderId)
        {
            List<OrderDetailTransferModel> models = new List<OrderDetailTransferModel>();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                models = Mapper.Map<List<OrderDetailTransferModel>>(uow.OrderDetailRepository.Select(x=>x.OrderId==orderId));
            }
            return models;
        }

        public void AdOrderDetail(OrderDetailTransferModel model)
        {
            OrderDetail detail = Mapper.Map<OrderDetail>(model);
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderDetailRepository.Insert(detail);
            }

        }

        public void UpdateOrderDetail(OrderDetailTransferModel model)
        {
            OrderDetail detail = Mapper.Map<OrderDetail>(model);
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderDetailRepository.Update(detail);
            }
        }

        public void DeleteOrderDetail(int id)
        {
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.OrderDetailRepository.Delete(id);
            }
        }
    }
}
