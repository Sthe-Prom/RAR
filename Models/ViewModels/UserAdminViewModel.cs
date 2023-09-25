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
    public class UserAdminViewModel: BaseViewModel
    {
        public IQueryable<User> Users { get; set; }
        public User User { get; set; }
        public IUserValidator<User> userValidator { get; set; }
        public IPasswordValidator<User> passwordValidator { get; set; }
        public IPasswordHasher<User> passwordHasher { get; set; }
        public CreateModel CreateModel { get; set; }
        public CreateAdminUserModel CreateAdminUserModel { get; set; }
    
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Roles { get; set; }
    }
}

