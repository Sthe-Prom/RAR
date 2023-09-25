using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using rar.Infrastructure;
using rar.Interfaces;
//using rar.Models.ViewModels;
using rar.Models;

namespace rar.Controllers
{
    // [Authorize(Roles = "Admins")]
    public class AdminUserController : Controller
    {
        private UserManager<User> userManager;
        private IUserValidator<User> userValidator;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        private IAccount acc_context;
        private IServiceProvider serviceProvider;

        public AdminUserController(UserManager<User> _userMgr, IUserValidator<User> _userValidator,
                               IPasswordValidator<User> _passwordValidator, IPasswordHasher<User> _passwordHasher,
                                IAccount acc_context_, IServiceProvider serviceProvider_)
        {
            userManager = _userMgr;
            userValidator = _userValidator;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
            acc_context = acc_context_;
            serviceProvider = serviceProvider_;
        }


        //CREATE
        public ViewResult Create()
        {
            UserAdminViewModel vm = new UserAdminViewModel();
            vm.Accounts = acc_context.Accounts;

            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(UserAdminViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = vm.CreateModel.Name,
                    Email = vm.CreateModel.Email
                };

                RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityResult result = await userManager.CreateAsync(user, vm.CreateModel.Password);

                if (result.Succeeded)
                {
                    string role = "Officer";
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    await userManager.AddToRoleAsync(user, role);
                    return RedirectToAction("Login", "UserAccount");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(vm);
        }


        //EDIT
        public async Task<IActionResult> Edit(string Id)
        {
            UserAdminViewModel vm = new UserAdminViewModel();
            vm.Accounts = acc_context.Accounts;

            //User user = await userManager.FindByIdAsync(Id);
            vm.User = await userManager.FindByIdAsync(Id);

            if (vm != null)
            {
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserAdminViewModel vm, string password, string Id)
        {
            vm.Accounts = acc_context.Accounts;
            //Survey Survey = context.Surveys.FirstOrDefault(c => c.SurveyID == vm.SurveyID);
            User user = await userManager.FindByIdAsync(Id);
            //User user = userManager.Users.FirstOrDefault(c => c.Id == vm.User.Id);

            if (user != null)
            {
                user.Email = vm.User.Email;
                //user.Id = vm.User.Id;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User not Found");
            }

            return View(vm);
        }

        [HttpPost]
        //DELETE
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            return View("Index", userManager.Users);
        }

        public void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        [AllowAnonymous]
        public IActionResult Settings()
        {
            return View();
        }
    }
}
