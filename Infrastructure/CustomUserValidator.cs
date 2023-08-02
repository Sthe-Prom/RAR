using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using rar.Models;

namespace rar.Infrastructure
{
    public class CustomUserValidator : UserValidator<User>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>()
                : result.Errors.ToList();

            return errors.Count == 0 ? IdentityResult.Success
                   : IdentityResult.Failed(errors.ToArray());
        }
    }
}

