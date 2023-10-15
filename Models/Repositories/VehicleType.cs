using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
    }
}