using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class AreaCode
    {
        [Key]
        public int AreaCodeID { get; set; }
        public string AreaName { get; set; }

        /*Ref. by*/
        public virtual ICollection<AccidentReport> AccidentReport { get; set; }
    }
}