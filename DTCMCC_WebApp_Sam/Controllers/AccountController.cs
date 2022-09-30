using DTCMCC_WebApp_Sam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class AccountController : Controller
    { 
        HttpClient HttpClient;
        string addressLogin, addressRegist, addressForgotPassword;
        public AccountController()
        {
            this.addressLogin = "https://localhost:44321/api/Account/Login";
            this.addressRegist = "https://localhost:44321/api/Account/Register";
            this.addressForgotPassword = "https://localhost:44321/api/Account/ForgotPassword";
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(addressLogin)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(addressLogin, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.data.Role);
                if (HttpContext.Session.GetString("Role").Equals("Admin"))
                    return RedirectToAction("Index", "AdminPanel");
                //RouteValueDictionary dict = new RouteValueDictionary();
                //dict.Add("LoginStaffId", data.data.Id);
                var logId = data.data.Id;
                TempData["logId"] = logId;
                return RedirectToAction("Index", "StaffPanel");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(addressRegist)
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(addressRegist, content).Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(addressForgotPassword)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(forgotPassword), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(addressForgotPassword, content).Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Login", "Account");
            return View();
        }
    }
}
