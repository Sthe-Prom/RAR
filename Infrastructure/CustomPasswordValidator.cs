using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using rar.Models;

namespace rar.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<User>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string Password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, Password);

            List<IdentityError> errors = result.Succeeded ?
                new List<IdentityError>() : result.Errors.ToList();

            if (Password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PassWordContainsUsername",
                    Description = "Password Cannot Contain UserName."
                });
            }

            if (Password.Contains("1234"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PassWordContainsSequence",
                    Description = "Password Cannot Contain Sequence."
                });
            }

            return errors.Count == 0 ? IdentityResult.Success
                   : IdentityResult.Failed(errors.ToArray());
        }
    }
}
