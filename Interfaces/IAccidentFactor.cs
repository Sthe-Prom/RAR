using rar.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;

namespace rar.Interfaces
{
    public interface IAccidentFactor
    {
        IEnumerable<AccidentFactor> AccidentFactors { get; }

        Task SaveAccidentFactor(AccidentFactor AccidentFactor);

        AccidentFactor DeleteAccidentFactor(int AccidentFactorID);    
    }
}