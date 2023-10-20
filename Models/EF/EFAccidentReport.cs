using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;
using rar.Interfaces;

namespace RAR.Models.EF
{
    public class EFAccidentReport: IAccidentReport
    {
        public AppDbContext context;

        public IEnumerable<AccidentReport> AccidentReports => context.AccidentReport;
        
        public EFAccidentReport(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveAccidentReport(AccidentReport AccidentReport)
        {
            if (AccidentReport.AccidentReportID == 0) //Add New Report
            {
                context.AccidentReport.Add(AccidentReport);
            }
            else //Edit Report
            {
                AccidentReport dbEntry = context.AccidentReport
                    .FirstOrDefault(c => c.AccidentReportID == AccidentReport.AccidentReportID);

                if (dbEntry != null)
                {                  
                    // dbEntry.AccidentID = AccidentReport.AccidentID;
                    // dbEntry.AccidentTime = AccidentReport.AccidentTime;
                    dbEntry.AccidentLocation = AccidentReport.AccidentLocation;
                    // dbEntry.AccidentDate = AccidentReport.AccidentDate;
                    dbEntry.AccidentDescription = AccidentReport.AccidentDescription;
                    dbEntry.NrPeopleKilled = AccidentReport.NrPeopleKilled;                    
                    dbEntry.NrPeopleInjured = AccidentReport.NrPeopleInjured;
                    // dbEntry.AccountID = AccidentReport.AccountID;
                    dbEntry.PoliceStationID = AccidentReport.PoliceStationID;
                    dbEntry.CollisionID = AccidentReport.CollisionID;
                    
                    dbEntry.AccidentTypeID = AccidentReport.AccidentTypeID;
                    dbEntry.WeatherTypeID = AccidentReport.WeatherTypeID;
                    dbEntry.Confirmed = AccidentReport.Confirmed;
                    //dbEntry.AccidentPicture = AccidentReport.AccidentPicture;
                    //dbEntry.AccidentSketch = AccidentReport.AccidentSketch;
                    dbEntry.HitAndRun = AccidentReport.HitAndRun;
                    
                }
            }

             await context.SaveChangesAsync(); //commit to db

        }

        public async Task<AccidentReport> GetAccidentReport(int AccidentReportID)
        {
            return await context.AccidentReport.FindAsync(AccidentReportID);
        }

        public AccidentReport DeleteAccidentReport(int AccidentReportID)
        {
            AccidentReport dbEntry = context.AccidentReport
                .FirstOrDefault(c => c.AccidentReportID == AccidentReportID);

            if (dbEntry != null)
            {
                context.AccidentReport.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
}