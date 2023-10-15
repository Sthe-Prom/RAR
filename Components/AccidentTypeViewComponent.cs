using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Interfaces;

namespace RAR.Components
{
    public class AccidentTypeViewComponent: ViewComponent
    {
        //Private Property
        private IAccidentType context;

        //Constructor
        public AccidentTypeViewComponent(IAccidentType ctx)
        {
            context = ctx;
        }
    
        //Methods
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["accidentType"];

            var AccTypeFilter = (from p in context.AccidentTypes                                     
                                  orderby p.TypeOfAccident
                                  select p)
                                  .Distinct()
                                  .ToList();

            return View(AccTypeFilter);

        }
    }
}