using System.ComponentModel.DataAnnotations;

namespace AttendaceServices.Models
{
    public class Attendace
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpId { get; set; }

        [Required]
        public DateTime Attendace_DT { get; set; }

        [Required]
        public bool IsPresent { get; set; }
    }
}
