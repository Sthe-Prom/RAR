using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Interfaces;

namespace rar.Components
{
    public class CollisionFilterViewComponent: ViewComponent
    {
        //Private Property
        private ICollision context;

        //Constructor
        public CollisionFilterViewComponent(ICollision ctx)
        {
            context = ctx;
        }

        //Methods
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["collision"];

            // return View(context.CollisionTypes
            //             .Select(x => new {x.CollisionID, x.ColiisionType})
            //             .Distinct()
            //             .OrderBy(x => x.CollisionID)
            //             .ToList());

            var FilterProducts = (from p in context.CollisionTypes
                                      //group p by new {p.ProductID}
                                      //into myGroup
                                      //where myGroup.Count() > 0
                                  orderby p.ColiisionType
                                  select p)
                                  .Distinct()
                                  .ToList();
            return View(FilterProducts);

        }

    }
}