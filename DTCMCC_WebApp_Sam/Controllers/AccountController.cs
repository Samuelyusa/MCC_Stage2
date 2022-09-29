using DTCMCC_WebApp_Sam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        string addressLogin, addressRegist;
        public AccountController()
        {
            this.addressLogin = "https://localhost:44321/api/Account/Login";
            this.addressRegist = "https://localhost:44321/api/Account/Register";
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
                return RedirectToAction("Index", "Home");
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
    }
}
