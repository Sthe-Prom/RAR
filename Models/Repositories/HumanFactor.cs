using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class HumanFactor
    {
        [Key]
        public int HumanFactorID { get; set; }
        public string HumanFactorName { get; set; }
    }
}