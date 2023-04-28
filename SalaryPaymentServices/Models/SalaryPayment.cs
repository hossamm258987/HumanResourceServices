using System.ComponentModel.DataAnnotations;

namespace SalaryPaymentServices.Models
{
    public class SalaryPayment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpId { get; set; }

        [MaxLength(250, ErrorMessage ="Description Must be Less Than 250 Charchtar")]
        public string Description { get; set; }

        public double IncentiveAmount { get; set; }

        public double NetSalary { get; set; }
        public double Tax { get; set; }

        [Required]
        public DateTime SalaryPayment_DT { get; set; }

        [Required]
        public int Month { get; set; }
    }
}
