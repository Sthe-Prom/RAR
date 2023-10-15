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
        //public DbSet<AreaCode> AreaCode { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Collision> Collision { get; set; }

        //Accident Factor Tables
        //public DbSet<AccidentFactor> AccidentFactor { get; set; }
        //public DbSet<HumanFactor> HumanFactor { get; set; }
        //public DbSet<VehicleFactor> VehicleFactor { get; set; }

        //Road Factor Tables
        public DbSet<RoadFactor> RoadFactor { get; set; }
        public DbSet<RoadFeature> RoadFeature { get; set; }
        public DbSet<RoadType> RoadType { get; set; }
        public DbSet<RoadSurface> RoadSurface { get; set; }
        public DbSet<SurfaceCondition> SurfaceCondition { get; set; }
        public DbSet<RoadSurfaceQuality> RoadSurfaceQuality { get; set; }
        public DbSet<SpeedLimit> SpeedLimit { get; set; }
        public DbSet<Lane> Lane { get; set; }        
        
        //Vehicle Details Tables
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleOwner> VehicleOwner { get; set; }
        public DbSet<DriverInformation> DriverInformation { get; set; }
        public DbSet<Licence> Licence { get; set; }
        public DbSet<TypeOfTrafficViolation> TypeOfTrafficViolation { get; set; }


    }
}
