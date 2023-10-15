using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class TypeOfTrafficViolation
    {
        [Key]
        public int TypeOfTrafficViolationID { get; set; }
        public string TypeOfTrafficViolationName { get; set; }
    }
}