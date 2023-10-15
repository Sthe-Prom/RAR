using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class SpeedLimit
    {
        [Key]
        public int SpeedLimitID { get; set; }
        public string SpeedLimitNumber { get; set; }

        /* Ref. by */
        //public virtual ICollection<RoadFactor> RoadFactor { get; set; }
        
    }
}