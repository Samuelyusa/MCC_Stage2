using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Jobs
    {
        [Key]
        public int JobtId { get; set; }
        public string JobTitle { get; set; }
    }
}
