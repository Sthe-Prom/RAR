using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class RoadType
    {
        [Key]
        public int RoadTypeID { get; set; }
        public string RoadTypeName { get; set; }

        /* Ref. by */
        //public virtual ICollection<RoadFactor> RoadFactor { get; set; }
    }
}