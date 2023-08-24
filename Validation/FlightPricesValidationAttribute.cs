using System.ComponentModel.DataAnnotations;
using AirportBooking.Models;
namespace AirportBooking.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FlightPricesValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IDictionary<FlightClass, decimal> classPrices)
            {
                if (classPrices.Count == 0)
                {
                    return new ValidationResult(ErrorMessage);
                }

                if (classPrices.Values.Any(price => price <= 0))
                {
                    return new ValidationResult("Prices must be greater than 0.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid property type.");
        }
    }
}
