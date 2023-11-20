using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data.Odbc;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using rar.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;


namespace rar.Controllers
{
    public class AccidentReportController: Controller
    {
        private IAccidentReport context;
        private IPoliceStation pol_context;
        private IAccidentType acc_t_context;
        private ICollision coll_context;
        private IAccount acc_context;
        
        private IConfiguration Configuration;
        public BaseViewModel BaseViewModel { get; set; }
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        //Accident Factor
        

        //Road Factor
        private IRoadFactor roadFac_context;

        //Vehicle Factor
        private IVehicle veh_context;

        //Driver Infor Factor
        private IDriverInformation drvFac_context;

        private readonly IWebHostEnvironment HostEnvironment;

        private int PageSize = 6;

        public AccidentReportController(IAccidentReport ctx, IAccount i_Acc, IConfiguration config,
            SignInManager<User> s_man, UserManager<User> u_man, IPoliceStation pol_ctx, IAccidentType acc_t_ctx,
            ICollision coll_ctx, IRoadFactor roadFac_ctx, IVehicle veh_ctx, IDriverInformation drvFac_ctx,
            IWebHostEnvironment he)
        {
            context = ctx;
            acc_context = i_Acc;
            Configuration = config;
            signInManager = s_man;
            userManager = u_man;
            pol_context = pol_ctx;
            acc_t_context = acc_t_ctx;
            coll_context = coll_ctx;
            HostEnvironment = he;
                        
            //Road Factors
            roadFac_context = roadFac_ctx;

            //Vehicle Factors
            veh_context = veh_ctx;

            //DriverInfor Factors
            drvFac_context = drvFac_ctx;
        }
              
        public ViewResult UnconfirmedReports() =>
            View(context.AccidentReports.Where(ar => !ar.Confirmed));
        
        public ViewResult Ajax() 
        {
            AccidentReportViewModel vm = new AccidentReportViewModel();
            vm.Accounts = acc_context.Accounts;
            return View(vm);
        }

        //Confirm Reports
        [HttpPost] 
        public async Task<JsonResult> ConfirmReport(IFormCollection formcollection)
        {
            var id = Convert.ToInt32(formcollection["AccidentReport_AccidentReportID"]);
            var AccidentReport = context.AccidentReports.FirstOrDefault(r => r.AccidentReportID == id);
        
            AccidentReport.Confirmed = Convert.ToBoolean(formcollection["AccidentReport_Confirmed"]);

            JsonViewModel model = new JsonViewModel();

            try
            {
                await context.SaveAccidentReport(AccidentReport);
                model.ResponseMessage = "Success ";
            }
            catch (Exception ex)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = "Could not save";
            }

            if (AccidentReport != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(AccidentReport.AccidentID);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }

            return Json(model);            
            
        }

        [HttpGet]
        public ViewResult EditReport(int AccidentReportID)
        {
            AccidentReportViewModel vm = new AccidentReportViewModel();
                          
            vm.AccidentReport = new AccidentReport();
            vm.Vehicle = new Vehicle();
            vm.DriverInfor = new DriverInformation();
            vm.RoadFactor = new RoadFactor();
            vm.Users = getUsers();
            vm.Accounts = acc_context.Accounts;
            vm.PoliceStations_Select = getPoliceStations();
            vm.Provinces_Select = getProvinces();
            vm.WeatherTypes = getWeatherTypes();
            vm.Collisions = getCollisions();
            vm.AccidentTypes_Select = getAccidentTypes();
            vm.AccidentReports = context.AccidentReports;
          
            AccidentReport AccidentReport = context.AccidentReports
                .FirstOrDefault(r => r.AccidentReportID == AccidentReportID);

            // Convert.ToInt32(formcollection["AccidentReportID"]) = AccidentReport.AccidentReportID;
            // formcollection["AccidentLocation"].ToString() = AccidentReport.AccidentLocation;
            // Convert.ToInt32(formcollection["AccidentDescription"]) = AccidentReport.AccidentDescription;
            // Convert.ToInt32(formcollection["NrPeopleInjured"]) = AccidentReport.NrPeopleInjured;
            // Convert.ToInt32(formcollection["NrPeopleKilled"]) = AccidentReport.NrPeopleKilled;
            // Convert.ToBoolean(formcollection["HitAndRun"]) = AccidentReport.HitAndRun;
            // Convert.ToInt32(formcollection["WeatherTypeID"]) = AccidentReport.WeatherTypeID;
            // Convert.ToInt32(formcollection["AccidentTypeID"]) = AccidentReport.AccidentTypeID;
            // Convert.ToInt32(formcollection["CollisionID"]) = AccidentReport.CollisionID;
            // Convert.ToInt32(formcollection["PoliceStationID"]) = AccidentReport.PoliceStationID;
            // Convert.ToDateTime(formcollection["AccidentDate"]) = AccidentReport.AccidentDate;
            // Convert.ToDateTime(formcollection["AccidentTime"]) = AccidentReport.AccidentTime;
            // Convert.ToInt32(formcollection["AccidentID"]) = AccidentReport.AccidentID;

            vm.AccidentReport.AccidentReportID = AccidentReport.AccidentReportID;
            vm.AccidentReport.AccidentLocation = AccidentReport.AccidentLocation;
            vm.AccidentReport.AccidentDescription = AccidentReport.AccidentDescription;
            vm.AccidentReport.NrPeopleInjured = AccidentReport.NrPeopleInjured;
            vm.AccidentReport.NrPeopleKilled = AccidentReport.NrPeopleKilled;
            vm.AccidentReport.HitAndRun = AccidentReport.HitAndRun;
            vm.AccidentReport.WeatherTypeID = AccidentReport.WeatherTypeID;
            vm.AccidentReport.AccidentTypeID = AccidentReport.AccidentTypeID;
            vm.AccidentReport.CollisionID = AccidentReport.CollisionID;
            vm.AccidentReport.PoliceStationID = AccidentReport.PoliceStationID;
            vm.AccidentReport.AccidentDate = AccidentReport.AccidentDate;
            vm.AccidentReport.AccidentTime = AccidentReport.AccidentTime;
            vm.AccidentReport.AccidentID = AccidentReport.AccidentID;

            return View(vm);            

        }  

