using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class PoliceStation
    {
        [Key]
        public int PoliceStationID { get; set; }

        [Required(ErrorMessage = "Please enter Province")]
        public string PoliceStationName { get; set; }

        /* Relationship
          FKs         
       */
        [Required(ErrorMessage = "Please enter Province")]
        public int ProvinceID { get; set; }

        [Required(ErrorMessage = "Please enter District")]
        public int DistrictID { get; set; }


        /* Ref Nav Properties */
        [ForeignKey("ProvinceID")]
        public virtual Province Province { get; set; }

        [ForeignKey("DistrictID")]
        public virtual District District { get; set; }

      
    }
}