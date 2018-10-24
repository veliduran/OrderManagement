using AutoMapper;
using Newtonsoft.Json;
using OrderManagement.API.Models;
using OrderManagement.Business.LogicClasses;
using OrderManagement.Business.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.API.Controllers
{
    public class OrdersController : ApiController
    {
        private OrderLogic _orderLogic;
        private CustomerLogic _customerLogic;
        private ProductLogic _productLogic;
        public OrdersController()
        {
            _orderLogic = new OrderLogic();
            _customerLogic = new CustomerLogic();
            _productLogic = new ProductLogic();
        }
        [HttpGet]
        [Route("~/api/customers/{customerid}/orders/{id}")]
        public IHttpActionResult GetCustomerOrderById(int customerid, int id)
        {
            Order order = Mapper.Map<Order>(_orderLogic.GetCustomerOrder(id));
            var value = JsonConvert.SerializeObject(order);
            Customer customer = Mapper.Map<Customer>(_customerLogic.GetCustomer(customerid));
            CustomerOrder customerOrder = new CustomerOrder();
            if (order == null || customer == null)
                return Content(HttpStatusCode.NotFound,"Content Not Found");

            customerOrder.CustomerId = customer.Id;
            customerOrder.Name = customer.Name;
            customerOrder.Address = order.Address;
            foreach (OrderDetail item in order.OrderDetails)
            {
                Product product = Mapper.Map<Product>(_productLogic.GetProduct(item.ProductId));
                if (product != null)
                {
                    OrderProduct ordProduct = new OrderProduct();
                    ordProduct.Barcode = product.Barcode;
                    ordProduct.Description = product.Description;
                    ordProduct.ProductId = product.Id;
                    ordProduct.OrderId = item.OrderId;
                    ordProduct.Price = product.Price;
                    ordProduct.Quantity = item.Quantity;
                    customerOrder.OrderProducts.Add(ordProduct);
                }
            }
            return Json(customerOrder);

        }

        [HttpGet]
        [Route("~/api/customers/{id}/orders")]
        public IHttpActionResult GetCustomerOrders(int id)
        {
            Customer customer = Mapper.Map<Customer>(_customerLogic.GetCustomer(id));
            List<Order> orders = Mapper.Map<List<Order>>(_orderLogic.GetOrders(id));
            if (orders==null || customer==null)
                return Content(HttpStatusCode.NotFound, "Content Not Found");

            List<CustomerOrder> cusOrders = new List<CustomerOrder>();
            
            foreach (Order item in orders)
            {
                CustomerOrder cusOrder = new CustomerOrder();
                cusOrder.CustomerId = customer.Id;
                cusOrder.Name = customer.Name;
                cusOrder.Address = item.Address;
                foreach (OrderDetail orderDetail in item.OrderDetails)
                {
                    Product product = Mapper.Map<Product>(_productLogic.GetProduct(orderDetail.ProductId));
                    if (product != null)
                    {
                        OrderProduct ordProduct = new OrderProduct();
                        ordProduct.Barcode = product.Barcode;
                        ordProduct.Description = product.Description;
                        ordProduct.ProductId = product.Id;
                        ordProduct.OrderId = orderDetail.OrderId;
                        ordProduct.Price = product.Price;
                        ordProduct.Quantity = orderDetail.Quantity;
                        cusOrder.OrderProducts.Add(ordProduct);
                    }
                }
                cusOrders.Add(cusOrder);
            }

            return Json(cusOrders);
        }
        [HttpPost]
        [Route("~/api/customers/{id}/orders")]
        public IHttpActionResult Post(int id,[FromBody]OrderCreateModel model)
        {
            try
            {
                OrderTransferModel orderModel = new OrderTransferModel();
                orderModel.Address = model.Address;
                orderModel.CustomerId = id;
                foreach (var item in model.OrderDetails)
                {
                    OrderDetailTransferModel transModel = new OrderDetailTransferModel();
                    transModel.ProductId = item.ProductId;
                    transModel.Quantity = item.Quantity;
                    orderModel.OrderDetails.Add(transModel);
                }
                _orderLogic.CreateOrder(orderModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("~/api/orders/{id}")]
        public IHttpActionResult Put(int id, [FromBody]OrderAddressUpdateModel model)
        {
            try
            {
                Order order = Mapper.Map<Order>(_orderLogic.GetCustomerOrder(id));
                if (order == null)
                    return Content(HttpStatusCode.NoContent, "There isn't any Order with id=" + id);

                order.Address = model.Address;
                _orderLogic.UpdateOrderAddress(Mapper.Map<OrderTransferModel>(order));
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/orders/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Order order = Mapper.Map<Order>(_orderLogic.GetCustomerOrder(id));
                if (order==null)
                    return Content(HttpStatusCode.NoContent, "Order not exist with id=" + id);

                _orderLogic.DeleteOrder(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
