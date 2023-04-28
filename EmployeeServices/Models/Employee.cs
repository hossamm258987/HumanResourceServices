using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeServices.Models
{
    public class Employee
    {
        //Personal Inforamtion
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "The Name Must be Less Than 80 Charachtar")]
        public string Name { get; set; }

        [Required]
        public byte Gender { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return (int)DateTime.Now.Year - (int)DoB.Year;
            }
        }

        [Required]
        [MaxLength(14, ErrorMessage = "The National Number Must Less Than 14")]
        public string NationalNumber { get; set; }

        [MaxLength(14, ErrorMessage = "The SNN Must Less Than 14")]
        public string SNN { get; set; }

        //Address Inforamtion
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string Street { get; set; }

        [MaxLength(5)]
        public string PostalCode { get; set; }

        //Contact Information
        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }

        [MaxLength(50, ErrorMessage = "Email Must be Less Than 50 Charachtar")]
        public string Email { get; set; }

        //Ward Information
        public int DepartmentId { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }

        //Salary Inforamtion
        public double Salary { get; set; }
        public double Factor { get; set; }
        public double InsuranceTax { get; set; }

        //Education Inforamtion
        public string Certificates { get; set; }
        public byte YearsofExperience { get; set; }

        public bool IsActive { get; set; }
    }
}
