using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rar.Models;
using rar.Models;
using rar.Interfaces;

namespace rar.Controllers
{

    public class AddressController : Controller
    {
        //Private Fields
        //--------------

        private IAddress context;
        private IAccount ctx_context;

        //Constructor
        //-----------
        public AddressController(IAddress ctx, IAccount ctx_context_)
        {
            context = ctx;
            ctx_context = ctx_context_;
        }

        public IActionResult Index()
        {
            ProfileAddressViewModel vm = new ProfileAddressViewModel();
            vm.Addresses = context.Addresses;
            vm.Accounts = ctx_context.Accounts;

            return View(vm);
        }

        //CREATE
        [HttpGet]
        public ViewResult Address()
        {
            ProfileAddressViewModel vm = new ProfileAddressViewModel();
            vm.Addresses = context.Addresses;
            vm.Accounts = ctx_context.Accounts;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Address(ProfileAddressViewModel vm)
        {
            var Address = new Address
            {
                Province = vm.AddressModel.Province,
                City = vm.AddressModel.City,
                StreetNumber = vm.AddressModel.StreetNumber,
                StreetName = vm.AddressModel.StreetName,
                Suburb = vm.AddressModel.Suburb,
                Zip = vm.AddressModel.Zip,
                AccountID = vm.AddressModel.AccountID
            };

            if (ModelState.IsValid)
            {
                context.SaveAddress(Address);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View(vm);
            }
        }

        //UPDATE
        public ViewResult Edit(int AddressID)
        {
            ProfileAddressViewModel vm = new ProfileAddressViewModel();

            Address Address = context.Addresses.FirstOrDefault(c => c.AddressID == AddressID);

            vm.AddressModel.Province = Address.Province;
            vm.AddressModel.City = Address.City;
            vm.AddressModel.StreetNumber = Address.StreetNumber;
            vm.AddressModel.StreetName = Address.StreetName;
            vm.AddressModel.Suburb = Address.Suburb;
            vm.AddressModel.Zip = Address.Zip;
            vm.AddressModel.AccountID = Address.AccountID;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ProfileAddressViewModel vm)
        {
            var Address = context.Addresses.FirstOrDefault(c => c.AddressID == vm.AddressModel.AddressID);
            if (Address != default(Address))
            {
                Address.Province = vm.AddressModel.Province;
                Address.City = vm.AddressModel.City;
                Address.StreetNumber = vm.AddressModel.StreetNumber;
                Address.StreetName = vm.AddressModel.StreetName;
                Address.Suburb = vm.AddressModel.Suburb;
                Address.Zip = vm.AddressModel.Zip;
                Address.AccountID = vm.AddressModel.AccountID;

            }

            try
            {
                if (ModelState.IsValid)
                {
                    context.SaveAddress(Address);
                    return RedirectToAction("profile", "Account");
                }
                else
                {
                    return View(vm);
                }
            }
            catch
            {
                return View(vm);
            }
        }

        //DELETE
        public IActionResult Delete(int AddressID)
        {
            Address Address = context.DeleteAddress(AddressID);
            return RedirectToAction("Index");
        }

        public ViewResult AddressList() => View(context.Addresses);

    }
}
