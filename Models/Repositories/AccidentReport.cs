using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class AccidentReport
    {
        [Key]
        public int AccidentReportID { get; set; }

        [Required(ErrorMessage = "Accident ID Not Generated")]
        public string AccidentID { get; set; } 

        [Required(ErrorMessage = "Please Enter Accident Time")]
        public DateTime AccidentTime { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Please Enter Accident Date")]
        public DateTime AccidentDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Please Enter Accident Location")]
        public string AccidentLocation { get; set; }
        
        public string AccidentSketch { get; set; }

        public string AccidentPicture { get; set; }

        [Required(ErrorMessage = "Please Enter Accident Description")]
        public string AccidentDescription { get; set; }

        [Required(ErrorMessage = "Please Enter Number of People Killed")]
        public int NrPeopleKilled { get; set; }

        [Required(ErrorMessage = "Please Enter Number of People Injured")]
        public int NrPeopleInjured { get; set; }

        [Required(ErrorMessage = "Please Enter Number of People Injured")]
        public bool Confirmed { get; set; } = false;

        [Required(ErrorMessage = "Please Enter Indicate if it'a hit and run")]
        public bool HitAndRun { get; set; } = false;

        /* Relationship
           FKs         
        */
        [Required(ErrorMessage = "Please Login with your account")]
        public int AccountID { get; set; }

        public int PoliceStationID { get; set; }

        public int AccidentTypeID { get; set; }

        public int WeatherTypeID { get; set; }

        public int CollisionID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

        [ForeignKey("PoliceStationID")]
        public virtual PoliceStation PoliceStation { get; set; }

        [ForeignKey("AccidentTypeID")]
        public virtual AccidentType AccidentType { get; set; }

        [ForeignKey("WeatherTypeID")]
        public virtual Weather Weather { get; set; }

        [ForeignKey("CollisionID")]
        public virtual Collision Collision { get; set; }

        /* Ref. by */
        public virtual ICollection<AccidentFactor> AccidentFactor { get; set; }
        public virtual ICollection<RoadFactor> RoadFactor { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }


    }
}