         [HttpGet]        
        public ViewResult LatestAccidents(int accidentType, string sortOrder, string currentFilter, string sortUser, string filterConfirmed, int Page = 1)
        {       
            //Logged in User
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

                    
            //Filter - Sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Oldest" ? "Newest" : "Oldest";
            ViewBag.UserSortParm = sortUser == "AllUsers" ? "LoggedIn" : "AllUsers";
            ViewBag.ConfirmedSortParm = filterConfirmed == "Confirmed" ? "Unconfirmed" : "Confirmed";

            AccidentReportViewModel vm = new AccidentReportViewModel();

            vm.PaginationHeader = new PaginationHeader();
            vm.PaginationHeader.CurrentPage = Page;
            vm.PaginationHeader.ItemPerPage = PageSize;
           
            vm.PaginationHeader.TotalItems = accidentType == 0 ?
                    context.AccidentReports.Count() :
                    context.AccidentReports.Where(e => e.AccidentTypeID == accidentType).Count();


            //Filter By Accident Types
            vm.AccidentReports = context.AccidentReports
               .Where(c => accidentType == 0 || c.AccidentTypeID == accidentType)
               .OrderBy(c => c.AccidentReportID)
               .Skip((Page - 1) * PageSize)
               .Take(PageSize);


            //Sort By User 

            if (!string.IsNullOrEmpty(Request.Query["sortUser"]))
            {
                switch (sortUser)
                {
                    case "AllUsers":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
                        vm.AccidentReports = context.AccidentReports                           
                            .Skip((Page - 1) * PageSize)
                            .OrderBy(c => c.AccidentDate)
                            .Take(PageSize);
                        break;
                    case "LoggedIn":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Where(r => r.AccountID == AccountID_).Count();
                        vm.AccidentReports = context.AccidentReports
                            .Where(r => r.AccountID == AccountID_ )
                            .OrderBy(c => c.AccidentDate)
                            .Skip((Page - 1) * PageSize)
                            .Take(PageSize);
                        break;
                    default:
                        // vm.AccidentReports = context.AccidentReports
                        //     .Skip((Page - 1) * PageSize)
                        //     .Take(PageSize);
                        // vm.PaginationHeader.TotalItems = vm.AccidentReports.Count();
                        break;
                }

            }
            else{
                // vm.AccidentReports = context.AccidentReports
                //     .Skip((Page - 1) * PageSize)
                //     .Take(PageSize);
                // vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
            }
           
            //Sort By Order
            if (!string.IsNullOrEmpty(Request.Query["sortOrder"]))
            {
                switch (sortOrder)
                {
                    case "Oldest":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
                        vm.AccidentReports = context.AccidentReports                           
                            .OrderBy(r => r.AccidentDate)
                            .Skip((Page - 1) * PageSize)
                            .Take(PageSize);
                        break;
                    case "Newest":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
                        vm.AccidentReports = context.AccidentReports                           
                            .OrderByDescending(r => r.AccidentDate)
                            .Skip((Page - 1) * PageSize)
                            .Take(PageSize);
                        break;
                    default:
                        // vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
                        // vm.AccidentReports = vm.AccidentReports
                        //     .Skip((Page - 1) * PageSize)
                        //     .Take(PageSize); ;
                        break;
                }

            }  
            else{
                // vm.AccidentReports = context.AccidentReports
                //     .Skip((Page - 1) * PageSize)
                //     .Take(PageSize);
                // vm.PaginationHeader.TotalItems = context.AccidentReports.Count();
            }


            //Filter By Confirmed 

            if (!string.IsNullOrEmpty(Request.Query["filterConfirmed"]))
            {
                switch (filterConfirmed)
                {
                    case "Confirmed":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Where(r => r.Confirmed == true).Count();
                        vm.AccidentReports = context.AccidentReports
                            .Where(r => r.Confirmed == true)
                            .OrderByDescending(r => r.AccidentDate)
                            .Skip((Page - 1) * PageSize)
                            .Take(PageSize);
                        break;
                    case "Unconfirmed":
                        vm.PaginationHeader.TotalItems = context.AccidentReports.Where(r => r.Confirmed == false).Count();
                        vm.AccidentReports = context.AccidentReports
                            .Where(r => r.Confirmed == false)
                            .OrderByDescending(r => r.AccidentDate)
                            .Skip((Page - 1) * PageSize)
                            .Take(PageSize);
                        break;     
                    default:                       
                        break;

                }

            }
          

            vm.AccidentTypeID = accidentType;

            // switch (sortOrder)
            //     {                   
            //         case "Oldest":
            //             vm.AccidentReports = vm.AccidentReports.OrderBy(r => r.AccidentDate);
            //             break;
            //         case "Newest":
            //             vm.AccidentReports = vm.AccidentReports.OrderByDescending(r => r.AccidentDate);
            //             break;
            //         default:
            //             vm.AccidentReports = vm.AccidentReports;
            //             break;
            //     }

           

            // switch (sortUser)
                // {                   
                //     case "AllUsers":
                //         vm.AccidentReports = vm.AccidentReports;
                //         break;
                //     case "LoggedIn":
                //         vm.AccidentReports =  vm.AccidentReports
                //             .Where(r => r.AccountID == AccountID_ )
                //             .OrderBy(c => c.AccidentReportID)
                //             .Skip((Page - 1) * PageSize)
                //             .Take(PageSize);
                        
                //         break;
                //     default:
                //         vm.AccidentReports = vm.AccidentReports;
                //         break;
                // }
            
            vm.Accounts = acc_context.Accounts;
            vm.PoliceStations = pol_context.PoliceStations;
            vm.AccidentTypes = acc_t_context.AccidentTypes;
            vm.CollisionTypes = coll_context.CollisionTypes;
            vm.RoadFactors = roadFac_context.RoadFactors;

            return View(vm);
                                
        }

        [HttpGet]        
        public ViewResult AddReport(int accidentType, string sortOrder, string currentFilter, string sortUser, int Page = 1)
        {       
            //Logged in User
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            //Filter - Sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Oldest" ? "Newest" : "Oldest";
            ViewBag.UserSortParm = sortUser == "AllUsers" ? "LoggedIn" : "AllUsers";

            AccidentReportViewModel vm = new AccidentReportViewModel();
                     
            vm.AccidentReports = context.AccidentReports
                .Where(c => accidentType == 0 || c.AccidentTypeID == accidentType)
                .OrderBy(c => c.AccidentReportID)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize);

