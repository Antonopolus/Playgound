using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaygroundWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContex Context;

        public CustomersController(CustomerContex context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return Context.Customers.ToArray();
        }

        [HttpPost]
        public async Task<Customer> Add([FromBody] Customer customer)
        {
            Context.Add(customer);
            await Context.SaveChangesAsync();
            return customer;
        }

    }
}
