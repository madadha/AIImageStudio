using System.Globalization;
using System.Windows.Controls;

namespace SmartChat.WPF.Helpers
{
    public class RequiredFieldRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "This field is required.");
            }

            return ValidationResult.ValidResult;
        }
    }
}