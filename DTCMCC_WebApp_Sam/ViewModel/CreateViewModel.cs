using DTCMCC_WebApp_Sam.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DTCMCC_WebApp_Sam.ViewModel
{
    public class CreateViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Jobs { get; set; }

    }
}
