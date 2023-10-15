using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;

namespace RAR.Models.EF
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