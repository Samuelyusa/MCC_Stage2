using DTCMCC_WebApp_Sam.Context;
using DTCMCC_WebApp_Sam.Models;
using DTCMCC_WebApp_Sam.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class AdminPanelController : Controller
    {
        MyContext myContext;
        HttpClient HttpClient;
        string addressCuti;
        public AdminPanelController(MyContext myContext)
        {
            this.myContext = myContext;
            this.addressCuti = "https://localhost:44321/api/Account/Cuti";
        }
        [HttpGet]
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Admin"))
            {
                var data = myContext.Cuti.Include(x => x.Staff).ToList();
                return View(data);
            }
                
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        //UPDATE GET
        public IActionResult Approve(int? id)
        {
            var staffCuti = myContext.Cuti.Where(x => x.Id == id)
                .FirstOrDefault();
            return View(staffCuti);
        }

        //UPDATE
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(int Id)
        {
            var staffCuti = myContext.Cuti.Where(x => x.Id == Id)
                .FirstOrDefault();
            staffCuti.Id = Id;
            staffCuti.Status = "Approved";
            staffCuti.StaffId = staffCuti.StaffId;

            if (ModelState.IsValid)
            {
                myContext.Cuti.Update(staffCuti);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //UPDATE GET
        public IActionResult Decline(int? id)
        {
            var staffCuti = myContext.Cuti.Where(x => x.Id == id)
                .FirstOrDefault();
            //CutiViewModel viewModel = new CutiViewModel()
            //{
            //    FullName = staffCuti.Staff.FullName,
            //    LamaCuti = staffCuti.LamaCuti
            //};
            return View(staffCuti);
        }

        //UPDATE
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Decline(int Id)
        {
            var staffCuti = myContext.Cuti.Where(x => x.Id == Id)
                .FirstOrDefault();
            staffCuti.Id = Id;
            staffCuti.Status = "Declined";
            staffCuti.StaffId = staffCuti.StaffId;

            if (ModelState.IsValid)
            {
                myContext.Cuti.Update(staffCuti);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
