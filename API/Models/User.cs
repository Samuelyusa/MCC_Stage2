using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        [Key]
        public Staff Staff { get; set; }
        [ForeignKey("Staff")]
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
