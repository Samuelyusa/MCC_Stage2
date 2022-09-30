using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cuti
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public int? LamaCuti { get; set; }
        public string Status { get; set; }
    }
}
