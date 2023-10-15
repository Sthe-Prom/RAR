using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string RegistrationNumber { get; set; }
        public bool MechanicalFailure { get; set; }
        
        /* Relationship
           FKs         
        */
        public int VehicleTypeID { get; set; }
        public int LoadTypeID { get; set; }
        public int LoadConditionID { get; set; }
        public int AccidentReportID { get; set; }
        public int VehicleOwnerID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("VehicleTypeID")]
        public virtual VehicleType VehicleType { get; set; }

        [ForeignKey("LoadTypeID")]
        public virtual LoadType LoadType { get; set; }

        [ForeignKey("LoadConditionID")]
        public virtual LoadCondition LoadCondition { get; set; }

        [ForeignKey("AccidentReportID")]
        public virtual AccidentReport AccidentReport { get; set; }

        [ForeignKey("VehicleOwnerID")]
        public virtual VehicleOwner VehicleOwner { get; set; }

        
    }
}