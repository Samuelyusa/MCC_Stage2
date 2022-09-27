using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class EmployeeDetailViewModel
    {
       public Employee employee { get; set; }

       public Department department { get; set; }

       public Jobs jobs { get; set; }
    }
}
