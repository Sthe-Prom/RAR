using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Models
{
    public class AccidentReportViewModel: BaseViewModel
    {
        public Account Account { get; set; }
        public AccidentReport AccidentReport { get; set; }
        public IEnumerable<AccidentReport> AccidentReports { get; set; }
        public IEnumerable<PoliceStation> PoliceStations { get; set; }
        public IEnumerable<AccidentType> AccidentTypes { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList PoliceStations_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList AreaCodes { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList AccidentTypes_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList WeatherTypes { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Collisions { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Users { get; set; }
    }
}