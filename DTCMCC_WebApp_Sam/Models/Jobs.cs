using System.ComponentModel.DataAnnotations;

namespace DTCMCC_WebApp_Sam.Models
{
    public class Jobs
    {
        [Key]
        public int JobtId { get; set; }
        public string JobTitle { get; set; }
    }
}
