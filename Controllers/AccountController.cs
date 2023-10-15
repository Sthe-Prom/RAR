using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;
using RestSharp;

namespace rar.Controllers
{
    // [Authorize(Roles = "Applicant")]
    public class AccountController : Controller
    {
        //private properties      
        private IAccount context;
        private IAddress ctx_context;
        private readonly IWebHostEnvironment HostEnvironment;
        public BaseViewModel BaseViewModel { get; set; }
        private IConfiguration Configuration;

        //public string strConn = @"Server=196.255.240.74;Database=iinfo;MultipleActiveResultSets=true;User ID=Sthembiso;password=IIS123";
        public string strConn = @"Server=156.38.224.15;Database=UserDB2;MultipleActiveResultSets=true;User ID=xslicwih_ms_admin;password=#21MsDBUser@";

        //public string sCampusServer = Configuration.GetConnectionString("Data:rar2:ConnectionString").ToString();

        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        //Const
        public AccountController(IAccount ctx, IWebHostEnvironment he,
                               SignInManager<User> s_man, UserManager<User> u_man, IConfiguration configuration, IAddress ctx_context_)
        {
            context = ctx;
            HostEnvironment = he;
            signInManager = s_man;
            userManager = u_man;
            ctx_context = ctx_context_;

            this.BaseViewModel = new BaseViewModel();
            this.BaseViewModel.Accounts = context.Accounts;
            this.ViewData["BaseViewModel"] = this.BaseViewModel;
            this.Configuration = configuration;
        }
      
        public ViewResult Index()
        {           
            ProfileAddressViewModel vm = new ProfileAddressViewModel();
            vm.Accounts = context.Accounts;
            vm.Addresses = ctx_context.Addresses;
            return View(vm);
        }

        [HttpGet]
        public ViewResult myprofile()
        {
            // var userId = userManager.GetUserId(User);
            // ViewData["Msg"] = "Cant Get User ID";

            // if(signInManager.IsSignedIn(User))                                                 
            // {
            //     //var userId = user.Id;
            //     return View(context.Accounts.Where(c => c.Id == userId));
            // }   
            // else
            // {
            //     return View(context.Accounts);
            // } 

            // return View(context.Accounts);

            ProfileAddressViewModel vm = new ProfileAddressViewModel();
            vm.Accounts = context.Accounts;
            vm.Addresses = ctx_context.Addresses;

            return View(vm);
        }

        //public IActionResult Profile() => View();

        [HttpGet]
        public IActionResult Profile()
        {
            ProfileAddressViewModel vm = new ProfileAddressViewModel()
            {                
                Users = getUsers(),
                Accounts = context.Accounts
            };
            

            return View(vm);
        }
      
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileAddressViewModel vm)
        {
            //Prepare variables to get the token
            var client = new RestClient("https://rest.smsportal.com");

            var authToken = "";

            var apiKey = "0a7d5eee-0f6f-434b-9382-fff7aed20e65";
            var apiSecret = "+KveFafDFRLN6ZPGGSahCTkLNS9Ff1+T";
            var accountApiCred = $"{apiKey}:{apiSecret}";

            //Convert (keys and secrets) to Base64
            var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(accountApiCred);
            var base64Credentials = Convert.ToBase64String(plaintextBytes);

            //Request for authentication TOKEN
            var authRequest = new RestRequest("/v1/Authentication", Method.GET);
            authRequest.AddHeader("Authorization", $"Basic {base64Credentials}");

            //Authenticate (with keys and secrets) To ask for TOKEN!
            var authResponse = client.Execute(authRequest);

            //Check respose if (TOKEN) was granted from request (Success or Fail)
            if (authResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var authResponseBody = JObject.Parse(authResponse.Content);

                authToken = authResponseBody["token"].ToString();

            }
            // else
            // {
            //     HttpContext.Response.Write(authResponse.ErrorMessage);
            //     return;              
            // }

            //Prepare Send request to send SMS via [TOKEN]
            var sendRequest = new RestRequest("/v1/bulkmessages", Method.POST);
            var authHeader = $"Bearer {authToken}";
            sendRequest.AddHeader("Authorization", $"{authHeader}");


            sendRequest.AddJsonBody(new
            {
                Messages = new[]
                {
                    new
                    {
                        content = "SMS Test..",
                        destination = "0791962740",
                        LandingPageVariables = new
                        {
                            LandingPageId = "20220219160334351"
                        }
                    }
                }

            });


            string uploadedProfileImage = UploadedProfileImg(vm);
            string UploadedIdDoc = UploadedIdentityDoc(vm);           

            if (uploadedProfileImage == null)
            {
                uploadedProfileImage = "Upload is null";
            }

            string UserID_ = "";

            if (signInManager.IsSignedIn(User))
            {
                UserID_ = User.Identity.Name;
            }

            var Account = new Account
            {
                Name = vm.ProfileModel.Name,
                Surname = vm.ProfileModel.Surname,
                Email = vm.ProfileModel.Email,
                ProfileImg = uploadedProfileImage,
                Cell = vm.ProfileModel.Cell,
                Id = vm.ProfileModel.Id,
                MarriageDoc = "No Doc",
                IdentityDoc = UploadedIdDoc,
                MaritalStatus = "Not Applicable",//vm.ProfileModel.MaritalStatus,
                FullAddress = vm.ProfileModel.FullAddress
            };

            if (ModelState.IsValid)
            {
                context.SaveAccount(Account);

                //Send SMS (request)
                var sendResponse = client.Execute(sendRequest);


                return RedirectToAction("Address", "Address");
            }
            else
            {
                return View("Profile");
            }
        }

