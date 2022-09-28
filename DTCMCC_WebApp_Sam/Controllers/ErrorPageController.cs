using Microsoft.AspNetCore.Mvc;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
