using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using rar.Models;
using rar.Models.Repositories;
//using rar.Models.ViewModels;

namespace rar.Models
{
    public class ProfileAddressViewModel : BaseViewModel
    {
        public Address AddressModel { get; set; }
        public Account Account { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public ProfileViewModel ProfileModel { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Users { get; set; }
    }
}