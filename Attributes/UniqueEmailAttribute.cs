using ContactManagement.Data;
using ContactManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var email = (string)value;

            var currentContactId = (validationContext.ObjectInstance as ContactModel)?.Id;

            if (dbContext.contactModel.Any(c => c.Email == email && c.Id != currentContactId))
            {
                return new ValidationResult("This email is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}