using rar.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;

namespace rar.Interfaces
{
    public interface IVehicle
    {
        IEnumerable<Vehicle> Vehicles { get; }

        Task SaveVehicle(Vehicle Vehicle);

        Vehicle DeleteVehicle(int VehicleID);
    }
}