using API.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ViewModel
{
    public class UpdateViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        
        public string FirstName { get; set; }

        //public Department Department { get; set; }
        
        public int DepartmentId { get; set; }

        //public Jobs Jobs { get; set; }
        
        public int JobsId { get; set; }
    }
}
