using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;

namespace rar.Models.EF
{
    public class EFDriverInformation: IDriverInformation
    {
        public AppDbContext context;

        public IEnumerable<DriverInformation> DriverInformationList => context.DriverInformation;
        
        public EFDriverInformation(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveDriverInformation(DriverInformation DriverInformation)
        {
            if (DriverInformation.DriverInformationID == 0) //Add New Report
            {
                context.DriverInformation.Add(DriverInformation);
            }
            else //Edit Report
            {
                DriverInformation dbEntry = context.DriverInformation
                    .FirstOrDefault(c => c.DriverInformationID == DriverInformation.DriverInformationID);

                if (dbEntry != null)
                {    
                    dbEntry.Name = DriverInformation.Name;                   
                    dbEntry.Surname = DriverInformation.Surname;
                    dbEntry.Age = DriverInformation.Age;                   
                    dbEntry.Gender = DriverInformation.Gender;
                    dbEntry.Race = DriverInformation.Race;
                    dbEntry.PhoneNumber = DriverInformation.PhoneNumber;                   
                    dbEntry.Address = DriverInformation.Address;
                    dbEntry.SafetyDevice = DriverInformation.SafetyDevice;
                    
                    dbEntry.LicenceNumber = DriverInformation.LicenceNumber;                   
                    dbEntry.AlcoholTested = DriverInformation.AlcoholTested;
                    dbEntry.AlcoholSuspected = DriverInformation.AlcoholSuspected; 

                    dbEntry.VehicleID = DriverInformation.VehicleID;                   
                    dbEntry.LicenceID = DriverInformation.LicenceID;
                    dbEntry.TrafficViolationID = DriverInformation.TrafficViolationID;

                }
            }

            await context.SaveChangesAsync(); //commit to db
            
        }

        public DriverInformation DeleteDriverInformation(int DriverInformationID)
        {
            DriverInformation dbEntry = context.DriverInformation
                .FirstOrDefault(c => c.DriverInformationID == DriverInformationID);

            if (dbEntry != null)
            {
                context.DriverInformation.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}