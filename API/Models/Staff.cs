using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
