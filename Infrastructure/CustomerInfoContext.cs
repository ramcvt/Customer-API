using CustomerIdentityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerIdentityAPI.Infrastructure
{
    public class CustomerInfoContext :DbContext
    {
        public CustomerInfoContext(DbContextOptions<CustomerInfoContext> options) :base(options)
        {

        }
        public DbSet<CustomerInfo> Customers { get; set; }
        public DbSet<CustomerAddress> custaddress { get; set; }
    }
}
