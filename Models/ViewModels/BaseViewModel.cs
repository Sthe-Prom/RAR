using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rar.Models.Repositories;
using rar.Interfaces;


namespace rar.Models
{
    public class BaseViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}