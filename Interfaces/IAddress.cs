using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IAddress
    {
        IEnumerable<Address> Addresses { get; }

        Task SaveAddress(Address Address);

        Address DeleteAddress(int AddressID);
    }
}