            vm.PaginationHeader = new PaginationHeader();
            
            vm.PaginationHeader.CurrentPage = Page;
            vm.PaginationHeader.ItemPerPage = PageSize;

            if (!string.IsNullOrEmpty(Request.Query["accidentType"]))
            {
                vm.PaginationHeader.TotalItems = accidentType == 0 ?
                        context.AccidentReports.Count() :
                        context.AccidentReports.Where(e => e.AccidentTypeID == accidentType).Count();
            }

            // if (!string.IsNullOrEmpty(Request.Query["sortUser"]))
            // {                
            //     switch (sortUser)
            //     {
            //         case "AllUsers":
            //             TotalItems = context.AccidentReports;
            //             break;
            //         case "LoggedIn":
            //             TotalItems = context.AccidentReports.Where(r => r.AccountID == AccountID_);
            //             break;
            //         default:
            //             vm.AccidentReports = context.AccidentReports;
            //             break;
            //     }                

            // }
            // else{
            //     context.AccidentReports.Count();
            // }

            // if (!string.IsNullOrEmpty(Request.Query["sortOrder"]))
            // {
            //     switch (sortUser)
            //     {
            //         case "Oldest":
            //             TotalItems = context.AccidentReports.AccidentReports.OrderBy(r => r.AccidentDate);
            //             break;
            //         case "Newest":
            //             TotalItems = context.AccidentReports.AccidentReports.OrderByDescending(r => r.AccidentDate);
            //             break;
            //         default:
            //             TotalItems = context.AccidentReports;
            //             break;
            //     }

            // }
            // else
            // {
            //     context.AccidentReports.Count();
            // }

            vm.AccidentTypeID = accidentType;

            // switch (sortOrder)
            //     {                   
            //         case "Oldest":
            //             vm.AccidentReports = vm.AccidentReports.OrderBy(r => r.AccidentDate);
            //             break;
            //         case "Newest":
            //             vm.AccidentReports = vm.AccidentReports.OrderByDescending(r => r.AccidentDate);
            //             break;
            //         default:
            //             vm.AccidentReports = vm.AccidentReports;
            //             break;
            //     }
           

            // switch (sortUser)
            //     {                   
            //         case "AllUsers":
            //             vm.AccidentReports = vm.AccidentReports;
            //             break;
            //         case "LoggedIn":
            //             vm.AccidentReports =  vm.AccidentReports
            //                 .Where(r => r.AccountID == AccountID_ )
            //                 .OrderBy(c => c.AccidentReportID)
            //                 .Skip((Page - 1) * PageSize)
            //                 .Take(PageSize);
                        
            //             break;
            //         default:
            //             vm.AccidentReports = vm.AccidentReports;
            //             break;
            //     }

           
                //Get values
            vm.Users = getUsers();
            vm.Accounts = acc_context.Accounts;
                //AccidentReports = context.AccidentReports,
            vm.PoliceStations = pol_context.PoliceStations;
            vm.AccidentTypes = acc_t_context.AccidentTypes;
            vm.CollisionTypes = coll_context.CollisionTypes;
            vm.AccidentReport = new AccidentReport();
            vm.PoliceStations_Select = getPoliceStations();
            vm.Provinces_Select = getProvinces();
            vm.WeatherTypes = getWeatherTypes();
            vm.Collisions = getCollisions();
            vm.AccidentTypes_Select = getAccidentTypes();
                            
                //Road Factor Tables
            vm.RoadFactor = new RoadFactor();
            vm.RoadType_Select = getRoadTypes();
            vm.RoadSurface_Select = getRoadSurfaceNames();
            vm.RoadSurfaceQuality_Select = getRoadSurfaceQuality();
            vm.SurfaceCondition_Select = getSurfaceConditions();
            vm.SpeedLimit_Select = getSpeedLimit();
            vm.Lane_Select = getLanes();
            vm.RoadFeature_Select = getRoadFeatures();

            
            var reps = from r in context.AccidentReports
                        where r.AccountID == AccountID_
                        select new {
                            r.AccidentReportID,
                            r.AccidentID
                        };

            ViewBag.UserAccidentReports = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(reps, "AccidentReportID", "AccidentID"); 

            vm.UserAccidentReports_select = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(reps, "AccidentReportID", "AccidentID");

                //Vehicle Factor Tables
            vm.Vehicle = new Vehicle();
            vm.VehicleOwner = new VehicleOwner();               
            vm.VehicleType_Select = getVehicleType();
            vm.VehicleOwner_Select = getVehicleOwner();
            vm.LoadCondition_Select = getLoadConditions();
            vm.LoadType_Select = getLoadTypes();

                //DriverInfor Tables               
            vm.DriverInfor = new DriverInformation();
            vm.TrafficViolation_Select = getTrafficViolation();
            vm.Licence_Select = getLicenceTypes();
            vm.VehicleDriverOwner_Select = getVehicleDriverOwner();

