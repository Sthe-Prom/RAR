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
    public class AccidentReportViewModel: BaseViewModel
    {
        //User
        public Account Account { get; set; }

        public IFormFile AccidentPicture { get; set; }
        
        public IFormFile AccidentSketch { get; set; }

        //Accident
        public AccidentReport AccidentReport { get; set; }

       
        //Road Factor Tables
        public RoadFactor RoadFactor { get; set; }
        public RoadType RoadType { get; set; }
        public RoadSurface RoadSurface { get; set; }
        public SurfaceCondition SurfaceCondition { get; set; }
        public RoadSurfaceQuality RoadSurfaceQuality { get; set; }
        public SpeedLimit SpeedLimit { get; set; }
        public Lane Lane { get; set; }

        public VehicleType VehicleType { get; set; }
        public LoadType LoadType { get; set; }
        public LoadCondition LoadCondition { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleOwner VehicleOwner { get; set; }
        public Licence Licence { get; set; }
        public DriverInformation DriverInfor { get; set; }

        public IEnumerable<AccidentReport> AccidentReports { get; set; }
        public IEnumerable<PoliceStation> PoliceStations { get; set; }
        public IEnumerable<AccidentType> AccidentTypes { get; set; }
        public IEnumerable<Collision> CollisionTypes { get; set; }
        public IEnumerable<RoadFactor> RoadFactors { get; set; }

        public PaginationHeader PaginationHeader { get; set; }
        public int AccidentTypeID { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList PoliceStations_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Provinces_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList District_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList AccidentTypes_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList WeatherTypes { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Collisions { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Users { get; set; }

        //Road Factors
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList RoadType_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList RoadSurface_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList RoadFeature_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Lane_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList SurfaceCondition_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList RoadSurfaceQuality_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList SpeedLimit_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList UserAccidentReports_select { get; set; }

        //Driver Factors
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList VehicleType_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList LoadCondition_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList LoadType_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList TrafficViolation_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Licence_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList VehicleOwner_Select { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList VehicleDriverOwner_Select { get; set; }

    }
}