using OrderManagement.DataAccess.Entities;
using System.Data.Entity;

namespace OrderManagement.DataAccess.Migrations
{
    public class RetailCompanyDbInitializer : CreateDatabaseIfNotExists<OrderManagementContext>
    {
        protected override void Seed(OrderManagementContext context)
        {
            Product product1 = new Product()
            {
                Barcode = "2312213434534",
                Description = "Product1",
                Price = 28
            };
            Product product2 = new Product()
            {
                Barcode = "244213433564",
                Description = "Product2",
                Price = 36
            };
            Product product3 = new Product()
            {
                Barcode = "11231334354534",
                Description = "Product3",
                Price = 62
            };
            Product product4 = new Product()
            {
                Barcode = "7673234512664",
                Description = "Product4",
                Price = 26
            };

            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            Customer customer = new Customer()
            {
                Name = "Edward Wood",
                
            };

            context.Customers.Add(customer);
            base.Seed(context);
        }
    }
}
