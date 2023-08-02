using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [Required(ErrorMessage = "Please Enter Province")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Please Enter Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please Enter Street Number")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Suburb")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Please Enter Zip Code")]
        public string Zip { get; set; }

        /* Relationship
           FKs         
        */
        [Required(ErrorMessage = "Please login with your registered account")]
        public int AccountID { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

        /* Ref. by */
        //public virtual ICollection<Account> Accounts { get; set; }

    }
}
