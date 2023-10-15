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
using rar.Infrastructure;

namespace rar.Models
{
    public class AccidentFactorViewModel: BaseViewModel
    {
        //Accident Factor Tables
        public HumanFactor HumanFactor { get; set; }
        public VehicleFactor VehicleFactor { get; set; }
        public AccidentReport AccidentReport { get; set; }

        //Accident Factors
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList HumanFactor_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList VehicleFactor_Select { get; set; }
    }
}