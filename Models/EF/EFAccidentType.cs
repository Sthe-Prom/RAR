using rar.Models.Repositories;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;
using RAR.Interfaces;


namespace rar.Models
{
    public class EFAccidentType: IAccidentType
    {
        public AppDbContext context;

        public IEnumerable<AccidentType> AccidentTypes => context.AccidentType;
        public EFAccidentType(AppDbContext ctx)
        {
            context = ctx;
        }
    }
}