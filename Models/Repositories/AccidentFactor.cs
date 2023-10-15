using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class AccidentFactor
    {
        [Key]
        public int AccidentFactorID { get; set; }

        /* Relationship
           FKs         
        */
         [Required(ErrorMessage = "Please select human factor")]
        public int HumanFactorID { get; set; }
         [Required(ErrorMessage = "Please select vehicle factor")]
        public int VehicleFactorID { get; set; }    
           
        public int AccidentReportID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("HumanFactorID")]
        public virtual HumanFactor HumanFactor { get; set; }

        [ForeignKey("VehicleFactorID")]
        public virtual VehicleFactor VehicleFactor { get; set; }

        [ForeignKey("AccidentReportID")]
        public virtual AccidentReport AccidentReport { get; set; }

     
    }
}