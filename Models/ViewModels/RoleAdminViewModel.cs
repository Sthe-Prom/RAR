using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using rar.Models;

namespace rar.Models
{ 
    public class RoleAdminViewModel : BaseViewModel
    {
        public IQueryable<User> Users { get; set; }
        public IQueryable<IdentityRole> Roles { get; set; }
        public User User { get; set; }
        public IUserValidator<User> userValidator { get; set; }
        public IPasswordValidator<User> passwordValidator { get; set; }
        public IPasswordHasher<User> passwordHasher { get; set; }
        public CreateModel CreateModel { get; set; }
    }    
}
