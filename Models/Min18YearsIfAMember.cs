using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthdayDate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.UtcNow.Year - customer.BirthdayDate.Value.Year;

            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Member should be greter than oe equal to 18 years.");
        }
    }
}