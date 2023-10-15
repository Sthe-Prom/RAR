using rar.Models.Repositories;
using rar.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;

namespace RAR.Models
{
    public class ReportViewModel: BaseViewModel
    {
        //Properties
        public IEnumerable<AccidentReport> AccidentReports { get; set; }
        public PaginationHeader PaginationHeader { get; set; }
        public int CollisionID { get; set; }
    }
}