using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaygroundWebApi
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName{ get; set; }
    }

    public class CustomerContex : DbContext
    {
        public CustomerContex(DbContextOptions<CustomerContex> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

    }
}
