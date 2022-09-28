using API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public int DepartmentId { get; set; }
        public int JobsId { get; set; }

        public List<EmployeeViewModel> Employees = new List<EmployeeViewModel>();
    }
}
