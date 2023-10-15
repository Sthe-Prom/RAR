using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;

namespace rar.Models.EF
{
    public class EFRoadFactor: IRoadFactor
    {
        public AppDbContext context;

        public IEnumerable<RoadFactor> RoadFactors => context.RoadFactor;
        
        public EFRoadFactor(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveRoadFactor(RoadFactor RoadFactor)
        {
            if (RoadFactor.RoadFactorID == 0) //Add New Report
            {
                context.RoadFactor.Add(RoadFactor);
            }
            else //Edit Report
            {
                RoadFactor dbEntry = context.RoadFactor
                    .FirstOrDefault(c => c.RoadFactorID == RoadFactor.RoadFactorID);

                if (dbEntry != null)
                {                        
                    dbEntry.RoadName = RoadFactor.RoadName;                   
                    dbEntry.RoadNumber = RoadFactor.RoadNumber;
                    dbEntry.Landmark = RoadFactor.Landmark;
                    dbEntry.PhysicalDivider = RoadFactor.PhysicalDivider;                   
                    dbEntry.OnGoingRoadWorks = RoadFactor.OnGoingRoadWorks;
                    dbEntry.SurfaceConditionID = RoadFactor.SurfaceConditionID; 

                    dbEntry.RoadTypeID = RoadFactor.RoadTypeID;
                    dbEntry.RoadFeatureID = RoadFactor.RoadFeatureID;                   
                    dbEntry.RoadSurfaceID = RoadFactor.RoadSurfaceID;
                    dbEntry.RoadSurfaceQualityID = RoadFactor.RoadSurfaceQualityID;   

                    dbEntry.SpeedLimitID = RoadFactor.SpeedLimitID;                   
                    dbEntry.LaneID = RoadFactor.LaneID;
                    dbEntry.AccidentReportID = RoadFactor.AccidentReportID;                       
                }
            }

            await context.SaveChangesAsync(); //commit to db
            
        }

        public RoadFactor DeleteRoadFactor(int RoadFactorID)
        {
            RoadFactor dbEntry = context.RoadFactor
                .FirstOrDefault(c => c.RoadFactorID == RoadFactorID);

            if (dbEntry != null)
            {
                context.RoadFactor.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}