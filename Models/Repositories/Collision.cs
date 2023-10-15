using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models.Repositories
{
    public class Collision
    {
        [Key]
        public int CollisionID { get; set; }
        public string ColiisionType { get; set; }

    }
}