using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;

namespace RAR.Models.EF
{
    public class EFVehicle: IVehicle
    {
        public AppDbContext context;

        public IEnumerable<Vehicle> Vehicles => context.Vehicle;

        public EFVehicle(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveVehicle(Vehicle Vehicle)
        {
            if (Vehicle.VehicleID == 0) //Add New Report
            {
                context.Vehicle.Add(Vehicle);
            }
            else //Edit Report
            {
                Vehicle dbEntry = context.Vehicle
                    .FirstOrDefault(c => c.VehicleID == Vehicle.VehicleID);

                if (dbEntry != null)
                {         
                    dbEntry.RegistrationNumber = Vehicle.RegistrationNumber;                   
                    dbEntry.MechanicalFailure = Vehicle.MechanicalFailure;
                    dbEntry.VehicleTypeID = Vehicle.VehicleTypeID;
                    dbEntry.LoadTypeID = Vehicle.LoadTypeID;                   
                    dbEntry.LoadConditionID = Vehicle.LoadConditionID;
                    dbEntry.VehicleOwnerID = Vehicle.VehicleOwnerID;
                    dbEntry.AccidentReportID = Vehicle.AccidentReportID;                       
                }
            }

            await context.SaveChangesAsync(); //commit to db
            
        }

        public Vehicle DeleteVehicle(int VehicleID)
        {
            Vehicle dbEntry = context.Vehicle
                .FirstOrDefault(c => c.VehicleID == VehicleID);

            if (dbEntry != null)
            {
                context.Vehicle.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}