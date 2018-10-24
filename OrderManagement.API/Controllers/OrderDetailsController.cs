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
    public class OrderDetailsController : ApiController
    {
        OrderDetailLogic _orderDetailLogic;
        OrderLogic _orderLogic;
        ProductLogic _productLogic;
        public OrderDetailsController()
        {
            _orderDetailLogic = new OrderDetailLogic();
            _orderLogic = new OrderLogic();
            _productLogic = new ProductLogic();
        }
        [HttpGet]
        [Route("~/api/orders/{orderid}/orderdetails")]
        public IHttpActionResult Get(int orderid)
        {
            try
            {
                List<OrderDetail> orderDetails = Mapper.Map<List<OrderDetail>>(_orderDetailLogic.GetOrderDetails(orderid));

                return Json(orderDetails);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpGet]
        [Route("~/api/orders/{orderid}/orderdetails/{id}")]
        public IHttpActionResult GetOrderDetail(int orderid,int id)
        {
            try
            {
                OrderDetail orderDetail = Mapper.Map<OrderDetail>(_orderDetailLogic.GetOrderDetail(id));
                return Json(orderDetail);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("~/api/orders/{id}/orderdetails")]
        public IHttpActionResult Post(int id,[FromBody]OrderDetailCreateModel model)
        {
            try
            {
                Order order = Mapper.Map<Order>(_orderLogic.GetCustomerOrder(id));
                if (order == null)
                { return Content(HttpStatusCode.NoContent, "The order with Id=" + id + " does not exist in the current contex"); }

                Product product = Mapper.Map<Product>(_productLogic.GetProduct(model.ProductId));
                if (product==null)
                { return Content(HttpStatusCode.NoContent, "The product with Id=" + model.ProductId + " does not exist in the current contex"); }

                
                OrderDetailTransferModel detail = new OrderDetailTransferModel { OrderId = id, ProductId = model.ProductId, Quantity = model.Quantity };
                _orderDetailLogic.AdOrderDetail(detail);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("~/api/orders/{orderid}/orderdetails/{id}")]
        public IHttpActionResult Put(int orderid,int id, [FromBody]OrderDetailUpdateModel model)
        {
            try
            {
                Order order = Mapper.Map<Order>(_orderLogic.GetCustomerOrder(orderid));
                if (order == null)
                    return Content(HttpStatusCode.NoContent, "Invalid Id for Order");


                OrderDetail orderDetail = Mapper.Map<OrderDetail>(_orderDetailLogic.GetOrderDetail(id));
                if (orderDetail == null)
                    return Content(HttpStatusCode.NoContent, "Invalid Id for Order Detail");

                orderDetail.Quantity = model.Quantity;
                _orderDetailLogic.UpdateOrderDetail(Mapper.Map<OrderDetailTransferModel>(orderDetail));

                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }
        [HttpDelete]
        [Route("~/api/orders/{orderid}/orderdetails/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                try
                {
                    if (_orderDetailLogic.GetOrderDetail(id) == null)
                        return Content(HttpStatusCode.NoContent, "The order detail with id=" + id + " does not exist in current context");

                    _orderDetailLogic.DeleteOrderDetail(id);
                    return Ok();
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
