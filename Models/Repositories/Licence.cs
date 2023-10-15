using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class Licence
    {
        [Key]
        public int LicenceID { get; set; }
        [Required]
        public string TypeOfLicence { get; set; }
        
    }
}