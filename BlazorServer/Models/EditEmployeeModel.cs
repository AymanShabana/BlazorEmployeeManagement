using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class EditEmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First name must be provided")]
        [MinLength(2, ErrorMessage = "First name cannot be shorter than 2 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name must be provided")]
        [MinLength(2, ErrorMessage = "Last name cannot be shorter than 2 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email must be provided")]
        [EmailValidator]
        public string Email { get; set; }
        [CompareProperty("Email",ErrorMessage ="Email and compare email must match.")]
        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage = "Date of birth must be provided")]
        public DateTime DateOfBrith { get; set; }
        [Required(ErrorMessage = "Gender must be provided")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Department must be provided")]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
