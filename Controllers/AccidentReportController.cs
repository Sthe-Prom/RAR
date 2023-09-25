using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data.Odbc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using RAR.Interfaces;


namespace rar.Controllers
{
    public class AccidentReportController: Controller
    {
        private IAccidentReport context;
        private IPoliceStation pol_context;
        private IAccidentType acc_t_context;
        private IAccount acc_context;
        private IConfiguration Configuration;
        public BaseViewModel BaseViewModel { get; set; }
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        public AccidentReportController(IAccidentReport ctx, IAccount i_Acc, IConfiguration config,
             SignInManager<User> s_man, UserManager<User> u_man, IPoliceStation pol_ctx, IAccidentType acc_t_ctx )
        {
            context = ctx;
            acc_context = i_Acc;
            Configuration = config;
            signInManager = s_man;
            userManager = u_man;
            pol_context = pol_ctx;
            acc_t_context = acc_t_ctx;
        }

              
        public ViewResult UnconfirmedReports() =>
            View(context.AccidentReports.Where(ar => !ar.Confirmed));

        //Confirm Reports
        [HttpPost] 
        public IActionResult ConfirmReport(int AccidentReportID)
        {
            // var AccidentReport = new AccidentReport
            // {
            //     AccidentReportID = vm.AccidentReport.AccidentReportID
            // };

            //  var AccidentReport = new AccidentReport
            //     {                   
            //         AccidentID = RAR,
            //         AccidentTime = vm.AccidentReport.AccidentTime,
            //         AccidentLocation = vm.AccidentReport.AccidentLocation,           
            //         AccidentDate = vm.AccidentReport.AccidentDate,
            //         AccidentDescription = vm.AccidentReport.AccidentDescription,
            //         NrPeopleKilled = vm.AccidentReport.NrPeopleKilled,
            //         NrPeopleInjured = vm.AccidentReport.NrPeopleInjured,
            //         AccountID = AccountID_,
            //         PoliceStationID = vm.AccidentReport.PoliceStationID,
            //         CollisionID = vm.AccidentReport.CollisionID,
            //         WeatherTypeID = vm.AccidentReport.WeatherTypeID,
            //         AreaCodeID = vm.AccidentReport.AreaCodeID,
            //         AccidentTypeID = vm.AccidentReport.AccidentTypeID
            //     };

           // if(AccidentReportID == 0) 
            //   AccidentReportID = vm.AccidentReport.AccidentReportID; //Convert.ToInt32(Request.Query["AccidentReportID"]);

            var AR = context.AccidentReports
                .FirstOrDefault(r => r.AccidentReportID == AccidentReportID);//Convert.ToInt32(Request.Query["AccidentReportID"]));
                
            // if(AR != null)
            // {
                try
                {
                    AR.Confirmed = true;
                    context.SaveAccidentReport(AR);
                    //return Content(AR.Confirmed.ToString() + " : " + AR.AccidentReportID);//+ Convert.ToInt32(Request.Query["AccidentReportID"]));
                    return Redirect("~/AccidentReport/AddReport");
                }
                catch(Exception ex)
                {
                    return Content("Not edited. " + ex.Message );
                }

                // return Content("AR not null");
            // }
            //  return Content("AR null" );
            //return RedirectToAction(nameof(AddReport));
            //return Redirect("~/");
           
        }

