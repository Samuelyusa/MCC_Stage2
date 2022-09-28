using DTCMCC_WebApp_Sam.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class AccountController : Controller
    { 
        HttpClient HttpClient;
        string address;
        public AccountController()
        {
            this.address = "https://localhost:4432/api/Account";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
