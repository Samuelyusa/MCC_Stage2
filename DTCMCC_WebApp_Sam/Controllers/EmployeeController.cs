using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using DTCMCC_WebApp_Sam.Models;
using System;
using DTCMCC_WebApp_Sam.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DTCMCC_WebApp_Sam.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class EmployeeController : Controller
    {
        MyContext myContext;
        

        public EmployeeController( MyContext myContext)
        {
            this.myContext = myContext;
        }

        //Read
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Employees.Include(x => x.Department).Include(y => y.Jobs).ToList();
            return View(data);
        }

        [HttpGet]
        //GET CREATE
        public IActionResult Create()
        {
            CreateViewModel createViewModel = new CreateViewModel();
            createViewModel.Employee = new Employee();
            List<SelectListItem> departments = myContext.Departments
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem
                {
                    Value = n.DepartmentId.ToString(),
                    Text = n.Name
                }).ToList();
            createViewModel.Departments = departments;

            createViewModel.Employee = new Employee();
            List<SelectListItem> jobs = myContext.Jobs
                .OrderBy(n => n.JobTitle)
                .Select(n => new SelectListItem
                {
                    Value = n.JobtId.ToString(),
                    Text = n.JobTitle
                }).ToList();
            createViewModel.Jobs = jobs;


            return View(createViewModel);
        } 
       

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Add(employee);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //Read By ID
        //GET
        [HttpGet]
        public IActionResult Details(int? id)
        {
            //Employee employee = myContext.Employees.Find(id);
            var employee = myContext.Employees.FirstOrDefault(x => x.EmployeeId == id);

            return View(employee);
        }

        //UPDATE GET
        public IActionResult Edit(int id)
        {
            var employee = myContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            
            CreateViewModel createViewModel = new CreateViewModel();
            
            createViewModel.Employee = new Employee();

            createViewModel.Employee.FirstName = employee.FirstName;
            createViewModel.Employee.DepartmentId = employee.DepartmentId;
            createViewModel.Employee.JobsId = employee.JobsId;

            List<SelectListItem> departments = myContext.Departments
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem
                {
                    Value = n.DepartmentId.ToString(),
                    Text = n.Name
                }).ToList();
            createViewModel.Departments = departments;

            //createViewModel.Employee = new Employee();
            List<SelectListItem> jobs = myContext.Jobs
                .OrderBy(n => n.JobTitle)
                .Select(n => new SelectListItem
                {
                    Value = n.JobtId.ToString(),
                    Text = n.JobTitle
                }).ToList();
            createViewModel.Jobs = jobs;

            return View(createViewModel);
        }

        //UPDATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Update(employee);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int? id, bool? saveChangesError = false)
        {
            var employee = myContext.Employees
                .AsNoTracking()
                .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = myContext.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                myContext.Employees.Remove(employee);
                myContext.SaveChanges();
                
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
