using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using rar.Models;

namespace rar.Models
{
    public class ProfileViewModel : BaseViewModel
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Please enter your Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname:")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please upload profile picture:")]
        public IFormFile ProfileImg { get; set; }

        [Required(ErrorMessage = "Please enter your Cell Number:")]
        public string Cell { get; set; }

        [Required(ErrorMessage = "Please Log in or Register Your account")]
        public string Id { get; set; }
      
        [Required(ErrorMessage = "Please Upload Identity Doc")]
        public IFormFile IdentityDoc { get; set; }

        public string MaritalStatus { get; set; }

        public string MarriageDoc { get; set; }
        
        public string FullAddress { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Users { get; set; }


    }
}


