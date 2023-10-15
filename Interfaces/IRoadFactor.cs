using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IRoadFactor
    {
        IEnumerable<RoadFactor> RoadFactors { get; }

        Task SaveRoadFactor(RoadFactor RoadFactor);

        RoadFactor DeleteRoadFactor(int RoadFactorID);
    }
}