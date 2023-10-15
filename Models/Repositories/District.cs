using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace rar.Models.Repositories
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }

        /* Ref. by */
        //public virtual ICollection<PoliceStation> PoliceStation { get; set; }
    }
}