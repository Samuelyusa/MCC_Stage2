using System.ComponentModel.DataAnnotations;

namespace DTCMCC_WebApp_Sam.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