            return View(vm);
                                
        }
                          
        [HttpGet]
        public ViewResult AddRoadFactors()
        {
            AccidentReportViewModel vm = new AccidentReportViewModel()
            {
                Users = getUsers(),
                Accounts = acc_context.Accounts,
                AccidentReports = context.AccidentReports,
              
                //AddAccidentFactors Tables
                AccidentReport = new AccidentReport(),
                RoadFactor = new RoadFactor(),
               
                RoadType_Select = getRoadTypes(),
                RoadSurface_Select = getRoadSurfaceNames(),
                RoadSurfaceQuality_Select = getRoadSurfaceQuality(),
                SurfaceCondition_Select = getSurfaceConditions(),   
                SpeedLimit_Select = getSpeedLimit(),
                Lane_Select = getLanes(),
                RoadFeature_Select = getRoadFeatures()

            };

            return View(vm);
        }

        [HttpGet]
        public ViewResult AddVehicle()
        {
            AccidentReportViewModel vm = new AccidentReportViewModel()
            {
                Users = getUsers(),
                Accounts = acc_context.Accounts,
                AccidentReports = context.AccidentReports,
              
                //Vehicle Tables
                AccidentReport = new AccidentReport(),
                Vehicle = new Vehicle(),
               
                VehicleType_Select = getVehicleType(),
                LoadCondition_Select = getLoadConditions(),
                LoadType_Select = getLoadTypes(),
                VehicleOwner_Select = getVehicleOwner()
               
            };

            return View(vm);
        }

        [HttpGet]
        public ViewResult AddDriverInformation()
        {
            AccidentReportViewModel vm = new AccidentReportViewModel()
            {
                Users = getUsers(),
                Accounts = acc_context.Accounts,
                AccidentReports = context.AccidentReports,
              
                //DriverInfor Tables
                AccidentReport = new AccidentReport(),                
                DriverInfor = new DriverInformation(),
               
                TrafficViolation_Select = getTrafficViolation(),               
                Licence_Select = getLicenceTypes()

            };

            return View(vm);
        }

        //[ChildActionOnly]
        [HttpGet]
        public IActionResult GetAccidentReport(int id)
        {
             AccidentReportViewModel vm = new AccidentReportViewModel();
                          
             vm.AccidentReport = new AccidentReport();

            // AccidentReport AccidentReport = context.AccidentReports
            //     .FirstOrDefault(r => r.AccidentReportID == AccidentReportID);
                            
            // vm.AccidentReport.AccidentReportID = AccidentReport.AccidentReportID;
            // vm.AccidentReport.AccidentID = AccidentReport.AccidentID;
            // vm.AccidentReport.AccidentLocation = AccidentReport.AccidentLocation;
            // vm.AccidentReport.NrPeopleInjured = AccidentReport.NrPeopleInjured;
            
            // return View(vm); 

            // AccidentReportViewModel vm = new AccidentReportViewModel
            // {
            //     AccidentReport.AccidentReportID = AccidentReportID;
            // };                 
            // ViewBag.Message = "GetAccidentReport";

            // if(vm.AccidentReport.AccidentReportID == AccidentReportID)
            //     return PartialView("",vm);

             return PartialView(vm);

            //return PartialView(id);
        }

        
        public ViewResult GetAccidentData()
        {         
            var AccidentReportData = new List<AccidentReport>();
            AccidentReportViewModel vm = new AccidentReportViewModel();

            //AccidentReport AccidentReports = context.AccidentReport();

            foreach (var item in context.AccidentReports)
            {
                AccidentReportData.Add(new AccidentReport
                {
                    AccidentReportID = item.AccidentReportID,
                    HitAndRun = item.HitAndRun,
                    Confirmed = item.Confirmed,
                    AccidentLocation = item.AccidentLocation,
                    NrPeopleInjured = item.NrPeopleInjured,
                    AccidentDate = item.AccidentDate
                });
            }

           
            JsonViewModel model = new JsonViewModel();

            try
            {
                vm.AccidentReports = AccidentReportData.ToArray();
            }
            catch (Exception ex)
            {
                model.ResponseCode = 1;
            }

            if (AccidentReportData.Count > 0)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(AccidentReportData);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }

            vm.AccidentReports = AccidentReportData;

            return View(vm);

            //return View(vm);

        }

       
      
        [HttpPost]
        public async Task<JsonResult> AddReportAjax(IFormCollection formcollection)
        {
            int AccountID_ = 0;
            string RAR = "";

            AccidentReportViewModel vm = new AccidentReportViewModel();

            if (signInManager.IsSignedIn(User))
            {
                if (Convert.ToString(formcollection["AccidentLocation"]).Length > 0)
                    RAR = "RAR-" + DateTime.UtcNow.ToString("HH:mm:ss").Substring(0, 3) + "-" + formcollection["AccidentLocation"].ToString().Substring(0, 3).ToUpper();

                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }            

            string uploadedAPImage = UploadedAccidentPicture(vm);

            if (uploadedAPImage == null)
            {
                uploadedAPImage = "Upload is null";
            }

            JsonViewModel model = new JsonViewModel();

            var AccidentReport = new AccidentReport
            {
                AccidentID =  RAR,
                AccidentTime = Convert.ToDateTime(formcollection["AccTime"]),
                AccidentLocation = formcollection["AccidentLocation"].ToString(),
                AccidentDate = Convert.ToDateTime(formcollection["AccDate"]), 
                AccidentDescription = formcollection["AccidentDescription"].ToString(),
                NrPeopleKilled = Convert.ToInt32(formcollection["AccKilled"]),
                NrPeopleInjured = Convert.ToInt32(formcollection["AccInjured"]),
                AccountID =  AccountID_,//Convert.ToInt32(formcollection["AccountID"]),
                PoliceStationID = Convert.ToInt32(formcollection["PoliceStation"]),
                CollisionID = Convert.ToInt32(formcollection["CollisionType"]),
                WeatherTypeID = Convert.ToInt32(formcollection["WeatherType"]),
                AccidentTypeID = Convert.ToInt32(formcollection["AccidentType"]),
                AccidentPicture = uploadedAPImage,
                AccidentSketch = uploadedAPImage,
                HitAndRun = Convert.ToBoolean(formcollection["HitAndRun"])

            };
            
            try
            {           
                await context.SaveAccidentReport(AccidentReport);                                                    
            }
            catch (Exception ex)
            {
                model.ResponseCode = 1;
            }

            if (AccidentReport != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(AccidentReport.AccidentID);//"Accident Report Added";
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }

            return Json(model);

        }


        [HttpPost]
        public async Task<IActionResult> AddRoadFactors(AccidentReportViewModel vm)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            var AR_ID = context.AccidentReports
                .OrderBy(r => r.AccountID)
                .FirstOrDefault(r => r.AccountID == AccountID_);
           
            var RoadFactor = new RoadFactor
            {                   
                RoadName = vm.RoadFactor.RoadName,
                RoadNumber = vm.RoadFactor.RoadNumber,
                Landmark = vm.RoadFactor.Landmark,
                PhysicalDivider = vm.RoadFactor.PhysicalDivider,
                OnGoingRoadWorks = vm.RoadFactor.OnGoingRoadWorks,
                SurfaceConditionID = vm.RoadFactor.SurfaceConditionID,
                RoadTypeID = vm.RoadFactor.RoadTypeID,
                RoadFeatureID = vm.RoadFactor.RoadFeatureID,
                RoadSurfaceID = vm.RoadFactor.RoadSurfaceID,                
                RoadSurfaceQualityID = vm.RoadFactor.RoadSurfaceQualityID,       
                SpeedLimitID = vm.RoadFactor.SpeedLimitID,
                LaneID = vm.RoadFactor.LaneID,
                AccidentReportID = AR_ID.AccidentReportID//vm.RoadFactor.AccidentReportID  //AR_ID//AR_ID.AccidentReportID//
               
            };
           
           
            // if(ModelState.IsValid)
            // {
                try
                {
                    // if (signInManager.IsSignedIn(User))
                    // {
                        await roadFac_context.SaveRoadFactor(RoadFactor);
                        return RedirectToAction("AddReport"); // return Content("Added");//
                    // }
                    // else
                    // {
                    //     return Content("Error: Account not created or user not signed-in.");
                    // }
                }
                catch (Exception ex)
                {
                    return Content("Road Factors Not Added." + ex.Message);
                }

                //return Content("Valid Road factor Model");
            // }
            // else
            // {
            //     return Content("Invalid Road factor Model");
            // }
        }
      
        [HttpPost]
        public async Task<JsonResult> AddRoadFactorsAjax(IFormCollection formcollection)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            var AR_ID = context.AccidentReports
                .OrderByDescending(r => r.AccidentReportID)
                .FirstOrDefault(r => r.AccountID == AccountID_);

            JsonViewModel model = new JsonViewModel();
           
            var RoadFactor = new RoadFactor
            {                   
                RoadName = formcollection["RoadName"].ToString(),
                RoadNumber = formcollection["RoadNumber"].ToString(),
                Landmark = formcollection["Landamrk"].ToString(),
                PhysicalDivider = Convert.ToBoolean(formcollection["PhysicalDivider"]),
                OnGoingRoadWorks = Convert.ToBoolean(formcollection["OnGoingRoadWorks"]),
                SurfaceConditionID = Convert.ToInt32(formcollection["SurfaceCondition"]),
                RoadTypeID = Convert.ToInt32(formcollection["RoadType"]),
                RoadFeatureID = Convert.ToInt32(formcollection["RoadFeature"]),
                RoadSurfaceID = Convert.ToInt32(formcollection["RoadSurface"]),                
                RoadSurfaceQualityID = Convert.ToInt32(formcollection["SurfaceQuality"]),       
                SpeedLimitID = Convert.ToInt32(formcollection["SpeedLimit"]),
                LaneID = Convert.ToInt32(formcollection["Lane"]),
                AccidentReportID = AR_ID.AccidentReportID               
            };

            try
            {                   
                await roadFac_context.SaveRoadFactor(RoadFactor);               
            }
            catch (Exception ex)
            {
                model.ResponseCode = 1;
            }

            if (RoadFactor != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(RoadFactor.RoadName);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }

            return Json(model);
           
        
        }


        [HttpPost]
        public async Task<IActionResult> AddVehicle(AccidentReportViewModel vm)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            var AR_ID = context.AccidentReports
                .OrderByDescending(r => r.AccidentReportID)
                .FirstOrDefault(r => r.AccountID == AccountID_);

            var reps = from r in context.AccidentReports
                        where r.AccountID == AccountID_
                        orderby r.AccidentReportID descending
                        select new {
                            r.AccidentReportID,
                            r.AccidentID,
                            r.AccountID
                        };

            var accID = reps.FirstOrDefault(r => r.AccountID == AccountID_);

            ViewBag.UserAccidentReports = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(reps, "AccidentReportID", "AccidentID"); 

            var Vehicle = new Vehicle
            {                   
                RegistrationNumber = vm.Vehicle.RegistrationNumber,
                MechanicalFailure = vm.Vehicle.MechanicalFailure,
                VehicleTypeID = vm.Vehicle.VehicleTypeID,
                LoadTypeID = vm.Vehicle.LoadTypeID,
                LoadConditionID = vm.Vehicle.LoadConditionID,
                VehicleOwnerID = vm.Vehicle.VehicleOwnerID,
                AccidentReportID = AR_ID.AccidentReportID //vm.Vehicle.AccidentReportID  //AR_ID            
            };
           
            if(ModelState.IsValid)
            {
                try
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        await veh_context.SaveVehicle(Vehicle);
                        return RedirectToAction("AddReport"); //return Content("Added");//
                    }
                    else
                    {
                        return Content("Error: Account not created or user not signed-in.");
                    }
                }
                catch (Exception ex)
                {
                    return Content("Road Factors Not Added." + ex.Message);
                }

                return Content("Valid Vehicle Model");
            }
            else
            {
                return Content("Invalid Vehicle Model");
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddVehicleAjax(IFormCollection formcollection)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            var AR_ID = context.AccidentReports
                .OrderByDescending(r => r.AccidentReportID)
                .FirstOrDefault(r => r.AccountID == AccountID_);

            var reps = from r in context.AccidentReports
                        where r.AccountID == AccountID_
                        orderby r.AccidentReportID descending
                        select new {
                            r.AccidentReportID,
                            r.AccidentID,
                            r.AccountID
                        };

            var accID = reps.FirstOrDefault(r => r.AccountID == AccountID_);

            ViewBag.UserAccidentReports = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(reps, "AccidentReportID", "AccidentID"); 

            JsonViewModel model = new JsonViewModel();

            var Vehicle = new Vehicle
            {                   
                RegistrationNumber = formcollection["VehicleRegistrationNr"].ToString(),
                MechanicalFailure =  Convert.ToBoolean(formcollection["MechanicalFailure"]),
                VehicleTypeID = Convert.ToInt32(formcollection["VehicleType"]),
                LoadTypeID = Convert.ToInt32(formcollection["LoadType"]),
                LoadConditionID = Convert.ToInt32(formcollection["LoadCondition"]),
                VehicleOwnerID = Convert.ToInt32(formcollection["VehicleOwner"]),
                AccidentReportID = AR_ID.AccidentReportID //vm.Vehicle.AccidentReportID  //AR_ID            
            };
           
            if(ModelState.IsValid)
            {
                try
                {
                    await veh_context.SaveVehicle(Vehicle);                        
                }
                catch (Exception ex)
                {
                    model.ResponseCode = 0;
                }

       
                if (Vehicle != null)
                {
                    model.ResponseCode = 0;
                    model.ResponseMessage = JsonConvert.SerializeObject(Vehicle.RegistrationNumber);
                }
                else
                {
                    model.ResponseCode = 1;
                    model.ResponseMessage = "No record available";
                }
                
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "Invalid Vehicle Model";
            }

            return Json(model);

        }
        
        [HttpPost]
        public async Task<ActionResult> AddDriverInformation(AccidentReportViewModel vm)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            };

            var AR = context.AccidentReports
                .FirstOrDefault(r => r.AccountID == AccountID_);

            int AR_ID = AR.AccidentReportID;

            var Vehicle = veh_context.Vehicles
                .FirstOrDefault(r => r.AccidentReportID == AR_ID);

            int Vehicle_ID = Vehicle.VehicleID;

            var DriverInfor = new DriverInformation
            {                   
                Name = vm.DriverInfor.Name,
                Surname = vm.DriverInfor.Surname,
                Age = vm.DriverInfor.Age,
                Gender = vm.DriverInfor.Gender,
                Race = vm.DriverInfor.Race,
                PhoneNumber = vm.DriverInfor.PhoneNumber,
                Address = vm.DriverInfor.Address,
                SafetyDevice = vm.DriverInfor.SafetyDevice,
                AlcoholTested = vm.DriverInfor.AlcoholTested,
                AlcoholSuspected = vm.DriverInfor.AlcoholSuspected,
                LicenceNumber = vm.DriverInfor.LicenceNumber,
                LicenceID = vm.DriverInfor.LicenceID,
                TrafficViolationID = vm.DriverInfor.TrafficViolationID,               
                VehicleID = vm.DriverInfor.VehicleID                
            };
           
            // if(ModelState.IsValid)
            // {
                try
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        await drvFac_context.SaveDriverInformation(DriverInfor);
                        return RedirectToAction("AddReport"); //return Content("DriverInfor Added");//r
                    }
                    else
                    {
                        return Content("Error: Account not created or user not signed-in.");
                    }
                }
                catch (Exception ex)
                {
                    return Content("Road Factors Not Added." + ex.Message);
                }

                //return Content("Valid DriverInfor Model");
            // }
            // else
            // {
            //     return Content("Invalid DriverInfor Model");
            // }
        }

        [HttpPost]
        public async Task<JsonResult> AddDriverInformationAjax(IFormCollection formcollection)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {                
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            };

            var AR = context.AccidentReports
                .FirstOrDefault(r => r.AccountID == AccountID_);

            int AR_ID = AR.AccidentReportID;

            var Vehicle = veh_context.Vehicles
                .FirstOrDefault(r => r.AccidentReportID == AR_ID);

            int Vehicle_ID = Vehicle.VehicleID;

            JsonViewModel model = new JsonViewModel();

            var DriverInfor = new DriverInformation
            {                   
                Name = formcollection["Name"].ToString(),
                Surname = formcollection["Surname"].ToString(),
                Age = Convert.ToInt32(formcollection["Age"]),
                Gender = formcollection["Gender"].ToString(),
                Race = formcollection["Race"].ToString(),
                PhoneNumber = formcollection["PhoneNumber"].ToString(),
                Address = formcollection["Address"].ToString(),
                SafetyDevice = formcollection["SafetyDeviceUsed"].ToString(),
                AlcoholTested = Convert.ToBoolean(formcollection["AlcoholTested"]),
                AlcoholSuspected = Convert.ToBoolean(formcollection["AlcoholSuspected"]),
                LicenceNumber = formcollection["LicenseRegNumber"].ToString(),
                LicenceID = Convert.ToInt32(formcollection["License"]),
                TrafficViolationID = Convert.ToInt32(formcollection["TrafficViolation"]),               
                VehicleID = Convert.ToInt32(formcollection["VehicleDriverOwner"]),              
            };
           
                try
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        await drvFac_context.SaveDriverInformation(DriverInfor);                        
                    }
                    else
                    {
                        model.ResponseMessage = "Error: Account not created or user not signed-in.";
                    }
                }
                catch (Exception ex)
                {
                    model.ResponseMessage = "DriverInfor details Not Added.";
                }

                if (DriverInfor != null)
                {
                    model.ResponseCode = 0;
                    model.ResponseMessage = JsonConvert.SerializeObject(DriverInfor.Name);
                }
                else
                {
                    model.ResponseCode = 1;
                    model.ResponseMessage = "No record available";
                }

                return Json(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditReport(AccidentReportViewModel vm)
        {             
            var AccidentReport = context.AccidentReports.FirstOrDefault(r => r.AccidentReportID == Convert.ToInt32(Request.Query["AccidentReportID"]));//8);//
            
            if (AccidentReport != default(AccidentReport))
            {     

                //return Content("Something's right");
                //AccidentReport.AccidentReportID = vm.AccidentReport.AccidentReportID;              
                // AccidentReport.AccidentID = vm.AccidentReport.AccidentID;
                // AccidentReport.AccidentTime = vm.AccidentReport.AccidentTime;
                AccidentReport.AccidentLocation = vm.AccidentReport.AccidentLocation;        
                AccidentReport.AccidentDate = vm.AccidentReport.AccidentDate;
                AccidentReport.AccidentDescription = vm.AccidentReport.AccidentDescription;
                AccidentReport.NrPeopleKilled = vm.AccidentReport.NrPeopleKilled;
                AccidentReport.NrPeopleInjured = vm.AccidentReport.NrPeopleInjured;
                // AccidentReport.AccountID = vm.AccidentReport.AccountID;
                AccidentReport.PoliceStationID = vm.AccidentReport.PoliceStationID;
                AccidentReport.AccidentTypeID = vm.AccidentReport.AccidentTypeID;
                AccidentReport.CollisionID = vm.AccidentReport.CollisionID;
                AccidentReport.WeatherTypeID = vm.AccidentReport.WeatherTypeID;
              
                //AccidentReport.Confirmed = vm.AccidentReport.Confirmed;
                AccidentReport.HitAndRun = vm.AccidentReport.HitAndRun;

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
                        await context.SaveAccidentReport(AccidentReport);
                        return RedirectToAction("LatestAccidents"); //return Content("Added");//
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

        [HttpPost]
        public async Task<JsonResult> EditReportAjax(IFormCollection formcollection)
        {
            var id = Convert.ToInt32(formcollection["AccidentReport_AccidentReportID"]);
            var AccidentReport = context.AccidentReports.FirstOrDefault(r => r.AccidentReportID == id);
            //Convert.ToInt32(formcollection["AccidentReportID"]));//Convert.ToInt32(Request.Query["AccidentReportID"]));
            //Convert.ToInt32(formcollection["AccidentReportID"])); //Convert.ToInt32(Request.Query["AccidentReportID"]));//8);//

            JsonViewModel model = new JsonViewModel();

            if (AccidentReport != default(AccidentReport))
            {                
                AccidentReport.AccidentTime = Convert.ToDateTime(formcollection["AccidentReport_AccidentTime"]);
                AccidentReport.AccidentLocation = formcollection["AccidentReport_AccidentLocation"].ToString();
                AccidentReport.AccidentDate = Convert.ToDateTime(formcollection["AccidentReport_AccidentDate"]);
                AccidentReport.AccidentDescription = formcollection["AccidentReport_AccidentDescription"].ToString();
                AccidentReport.NrPeopleKilled = Convert.ToInt32(formcollection["AccidentReport_NrPeopleKilled"]);
                AccidentReport.NrPeopleInjured = Convert.ToInt32(formcollection["AccidentReport_NrPeopleInjured"]);
                AccidentReport.PoliceStationID = Convert.ToInt32(formcollection["AccidentReport_PoliceStationID"]);
                AccidentReport.CollisionID = Convert.ToInt32(formcollection["AccidentReport_CollisionID"]);
                AccidentReport.WeatherTypeID = Convert.ToInt32(formcollection["AccidentReport_WeatherTypeID"]);
                AccidentReport.AccidentTypeID = Convert.ToInt32(formcollection["AccidentReport_AccidentTypeID"]);
                AccidentReport.HitAndRun = Convert.ToBoolean(formcollection["AccidentReport_HitAndRun"]);               
            }            
          
            try
            {
                await context.SaveAccidentReport(AccidentReport);
            }
            catch (Exception ex)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = "Issue is: " + ex.Message;
            }

            if (AccidentReport != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(AccidentReport.AccidentID);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }

            return Json(model);           

        }

        public Microsoft.AspNetCore.Mvc.IActionResult Delete(int AccidentReportID)
        {
            AccidentReport AccidentReport = context.DeleteAccidentReport(AccidentReportID);

            return Redirect("~/AccidentReport/LatestAccidents");
        }

        //Filter        
        [HttpGet]
        public ViewResult List(string sortOrder, string sortUser)
        {
            int AccountID_ = 0;

            if (signInManager.IsSignedIn(User))
            {
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            ViewBag.DateSortParm = sortOrder == "Oldest" ? "Newest" : "Oldest";
            ViewBag.UserSortParm = sortUser == "AllUsers" ? "LoggedIn" : "AllUsers";

            AccidentReportViewModel vm = new AccidentReportViewModel();
        
            vm.AccidentReports = context.AccidentReports;

            switch (sortOrder)
                {                   
                    case "Oldest":
                        vm.AccidentReports = vm.AccidentReports.OrderBy(r => r.AccidentDate);
                        break;
                    case "Newest":
                        vm.AccidentReports = vm.AccidentReports.OrderByDescending(r => r.AccidentDate);
                        break;
                    default:
                        vm.AccidentReports = vm.AccidentReports.OrderBy(r => r.AccidentDate);
                        break;
                }
        

            switch (sortUser)
                {                   
                    case "AllUsers":
                        vm.AccidentReports = vm.AccidentReports;
                        break;
                    case "LoggedIn":
                        vm.AccidentReports = vm.AccidentReports.Where(r => r.AccountID == AccountID_);
                        break;
                    default:
                        vm.AccidentReports = vm.AccidentReports;
                        break;
                }

                // AccidentReports = context.AccidentReports
                //     .Where(c => accidentType == 0 || c.AccidentTypeID == accidentType)
                //     .OrderBy(c => c.AccidentReportID)
                //     .Skip((Page - 1) * PageSize)
                //     .Take(PageSize),
                // PaginationHeader = new PaginationHeader
                // {
                //     CurrentPage = Page,
                //     ItemPerPage = PageSize,
                //     TotalItems = accidentType == 0 ?
                //         context.AccidentReports.Count() :
                //         context.AccidentReports.Where(e => e.AccidentTypeID == accidentType).Count()

                // },

                // //AccidentReport(c => c.CollisionID = collision)
                // AccidentTypeID = accidentType

                return View(vm);

        }


        

        /*Drop Downs / Chechboxes / Radio*/

        //Accident Information
        #region Accident Information
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

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getProvinces()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<Province> models = new List<Province>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select ProvinceID, ProvinceName from [Province]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Province();
                                m.ProvinceID = reader.GetInt32(reader.GetOrdinal("ProvinceID"));
                                m.ProvinceName = reader.GetString(reader.GetOrdinal("ProvinceName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "ProvinceID", "ProvinceName");
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
        #endregion

        //Accident Factors
        #region Accident Factors
      
        #endregion

        //Road Factors
        #region Road Factors
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getRoadTypes()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<RoadType> models = new List<RoadType>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select RoadTypeID, RoadTypeName from [RoadType]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new RoadType();
                                m.RoadTypeID = reader.GetInt32(reader.GetOrdinal("RoadTypeID"));
                                m.RoadTypeName = reader.GetString(reader.GetOrdinal("RoadTypeName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "RoadTypeID", "RoadTypeName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getRoadSurfaceNames()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<RoadSurface> models = new List<RoadSurface>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select RoadSurfaceID, RoadSurfaceName from [RoadSurface]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new RoadSurface();
                                m.RoadSurfaceID = reader.GetInt32(reader.GetOrdinal("RoadSurfaceID"));
                                m.RoadSurfaceName = reader.GetString(reader.GetOrdinal("RoadSurfaceName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "RoadSurfaceID", "RoadSurfaceName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getSurfaceConditions()
        {           
            string c = Configuration.GetConnectionString("ProdDB");

            List<SurfaceCondition> models = new List<SurfaceCondition>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select SurfaceConditionID, SurfaceConditionName from [SurfaceCondition]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new SurfaceCondition();
                                m.SurfaceConditionID = reader.GetInt32(reader.GetOrdinal("SurfaceConditionID"));
                                m.SurfaceConditionName = reader.GetString(reader.GetOrdinal("SurfaceConditionName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "SurfaceConditionID", "SurfaceConditionName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getRoadSurfaceQuality()
        {           
            string c = Configuration.GetConnectionString("ProdDB");

            List<RoadSurfaceQuality> models = new List<RoadSurfaceQuality>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select RoadSurfaceQualityID, RoadSurfaceQualityName from [RoadSurfaceQuality]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new RoadSurfaceQuality();
                                m.RoadSurfaceQualityID = reader.GetInt32(reader.GetOrdinal("RoadSurfaceQualityID"));
                                m.RoadSurfaceQualityName = reader.GetString(reader.GetOrdinal("RoadSurfaceQualityName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "RoadSurfaceQualityID", "RoadSurfaceQualityName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getSpeedLimit()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<SpeedLimit> models = new List<SpeedLimit>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select SpeedLimitID, SpeedLimitNumber from [SpeedLimit]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new SpeedLimit();
                                m.SpeedLimitID = reader.GetInt32(reader.GetOrdinal("SpeedLimitID"));
                                m.SpeedLimitNumber = reader.GetString(reader.GetOrdinal("SpeedLimitNumber"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "SpeedLimitID", "SpeedLimitNumber");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getLanes()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<Lane> models = new List<Lane>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select LaneID, LaneName from [Lane]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Lane();
                                m.LaneID = reader.GetInt32(reader.GetOrdinal("LaneID"));
                                m.LaneName = reader.GetString(reader.GetOrdinal("LaneName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "LaneID", "LaneName");
            return userSelect;
        }

         public Microsoft.AspNetCore.Mvc.Rendering.SelectList getRoadFeatures()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<RoadFeature> models = new List<RoadFeature>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select RoadFeatureID, RoadFeatureName from [RoadFeature]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new RoadFeature();
                                m.RoadFeatureID = reader.GetInt32(reader.GetOrdinal("RoadFeatureID"));
                                m.RoadFeatureName = reader.GetString(reader.GetOrdinal("RoadFeatureName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "RoadFeatureID", "RoadFeatureName");
            return userSelect;
        }
        #endregion

        //Driver Information
        #region Driver Information        
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getVehicleType()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<VehicleType> models = new List<VehicleType>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select VehicleTypeID, VehicleTypeName from [VehicleType]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new VehicleType();
                                m.VehicleTypeID = reader.GetInt32(reader.GetOrdinal("VehicleTypeID"));
                                m.VehicleTypeName = reader.GetString(reader.GetOrdinal("VehicleTypeName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "VehicleTypeID", "VehicleTypeName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getVehicleOwner()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<VehicleOwner> models = new List<VehicleOwner>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select VehicleOwnerID, VehicleOwnerType from [VehicleOwner]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new VehicleOwner();
                                m.VehicleOwnerID = reader.GetInt32(reader.GetOrdinal("VehicleOwnerID"));
                                m.VehicleOwnerType = reader.GetString(reader.GetOrdinal("VehicleOwnerType"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "VehicleOwnerID", "VehicleOwnerType");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getLoadConditions()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<LoadCondition> models = new List<LoadCondition>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select LoadConditionID, LoadConditionName from [LoadCondition]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new LoadCondition();
                                m.LoadConditionID = reader.GetInt32(reader.GetOrdinal("LoadConditionID"));
                                m.LoadConditionName = reader.GetString(reader.GetOrdinal("LoadConditionName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "LoadConditionID", "LoadConditionName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getLoadTypes()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<LoadType> models = new List<LoadType>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select LoadTypeID, LoadTypeName from [LoadType]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new LoadType();
                                m.LoadTypeID = reader.GetInt32(reader.GetOrdinal("LoadTypeID"));
                                m.LoadTypeName = reader.GetString(reader.GetOrdinal("LoadTypeName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "LoadTypeID", "LoadTypeName");
            return userSelect;
        }
      
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getLicenceTypes()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<Licence> models = new List<Licence>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select LicenceID, TypeOfLicence from [Licence]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Licence();
                                m.LicenceID = reader.GetInt32(reader.GetOrdinal("LicenceID"));
                                m.TypeOfLicence = reader.GetString(reader.GetOrdinal("TypeOfLicence"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "LicenceID", "TypeOfLicence");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getTrafficViolation()
        {
            string c = Configuration.GetConnectionString("ProdDB");

            List<TypeOfTrafficViolation> models = new List<TypeOfTrafficViolation>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select TypeOfTrafficViolationID, TypeOfTrafficViolationName from [TypeOfTrafficViolation]";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new TypeOfTrafficViolation();
                                m.TypeOfTrafficViolationID = reader.GetInt32(reader.GetOrdinal("TypeOfTrafficViolationID"));
                                m.TypeOfTrafficViolationName = reader.GetString(reader.GetOrdinal("TypeOfTrafficViolationName"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "TypeOfTrafficViolationID", "TypeOfTrafficViolationName");
            return userSelect;
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getVehicleDriverOwner()
        {
            int AccountID_ = 0;
           
            if (signInManager.IsSignedIn(User))
            {
               
                var userId = userManager.GetUserId(User);

                if (acc_context.Accounts != null && acc_context.Accounts.Count() != 0)
                {
                    foreach (var item in acc_context.Accounts.Where(c => c.Id == userId))
                    {
                        AccountID_ = item.AccountID;
                    }
                }
            }

            string c = Configuration.GetConnectionString("ProdDB");

            List<Vehicle> models = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(c))
            {
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    connection.Open();
                    cmd.CommandText = "Select top 2 VehicleID, concat(v.RegistrationNumber, '/', vo.VehicleOwnerType) as [RegistrationNumber]" 
                                + " from [Vehicle] v join VehicleOwner vo on v.VehicleOwnerID = vo.VehicleOwnerID"
                                + " join AccidentReport r on r.AccidentReportID = v.AccidentReportID"
                                + " where r.AccountID = " +  AccountID_.ToString()
                                + " order by r.AccidentReportID desc";

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var m = new Vehicle();
                                m.VehicleID = reader.GetInt32(reader.GetOrdinal("VehicleID"));
                                m.RegistrationNumber = reader.GetString(reader.GetOrdinal("RegistrationNumber"));
                                models.Add(m);
                            }
                        }
                    }
                }
            };

            Microsoft.AspNetCore.Mvc.Rendering.SelectList userSelect = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(models, "VehicleID", "RegistrationNumber");
            return userSelect;
        }

        #endregion

        #region Picture Methods
        private string UploadedAccidentPicture(AccidentReportViewModel model)
        {
            string uniqueFileName = null;

            if (model.AccidentPicture != null)
            {
                string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "users/profiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AccidentPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.AccidentPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        #endregion
       


    }
}