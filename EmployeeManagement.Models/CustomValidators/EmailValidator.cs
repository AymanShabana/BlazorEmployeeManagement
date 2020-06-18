using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex re = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (re.IsMatch(value.ToString()))
            {
                return null;
            }
            return new ValidationResult("Email format must be valid.", new[] { validationContext.MemberName });
        }
    }
}
