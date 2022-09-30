using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTCMCC_WebApp_Sam.Models
{
    public class Cuti
    {
        [Key]
        public int Id { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public int LamaCuti { get; set; }
        public string Status { get; set; }
    }
}
