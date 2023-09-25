using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace rar.Models.Repositories
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }

        /* Ref. by */
        public virtual ICollection<PoliceStation> PoliceStation { get; set; }
    }
}