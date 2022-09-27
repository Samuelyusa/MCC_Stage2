using DTCMCC_WebApp_Sam.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DTCMCC_WebApp_Sam.ViewModel
{
    public class UpdateViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        //public IEnumerable<SelectListItem> Departments { get; set; }
        public Department DepartmentId { get; set; }
        //public IEnumerable<SelectListItem> Jobs { get; set; }
        public Jobs JobsId { get; set; }
    }
}
