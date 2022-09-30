using System.ComponentModel.DataAnnotations;

namespace DTCMCC_WebApp_Sam.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