        [HttpGet]
        public ViewResult EditReport(int AccidentReportID)
        {
            AccidentReportViewModel vm = new AccidentReportViewModel();
                          
            vm.AccidentReport = new AccidentReport();
            vm.Users = getUsers();
            vm.Accounts = acc_context.Accounts;
            vm.PoliceStations_Select = getPoliceStations();
            vm.AreaCodes = getAreaCodes();
            vm.WeatherTypes = getWeatherTypes();
            vm.Collisions = getCollisions();
            vm.AccidentTypes_Select = getAccidentTypes();
            vm. AccidentReports = context.AccidentReports;
          
            AccidentReport AccidentReport = context.AccidentReports
                .FirstOrDefault(r => r.AccidentReportID == AccidentReportID);
                 
            vm.AccidentReport.AccidentReportID = AccidentReport.AccidentReportID;
            vm.AccidentReport.AccidentLocation = AccidentReport.AccidentLocation;
            vm.AccidentReport.AccidentDescription = AccidentReport.AccidentDescription;           
            vm.AccidentReport.NrPeopleInjured = AccidentReport.NrPeopleInjured;
            vm.AccidentReport.NrPeopleKilled = AccidentReport.NrPeopleKilled;
            vm.AccidentReport.AreaCodeID = AccidentReport.AreaCodeID;
            vm.AccidentReport.WeatherTypeID = AccidentReport.WeatherTypeID;
            vm.AccidentReport.AccidentTypeID = AccidentReport.AccidentTypeID;
            vm.AccidentReport.CollisionID = AccidentReport.CollisionID;
            vm.AccidentReport.PoliceStationID = AccidentReport.PoliceStationID;
            vm.AccidentReport.AccidentDate = AccidentReport.AccidentDate;
            vm.AccidentReport.AccidentTime = AccidentReport.AccidentTime;          
            vm.AccidentReport.AccidentID = AccidentReport.AccidentID;
            vm.AccidentReport.Confirmed = AccidentReport.Confirmed;

            return View(vm);            

        }  

        [HttpGet]
        public ViewResult AddReport()
        {
            AccidentReportViewModel vm = new AccidentReportViewModel()
            {
                Users = getUsers(),
                Accounts = acc_context.Accounts,
                AccidentReports = context.AccidentReports,
                PoliceStations = pol_context.PoliceStations,
                AccidentTypes = acc_t_context.AccidentTypes,
                AccidentReport = new AccidentReport(),
                PoliceStations_Select = getPoliceStations(),
                AreaCodes = getAreaCodes(),
                WeatherTypes = getWeatherTypes(),
                Collisions = getCollisions(),
                AccidentTypes_Select = getAccidentTypes()
                
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddReport(AccidentReportViewModel vm)
        {
            int AccountID_ = 0;
            string RAR = "";

            if (signInManager.IsSignedIn(User))
            {
                if(vm.AccidentReport.AccidentDate.ToShortDateString().Length > 0 && vm.AccidentReport.AccidentLocation.Length > 0)
                    RAR = "RAR-" + DateTime.Now.ToShortDateString().Substring(0, 4) + "-" + vm.AccidentReport.AccidentLocation.Substring(0, 3).ToUpper();

                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }
            
            // var AccidentReport = context.AccidentReports.FirstOrDefault(r => r.AccidentReportID == 15); 
            
            // if (AccidentReport != null)//default(AccidentReport))
            // {
            //     AccidentReport.AccidentID = vm.AccidentReport.AccidentID;
            //     //AccidentReport.AccidentTime = vm.AccidentReport.AccidentTime;
            //     AccidentReport.AccidentLocation = vm.AccidentReport.AccidentLocation;        
            //     //AccidentReport.AccidentDate = vm.AccidentReport.AccidentDate;
            //     AccidentReport.AccidentDescription = vm.AccidentReport.AccidentDescription;
            //     AccidentReport.NrPeopleKilled = vm.AccidentReport.NrPeopleKilled;
            //     AccidentReport.NrPeopleInjured = vm.AccidentReport.NrPeopleInjured;
            //     AccidentReport.AccountID = vm.AccidentReport.AccountID;
            //     AccidentReport.PoliceStationID = vm.AccidentReport.PoliceStationID;
            //     AccidentReport.CollisionID = vm.AccidentReport.CollisionID;
            //     AccidentReport.WeatherTypeID = vm.AccidentReport.WeatherTypeID;
            //     AccidentReport.AreaCodeID = vm.AccidentReport.AreaCodeID;
            //     AccidentReport.AccidentTypeID = vm.AccidentReport.AccidentTypeID;
            // }
            // else
            // {
                var AccidentReport = new AccidentReport
                {                   
                    AccidentID = RAR,
                    AccidentTime = vm.AccidentReport.AccidentTime,
                    AccidentLocation = vm.AccidentReport.AccidentLocation,           
                    AccidentDate = vm.AccidentReport.AccidentDate,
                    AccidentDescription = vm.AccidentReport.AccidentDescription,
                    NrPeopleKilled = vm.AccidentReport.NrPeopleKilled,
                    NrPeopleInjured = vm.AccidentReport.NrPeopleInjured,
                    AccountID = AccountID_,
                    PoliceStationID = vm.AccidentReport.PoliceStationID,
                    CollisionID = vm.AccidentReport.CollisionID,
                    WeatherTypeID = vm.AccidentReport.WeatherTypeID,
                    AreaCodeID = vm.AccidentReport.AreaCodeID,
                    AccidentTypeID = vm.AccidentReport.AccidentTypeID
                };
            // }
            // if (ModelState.IsValid)
            // {
                try
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        context.SaveAccidentReport(AccidentReport);
                        return RedirectToAction("AddReport"); //return Content("Added");//
                    }
                    else
                    {
                        return Content("Please go to your profile to create an account before you can report accident");
                    }
                }
                catch (Exception ex)
                {
                    return Content("Not Added." + ex.Message);
                }
            //}
            // else
            // {
            //     return Content("Invalid Model");
            // }
        }
        
