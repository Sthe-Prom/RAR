using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class RoadSurface
    {        
        [Key]
        public int RoadSurfaceID { get; set; }
        public string RoadSurfaceName { get; set; }

        /* Ref. by */
        //public virtual ICollection<RoadFactor> RoadFactor { get; set; }
    }
}