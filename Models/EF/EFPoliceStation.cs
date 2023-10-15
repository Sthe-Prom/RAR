using rar.Models.Repositories;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;

namespace RAR.Models.EF
{
    public class EFPoliceStation: IPoliceStation
    {
        public AppDbContext context;

        public IEnumerable<PoliceStation> PoliceStations => context.PoliceStation;
        
        public EFPoliceStation(AppDbContext ctx)
        {
            context = ctx;
        }
    }
}