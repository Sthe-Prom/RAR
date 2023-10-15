using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class VehicleFactor
    {
        [Key]
        public int VehicleFactorID { get; set; }

        public string VehicleFactorName { get; set; }
    }
}