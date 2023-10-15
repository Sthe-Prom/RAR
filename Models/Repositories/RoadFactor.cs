using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class RoadFactor
    {
        [Key]
        public int RoadFactorID { get; set; }

        [Required(ErrorMessage = "Please enter valid road name")]
        public string RoadName { get; set; }
        [Required(ErrorMessage = "Please enter valid road number")]
        public string RoadNumber { get; set; }
        public string Landmark { get; set; }
        public bool PhysicalDivider { get; set; }
        public bool OnGoingRoadWorks { get; set; }

      
        /* Relationship
           FKs         
        */

        public int SurfaceConditionID { get; set; }
        public int RoadTypeID { get; set; }
        public int RoadFeatureID { get; set; }
        public int RoadSurfaceID { get; set; }
        public int RoadSurfaceQualityID { get; set; }        
        public int SpeedLimitID { get; set; }
        public int LaneID { get; set; }        
        public int AccidentReportID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("SurfaceConditionID")]
        public virtual SurfaceCondition SurfaceCondition { get; set; }

        [ForeignKey("RoadTypeID")]
        public virtual RoadType RoadType { get; set; }

        [ForeignKey("RoadFeatureID")]
        public virtual RoadFeature RoadFeature { get; set; }

        [ForeignKey("RoadSurfaceID")]
        public virtual RoadSurface RoadSurface { get; set; }

        [ForeignKey("RoadSurfaceQualityID")]
        public virtual RoadSurfaceQuality RoadSurfaceQuality { get; set; }

        [ForeignKey("SpeedLimitID")]
        public virtual SpeedLimit SpeedLimit { get; set; }

        [ForeignKey("LaneID")]
        public virtual Lane Lane { get; set; }

        [ForeignKey("AccidentReportID")]
        public virtual AccidentReport AccidentReport { get; set; }

        /* Ref. by */
        //None
        

    }
}