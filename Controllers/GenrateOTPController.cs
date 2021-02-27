using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Net;
using System.Web;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Net.Http;
using RestSharp;
using System.Net.Http.Headers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using CoreWepAPI.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using CoreWepAPI.RSA;
using Microsoft.AspNetCore.Identity;

namespace CoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class GenrateOTPController :TwilioController 
    {

        private readonly IRsaHelper _rsaHelper;
       
        public const string SessionKeyName = "_OTP";

        private readonly SMSApplication _SMSSettings;

        private readonly ApplicationUserModel _ApplicationUser;

        private readonly AuthenticationContext _Context;

        private UserManager<ApplicationUser> _userManager;

        //  public const string SessionKeyName="";
        public  GenrateOTPController(UserManager<ApplicationUser> userManager,IOptions<SMSApplication> SMSSettings, AuthenticationContext Context, IRsaHelper rsaHelper)
        {
            _userManager = userManager;
            _rsaHelper = rsaHelper;

            _SMSSettings = SMSSettings.Value;

//            _ApplicationUser = ApplicationUser.Value;

            _Context = Context;
        }

        public object Configuration { get; private set; }

        [Route("CreateOTP")]
        [HttpPost]


        public  ActionResult GenrateOTP(SMSApplication SMSModel)
        {

            var Number = _Context.addStudentDetails.Where(a => a.ASD_PhoneNo == SMSModel.ToNumber).ToList();
            
            if (Number.Count == 0)
            {
                return Ok("0");

            }

           




            string num = "0123456789";
            int len = num.Length;
            string OTP = string.Empty;
            int OTPDigit = 4;
            string FinalDigit;
            int getIndex;

            for (int i = 0; i < OTPDigit; i++)
            {
                do
                {
                    getIndex = new Random().Next(0, len);
                    FinalDigit = num.ToCharArray()[getIndex].ToString();
                } while (OTP.IndexOf(FinalDigit) != -1);
                OTP += FinalDigit;


            }

           
            var accountsid = _SMSSettings.UserName;//"ACdb6c8eb26449187c76afe22fc845631d"; //ConfigurationManager.AppSettings["UserName"];
            var authtoken = _SMSSettings.Password; //"616af29b7ea8a863ada5cf1c0cf8fb02"; //_SMSSettings.Password; 

            TwilioClient.Init(accountsid, authtoken);
            var to = new PhoneNumber("+91"+SMSModel.ToNumber);
            var from = new PhoneNumber(_SMSSettings.FromNumber);

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Your one Time Password is :" + OTP);

            //  HttpContext.Session.SetString(SessionKeyName, OTP);
            // return Content(message.Sid);
         //   ViewData["OTPNumber"] = OTP;
         //if(string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
         //   {
         //       HttpContext.Session.SetString("Key",OTP);
                
         //      // HttpContext.Session.SetInt32(SessionKeyName, OTP);
         //   }

            var clearTextOTP = _rsaHelper.Encrypt(OTP);
            var sucess = "4444";

            var data =
            (
             
           Token: clearTextOTP, 
           Sucess:sucess
            );
            //   string  OTPNo = HttpContext.Session.GetString("Key");
            return Ok(data);
        }

        [Route("VerifyOTP")]
        [HttpPost]

        public async Task<Object>  VerifyOTP(SMSApplication SMSModel)
        {
            var UserRegister = _Context.addStudentDetails.Where(a => a.ASD_UserName == SMSModel.UserRegisterNo).ToList();
              if (UserRegister.Count == 0)
            {
                return Ok("0");

            }


            //  string OTPNo ;
            //if (HttpContext.Session.GetString("Key") !=null)
            //{
            // OTPNo = HttpContext.Session.GetString("Key");
            var DrycptOTP  = _rsaHelper.Decrypt(SMSModel.SendOTP);

            if (SMSModel.OTPNumber == DrycptOTP)
                {
                //update query

                //  ApplicationUser UpdateData = _Context.ApplicationUsers.SingleOrDefault(x => x.PhoneNumber == SMSModel.UserRegisterNo);
                var UpdateData = await _userManager.FindByNameAsync(SMSModel.UserRegisterNo);
                var newpassword = _userManager.PasswordHasher.HashPassword(UpdateData, SMSModel.UserPassword);
                //  var ResetPassword= _userManager.ResetPasswordAsync(SMSModel.UserRegisterNo,SMSModel.Password);
                UpdateData.PasswordHash = newpassword;
                IdentityResult result = await _userManager.UpdateAsync(UpdateData);
                //_Context.SaveChanges();


                return Ok("1");
                }
          //  }
          else
            {
                return Ok("0");
            }
                
                
           
            

        }

        //   String result;

        //const string url = @"https://api.twilio.com/2010-04-01/Accounts/ACdb6c8eb26449187c76afe22fc845631d";

        //const string UserName = @"ACdb6c8eb26449187c76afe22fc845631d";
        //const string Password = @"616af29b7ea8a863ada5cf1c0cf8fb02";

        //var httpClient = new HttpClient();
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        //    AuthenticationSchemes.Basic.ToString(),
        //    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{UserName}:{Password}")));

        //var response = await httpClient.GetAsync($"{url}/Messages.json?From=+13342319024&To=+919870603429&Body=" +OTP);
        //response.EnsureSuccessStatusCode();
        //var r = await response.Content.ReadAsStringAsync();
        //var client = new RestClient("https://api.twilio.com/2010-04-01/Accounts/ACdb6c8eb26449187c76afe22fc845631d/Messages.json?access_token=ACdb6c8eb26449187c76afe22fc845631d&args=616af29b7ea8a863ada5cf1c0cf8fb02");
        //var request = new RestRequest(Method.POST);
        //request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //request.AddParameter("application/x-www-form-urlencoded", "From=+13342319024&To=+919870603429&Body=" + OTP);
        //IRestResponse response = client.Execute(request);

        //using (var httpClient = new HttpClient())
        //{
        //    {


        //    }
        //    using (var response = await httpClient.GetAsync("https://api.twilio.com/2010-04-01/Accounts/ACdb6c8eb26449187c76afe22fc845631d:616af29b7ea8a863ada5cf1c0cf8fb02/Messages.json"))
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //       // reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
        //    }
        //}
        //string apiKey = "BfuqdT/Hn5U-fKNAHLGb8tyWP7uDK7YZ9WeWF9nw0i";
        //string numbers = "919870603429"; // in a comma seperated list
        //string message = "Your One Time Password " + OTP;
        //string sender = "TXTLCL";

        //String url = "https://api.textlocal.in/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
        ////refer to parameters to complete correct url string

        //StreamWriter myWriter = null;
        //HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

        //objRequest.Method = "POST";
        //objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
        //objRequest.ContentType = "application/x-www-form-urlencoded";
        //try
        //{
        //    myWriter = new StreamWriter(objRequest.GetRequestStream());
        //    myWriter.Write(url);
        //}
        //catch (Exception e)
        //{
        //    return e.Message;
        //}
        //finally
        //{
        //    myWriter.Close();
        //}

        //HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        //{
        //    result = sr.ReadToEnd();
        //    // Close and clean up the StreamReader
        //    sr.Close();
        //}




        // return  Ok(OTP);
        //  Session["OTP"] = OTP;

        // Session["h"] = OTP;


        //    return OTPDigit;

    }
}