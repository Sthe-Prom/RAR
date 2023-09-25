using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class AccidentType
    {
        [Key]
        public int AccidentTypeID { get; set; }
        public string TypeOfAccident { get; set; }
    }
}