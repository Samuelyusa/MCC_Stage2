using DTCMCC_WebApp_Sam.Context;
using DTCMCC_WebApp_Sam.Models;
using DTCMCC_WebApp_Sam.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class StaffPanelController : Controller
    {
        MyContext myContext;

        public StaffPanelController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var loginId = Convert.ToInt16(TempData["logId"]);
            var staff = myContext.Staff.Where(x => x.Id == loginId).FirstOrDefault();

            return View(staff);
        }
        [HttpGet]
        public IActionResult RequestCuti(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestCuti(Cuti cuti)
        {
            if (ModelState.IsValid)
            {
                

                myContext.Cuti.Add(cuti);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
    }
}
