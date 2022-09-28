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
        public IEnumerable<Department> Departments { get; set; }
        public int JobsId { get; set; }
        public IEnumerable<Jobs> Jobs { get; set; }
    }
}
