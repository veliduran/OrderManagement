using AutoMapper;
using OrderManagement.API.Models;
using OrderManagement.Business.LogicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.API.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductLogic _productLogic;
        public ProductsController()
        {
            _productLogic = new ProductLogic();
        }

        [Route("~/api/products")]
        public IHttpActionResult Get()
        {
            try
            {
                return Json(Mapper.Map<List<ProductApiModel>>(_productLogic.GetAllProducts()));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [Route("~/api/products/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Json(Mapper.Map<ProductApiModel>(_productLogic.GetProduct(id)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
