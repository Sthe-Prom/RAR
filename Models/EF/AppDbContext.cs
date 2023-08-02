using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rar.Interfaces;
using rar.Models.Repositories;

namespace rar.Models
{
    public class AppDbContext : DbContext
    {
        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        //Propeties - [T A B L E S]
        public DbSet<Account> Account { get; set; }
        public DbSet<Address> Address { get; set; }
       

    }
}
