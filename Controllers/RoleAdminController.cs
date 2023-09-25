using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rar.Interfaces;
using rar.Models;
//using rar.Models.ViewModels;

namespace rar.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RoleAdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<User> userManager;
        private IAccount acc_context;

        public RoleAdminController(RoleManager<IdentityRole> _roleManager, UserManager<User> _userManager,
                                   IAccount acc_context_)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            acc_context = acc_context_;
        }

        //READ
        public ViewResult Index()
        {
            RoleAdminViewModel vm = new RoleAdminViewModel();
            vm.Accounts = acc_context.Accounts;
            vm.Roles = roleManager.Roles;

            return View(vm);
        }

        //CREATE
        public IActionResult Create()
        {
            RoleAdminViewModel vm = new RoleAdminViewModel();
            vm.Accounts = acc_context.Accounts;
            vm.Roles = roleManager.Roles;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            return View(name);
        }

        //EDIT
        public async Task<IActionResult> Edit(string id)
        {
            RoleAdminViewModel vm = new RoleAdminViewModel();
            vm.Accounts = acc_context.Accounts;
            
            IdentityRole role = await roleManager.FindByIdAsync(id);

            List<User> members = new List<User>();
            List<User> nonMembers = new List<User>();

            foreach (User user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
        
                list.Add(user);
            }

            return View(new RoleEditModel { role = role, members = members, NonMembers = nonMembers });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleModificationModel vm_roleMod)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (string user_id in vm_roleMod.IDsToEdd ?? new string[] { })
                {
                    User user = await userManager.FindByIdAsync(user_id);

                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, vm_roleMod.RoleName);

                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }

                foreach (string user_id in vm_roleMod.IDsToDelete ?? new string[] { })
                {
                    User user = await userManager.FindByIdAsync(user_id);

                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, vm_roleMod.RoleName);

                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Edit(vm_roleMod.RoleID);
            }

        }

        //DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);

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
                ModelState.AddModelError("", "No role found");
            }

            return View("Index", roleManager.Roles);
        }

        public void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}
