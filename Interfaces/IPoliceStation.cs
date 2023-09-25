using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IPoliceStation
    {
        IEnumerable<PoliceStation> PoliceStations { get; }
    }
}