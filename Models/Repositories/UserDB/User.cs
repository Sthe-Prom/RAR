using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rar.Models
{
    public class User: IdentityUser
    {
        //  /* Ref. by */       
        // public virtual ICollection<Account> Account { get; set; }
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[StringLength(50)]
        //public string Id { get; set; }
    }
}




