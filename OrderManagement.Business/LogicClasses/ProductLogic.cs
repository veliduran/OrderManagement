using AutoMapper;
using OrderManagement.Business.TransferModels;
using OrderManagement.Business.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.LogicClasses
{
    public class ProductLogic
    {
        public ProductTransferModel GetProduct(int Id)
        {
            ProductTransferModel model = new ProductTransferModel();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                var entity = uow.ProductRepository.FindById(Id);
                model = Mapper.Map<ProductTransferModel>(entity);
            }
            return model;
        }

        public List<ProductTransferModel> GetAllProducts()
        {
            List<ProductTransferModel> products = new List<ProductTransferModel>();
            using (OrderManagementUnitOfWork uow = new OrderManagementUnitOfWork())
            {
                products = Mapper.Map<List<ProductTransferModel>>(uow.ProductRepository.Select());
            }
            return products;
        }
    }
}
