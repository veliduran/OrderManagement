using AutoMapper;
using OrderManagement.Business.TransferModels;
using OrderManagement.Business.UnitOfWorks;
using OrderManagement.DataAccess.Entities;
using System.Collections.Generic;

namespace OrderManagement.Business.LogicClasses
{
    public class CustomerLogic
    {
        public CustomerTransferModel GetCustomer(int Id)
        {
            CustomerTransferModel model = new CustomerTransferModel();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                var entity = uow.CustomerRepository.FindById(Id);
                model = Mapper.Map<CustomerTransferModel>(entity);
            }
            return model;
        }

        public List<CustomerTransferModel> GetCustomers()
        {

            List<CustomerTransferModel> model = new List<CustomerTransferModel>();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                var list = uow.CustomerRepository.Select();
                model = Mapper.Map<List<CustomerTransferModel>>(list);
            }
            return model;
        }

        public void CreateCustomer(CustomerTransferModel model)
        {
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.CustomerRepository.Insert(Mapper.Map<Customer>(model));
            }
            
        }
        public void UpdateCustomer(CustomerTransferModel model)
        {
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                uow.CustomerRepository.Update(Mapper.Map<Customer>(model));
            }
        }    
            
        
    }
}
