using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;

namespace rar.Infrastructure
{
    public class PaginationHeader
    {
        //Properties
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }

        //ReadOnly Property
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemPerPage) + 1;
    }
}