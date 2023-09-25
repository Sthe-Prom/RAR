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
        public DbSet<AccidentReport> AccidentReport { get; set; }
        public DbSet<PoliceStation> PoliceStation { get; set; }
        public DbSet<AccidentType> AccidentType { get; set; }
        public DbSet<AreaCode> AreaCode { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Collision> Collision { get; set; }


    }
}