        [HttpPost]
        public IActionResult EditReport(AccidentReportViewModel vm)
        {             
            var AccidentReport = context.AccidentReports.FirstOrDefault(r => r.AccidentReportID == vm.AccidentReport.AccidentReportID); //Convert.ToInt32(Request.Query["AccidentReportID"]));//8);//
            
            if (AccidentReport != default(AccidentReport))
            { 

                //return Content("Something's right");
                //AccidentReport.AccidentReportID = vm.AccidentReport.AccidentReportID;              
                // AccidentReport.AccidentID = vm.AccidentReport.AccidentID;
                // AccidentReport.AccidentTime = vm.AccidentReport.AccidentTime;
                AccidentReport.AccidentLocation = vm.AccidentReport.AccidentLocation;        
                // AccidentReport.AccidentDate = vm.AccidentReport.AccidentDate;
                AccidentReport.AccidentDescription = vm.AccidentReport.AccidentDescription;
                AccidentReport.NrPeopleKilled = vm.AccidentReport.NrPeopleKilled;
                AccidentReport.NrPeopleInjured = vm.AccidentReport.NrPeopleInjured;
                // AccidentReport.AccountID = vm.AccidentReport.AccountID;
                AccidentReport.PoliceStationID = vm.AccidentReport.PoliceStationID;
                AccidentReport.AccidentTypeID = vm.AccidentReport.AccidentTypeID;
                AccidentReport.CollisionID = vm.AccidentReport.CollisionID;
                AccidentReport.WeatherTypeID = vm.AccidentReport.WeatherTypeID;
                AccidentReport.AreaCodeID = vm.AccidentReport.AreaCodeID;
                AccidentReport.Confirmed = vm.AccidentReport.Confirmed;

                //var userId = userManager.GetUserId(User);
                //User user_id = userManager.FindByIdAsync(userId);

                // if((userManager.IsInRoleAsync(User,"Data Manager")) )
                // {

                //     AccidentReport.Confirmed = true;
                // }
                // else
                // {
                //     AccidentReport.Confirmed = true;
                // }

            }
            else
            {
                 return Content("Something's not right");
            }

            // if (ModelState.IsValid)
            // {
                try
                {
            //         // if (signInManager.IsSignedIn(User))
            //         // {
                        context.SaveAccidentReport(AccidentReport);
                        return RedirectToAction("AddReport"); //return Content("Added");//
            //             // return Content("PS: " + PoliceStationID   
            //             //         + "\nCol: " + CollisionID
            //             //         + "\nAT: " + AccidentTypeID
            //             //         + "\nAR: " + vm.AccidentReport.AccidentReportID);

            //             // return Content("PS: " + AccidentReport.PoliceStationID   
            //             //         + "\nCol: " + AccidentReport.CollisionID
            //             //         + "\nAT: " + AccidentReport.AccidentTypeID
            //             //         + "\nAR: " + AccidentReport.AccidentReportID);
            //         // // }
            //         // else
            //         // {
            //         //     return Content("Please go to your profile to create an account before you can report accident");
            //         // }
                }
                catch (Exception ex)
                {
                    return Content("Not Edited." + ex.Message);
                }
            //  }
            // else
            // {
            //     return Content("Invalid Model");
            // }

        }        

