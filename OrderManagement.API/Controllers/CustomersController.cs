using AutoMapper;
using Microsoft.Ajax.Utilities;
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
    public class CustomersController : ApiController
    {
        private CustomerLogic _customerLogic;
        public CustomersController()
        {
            _customerLogic = new CustomerLogic();
        }

        // GET: api/Customers
        [HttpGet]
        [Route("~/api/customers")]
        public IHttpActionResult Get()
        {
            List<Customer> customers = Mapper.Map<List<Customer>>(_customerLogic.GetCustomers());
            if (customers == null)
                return Content(HttpStatusCode.NoContent, "");

            return Ok(customers.Select(x=> new {Id=x.Id,Name=x.Name}));
        }

        // GET: api/Customers/5
        [HttpGet]
        [Route("~/api/customers/{id}")]
        public IHttpActionResult Get(int id)
        {
            Customer model = Mapper.Map<Customer>(_customerLogic.GetCustomer(id));
            if (model==null)
                return Content(HttpStatusCode.NoContent,"");

            return Ok(new { Id=model.Id,Name=model.Name});
        }
    }
}
