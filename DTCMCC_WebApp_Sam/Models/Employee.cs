using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTCMCC_WebApp_Sam.Models
{
    public class Employee
    {
    
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName ("First Name")]
        public string FirstName { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
       
        public Jobs Jobs { get; set; }
        [ForeignKey("Jobs")]
        public int JobsId { get; set; }

    }
}
