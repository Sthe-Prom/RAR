using rar.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;

namespace rar.Interfaces
{
    public interface IAccidentReport
    {    
        IEnumerable<AccidentReport> AccidentReports { get; }

        Task SaveAccidentReport(AccidentReport AccidentReport);

        Task<AccidentReport> GetAccidentReport(int AccidentReportID);

        AccidentReport DeleteAccidentReport(int AccidentReportID);
    }
}