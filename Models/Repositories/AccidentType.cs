using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class AccidentType
    {
        [Key]
        public int AccidentTypeID { get; set; }
        public string TypeOfAccident { get; set; }
    }
}