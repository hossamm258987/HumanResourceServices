using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeductionServices.Models
{
    public class Deduction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpId { get; set; }

        [Required]
        public DateTime Deduction_DT { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage ="Name Must be Less Than 60 Charachtar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Description Must be Less Than 60 Charachtar")]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        public bool IsActive { get; set; }
    }
}
