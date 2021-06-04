using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlaygroundWebApi;
using PlaygroundWebApi.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PlaygroundTest
{
    public class DemoTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1,1);
        }

        [Fact]
        public async void MyCustomerIntegrationTest()
        {
            // create db context
            var context = CreateDbContext().Result;
            // delete all existing customers in the db
            context.Customers.RemoveRange(await context.Customers.ToArrayAsync());
            await context.SaveChangesAsync();
            // create controller
            var controller = new CustomersController(context);
            // add customer
            var customer = await  controller.Add(new Customer() { CustomerName = "Christian" });
            // Check: Does GetAll return the added customer?
            var allCustomers = (await controller.GetAll());
            Assert.Single(allCustomers.ToArray());
            Assert.Equal("Christian", allCustomers.First().CustomerName);
        }

        public async Task<CustomerContex> CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddEnvironmentVariables()
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContex>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            var context = new CustomerContex(optionsBuilder.Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            return context;
        }

    }
}
