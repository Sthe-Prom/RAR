using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class LoadCondition
    {
        [Key]
        public int LoadConditionID { get; set; }
        public string LoadConditionName { get; set; }
    }
}