using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LocaFilme.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            // 0 ==> Corresponds a not selected value for Membership type ID
            // 1 ==> Corresponds Pay As You Go Membership type ID
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate field must be filled");

            //var age = (DateTime.Today.Subtract(customer.Birthdate))/365;
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be at least 18 years old to go on a membership.");
        }
    }
}