using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rar.Models.Repositories;

namespace rar.Models.Repositories
{
    public class LoadType
    {
        [Key]
        public int LoadTypeID { get; set; }
        public string LoadTypeName { get; set; }
    }
}