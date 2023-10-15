using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class SurfaceCondition
    {
        [Key]
        public int SurfaceConditionID { get; set; }
        public string SurfaceConditionName { get; set; }

        /* Ref. by */
        //public virtual ICollection<RoadFactor> RoadFactor { get; set; }
    }
}