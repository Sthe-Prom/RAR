using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class VehicleOwner
    {
        [Key]
        public int VehicleOwnerID { get; set; }
        public string VehicleOwnerType { get; set; }

        /* Ref. by */
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}