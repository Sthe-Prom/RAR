using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class RoadSurfaceQuality
    {
        [Key]
        public int RoadSurfaceQualityID { get; set; }
        public string RoadSurfaceQualityName { get; set; }

        /* Ref. by */
        //public virtual ICollection<RoadFactor> RoadFactor { get; set; }
    }
}