using AutoMapper;
using OrderManagement.API.Models;
using OrderManagement.Business.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OrderManagement.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(m =>
            {
                m.CreateMap<Customer, CustomerTransferModel>();
                m.CreateMap<Product, ProductTransferModel>();
                m.CreateMap<Order, OrderTransferModel>();
                m.CreateMap<OrderDetail, OrderDetailTransferModel>();
            });
        }
    }
}
