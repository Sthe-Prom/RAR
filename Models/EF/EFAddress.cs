using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rar.Interfaces;
using rar.Models;

namespace rar.Models
{
    public class EFAddress : IAddress
    {
        public AppDbContext context;

        public IEnumerable<Address> Addresses => context.Address;

        public EFAddress(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveAddress(Address Address)
        {
            if (Address.AddressID == 0)
            {
                context.Address.Add(Address);
            }
            else
            {
                Address dbEntry = context.Address
                    .FirstOrDefault(c => c.AddressID == Address.AddressID);

                if (dbEntry != null)
                {
                    dbEntry.Province = Address.Province;
                    dbEntry.StreetName = Address.StreetName;
                    dbEntry.StreetNumber = Address.StreetNumber;
                    dbEntry.City = Address.City;
                    dbEntry.Suburb = Address.Suburb;
                    dbEntry.Zip = Address.Zip;
                }
            }

            context.SaveChanges(); //commit to db            
        }

        public Address DeleteAddress(int AddressID)
        {
            Address dbEntry = context.Address
                .FirstOrDefault(c => c.AddressID == AddressID);

            if (dbEntry != null)
            {
                context.Address.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
}
