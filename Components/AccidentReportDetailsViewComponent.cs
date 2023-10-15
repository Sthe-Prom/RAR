using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using rar.Models;
using rar.Interfaces;

namespace rar.Components
{
    public class AccidentReportDetailsViewComponent: ViewComponent
    {
        private IAccidentReport context;

        public AccidentReportDetailsViewComponent(IAccidentReport ctx)
        {
            context = ctx;   
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}