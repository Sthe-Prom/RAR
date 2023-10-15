using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class DriverInformation
    {
        [Key]
        public int DriverInformationID { get; set; }
         [Required(ErrorMessage = "Please enter driver name")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Please enter driver surname")]
        public string Surname { get; set; }
         [Required(ErrorMessage = "Please enter driver age")]
        public int Age { get; set; }
         [Required(ErrorMessage = "Please enter driver gender")]
        public string Gender { get; set; }
         [Required(ErrorMessage = "Please enter driver race")]
        public string Race { get; set; }
         [Required(ErrorMessage = "Please enter driver phone number")]
        public string PhoneNumber { get; set; }
         [Required(ErrorMessage = "Please enter driver's address")]   
         public string Address { get; set; }       
         [Required(ErrorMessage = "Please select safety device used")]
        public string SafetyDevice { get; set; }          
        public string LicenceNumber { get; set; }    
        public bool AlcoholTested { get; set; }
        public bool AlcoholSuspected { get; set; }

        /* Relationship
           FKs         
        */
        public int VehicleID { get; set; }
        public int LicenceID { get; set; }
        public int TrafficViolationID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("LicenceID")]
        public virtual Licence Licence { get; set; }

        [ForeignKey("VehicleID")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("TrafficViolationID")]
        public virtual TypeOfTrafficViolation TypeOfTrafficViolation { get; set; }

       
    }
}