        public IActionResult Delete(int AccidentReportID)
        {
            AccidentReport AccidentReport = context.DeleteAccidentReport(AccidentReportID);

            return Redirect("~/AccidentReport/AddReport");
        }    

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getUsers()
        {
            //string c = Configuration.GetValue<string>("Data:DevDB2:ConnectionString");
            //string c = Configuration.GetConnectionString("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<User> models = new List<User>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select Id, Email from [AspNetUsers]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new User();
                                m.Id = reader.GetString(reader.GetOrdinal("Id"));
                                m.Email = reader.GetString(reader.GetOrdinal("Email"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "Id", "Email");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getPoliceStations()
        {
            //string c = Configuration.GetValue<string>("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<PoliceStation> models = new List<PoliceStation>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select PoliceStationID, PoliceStationName from [PoliceStation]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new PoliceStation();
                                m.PoliceStationID = reader.GetInt32(reader.GetOrdinal("PoliceStationID"));
                                m.PoliceStationName = reader.GetString(reader.GetOrdinal("PoliceStationName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "PoliceStationID", "PoliceStationName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getAreaCodes()
        {
            //string c = Configuration.GetValue<string>("Data:DevDB2:ConnectionString");
            //string c = Configuration.GetConnectionString("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<AreaCode> models = new List<AreaCode>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select AreaCodeID, AreaName from [AreaCode]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new AreaCode();
                                m.AreaCodeID = reader.GetInt32(reader.GetOrdinal("AreaCodeID"));
                                m.AreaName = reader.GetString(reader.GetOrdinal("AreaName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "AreaCodeID", "AreaName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getAccidentTypes()
        {
            //string c = Configuration.GetValue<string>("Data:DevDB2:ConnectionString");
            //string c = Configuration.GetConnectionString("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<AccidentType> models = new List<AccidentType>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select AccidentTypeID, TypeOfAccident from [AccidentType]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new AccidentType();
                                m.AccidentTypeID = reader.GetInt32(reader.GetOrdinal("AccidentTypeID"));
                                m.TypeOfAccident = reader.GetString(reader.GetOrdinal("TypeOfAccident"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "AccidentTypeID", "TypeOfAccident");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getWeatherTypes()
        {
            //string c = Configuration.GetValue<string>("Data:DevDB2:ConnectionString");
            //string c = Configuration.GetConnectionString("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<Weather> models = new List<Weather>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select WeatherTypeID, TypeOfWeather from [Weather]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Weather();
                                m.WeatherTypeID = reader.GetInt32(reader.GetOrdinal("WeatherTypeID"));
                                m.TypeOfWeather = reader.GetString(reader.GetOrdinal("TypeOfWeather"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "WeatherTypeID", "TypeOfWeather");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getCollisions()
        {
            //string c = Configuration.GetValue<string>("Data:DevDB2:ConnectionString");
            //string c = Configuration.GetConnectionString("DevDB");
            string c = Configuration.GetConnectionString("ProdDB");

            List<Collision> models = new List<Collision>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select CollisionID, ColiisionType from [Collision]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Collision();
                                m.CollisionID = reader.GetInt32(reader.GetOrdinal("CollisionID"));
                                m.ColiisionType = reader.GetString(reader.GetOrdinal("ColiisionType"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "CollisionID", "ColiisionType");
            return userSelect;
        }

    }
}