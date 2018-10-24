using OrderManagement.DataAccess.Entities;
using OrderManagement.DataAccess.Migrations;
using System.Data.Entity;

namespace OrderManagement.DataAccess
{
    public class OrderManagementContext: DbContext
    {
        public OrderManagementContext():base("RetailCompanyDb")
        {
            Database.SetInitializer(new RetailCompanyDbInitializer());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