        //UPDATE
        [HttpGet]
        public ViewResult Edit(int AccountID)
        {
            ProfileAddressViewModel vm = new ProfileAddressViewModel();
            vm.ProfileModel.Users = getUsers();
            //Accounts = context.Accounts            

            Account Account = context.Accounts.FirstOrDefault(c => c.AccountID == AccountID);

            string UploadedProfileImage = UploadedProfileImg(vm);
            string UploadedIdDoc = UploadedIdentityDoc(vm);

            vm.ProfileModel.Name = Account.Name;
            vm.ProfileModel.Surname = Account.Surname;
            vm.ProfileModel.Email = Account.Email;
            UploadedProfileImage = Account.ProfileImg;
            vm.ProfileModel.Cell = Account.Cell;
            vm.ProfileModel.Id = Account.Id;
            vm.ProfileModel.MarriageDoc = Account.MarriageDoc;
            UploadedIdDoc = Account.IdentityDoc;
            vm.ProfileModel.MaritalStatus = Account.MaritalStatus;
            vm.ProfileModel.FullAddress = Account.FullAddress;

            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileAddressViewModel vm)
        {
            string uploadedProfileImage = UploadedProfileImg(vm);
            string UploadedIdDoc = UploadedIdentityDoc(vm);

            if (uploadedProfileImage == null)
            {
                uploadedProfileImage = "Upload is null";
            }

            var Account = context.Accounts.FirstOrDefault(c => c.AccountID == vm.ProfileModel.AccountID);
            if (Account != default(Account))
            {
                Account.Name = vm.ProfileModel.Name;
                Account.Surname = vm.ProfileModel.Surname;
                Account.Email = vm.ProfileModel.Email;
                Account.Cell = vm.ProfileModel.Cell;
                Account.ProfileImg = uploadedProfileImage;
                Account.Id = vm.ProfileModel.Id;
                Account.IdentityDoc = UploadedIdDoc;
                Account.MaritalStatus = vm.ProfileModel.MaritalStatus;
                Account.MarriageDoc = "Not Applicable";
                Account.FullAddress = vm.ProfileModel.FullAddress;
            }

            try
            {
                if (ModelState.IsValid)
                {
                    context.SaveAccount(Account);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(vm);
                }
            }
            catch
            {
                return View(vm);
            }
        }

        //DELETE
        public IActionResult Delete(int AccountID)
        {
            Account Account = context.DeleteAccount(AccountID);

            if (Account != null)
            {
                TempData["message"] = $"Account {Account.Name} was deleted";
            }

            return RedirectToAction("Index");
        }

        private string UploadedProfileImg(ProfileAddressViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileModel.ProfileImg != null)
            {
                string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "users/profiles");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileModel.ProfileImg.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileModel.ProfileImg.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        private string UploadedIdentityDoc(ProfileAddressViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileModel.IdentityDoc != null)
            {
                string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "users/identity");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileModel.IdentityDoc.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileModel.IdentityDoc.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList getUsers()
        {
            //string c = Configuration.GetValue<string>("Data:UserDB2:ConnectionString");
            string c = Configuration.GetConnectionString("ProdDB");
            //string c = Configuration.GetConnectionString("ProdDB");

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

    }


}

