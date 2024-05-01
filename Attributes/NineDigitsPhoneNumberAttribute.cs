using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Attributes
{
    public class NineDigitsPhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = (string)value;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return ValidationResult.Success;
            }

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace(".", "");

            if (!long.TryParse(phoneNumber, out _))
            {
                return new ValidationResult("Phone number can only contain digits.");
            }

            if (phoneNumber.Length != 9)
            {
                return new ValidationResult("Phone number must have exactly 9 digits.");
            }

            return ValidationResult.Success;
        }
    }
}
