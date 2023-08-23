using System;
using System.ComponentModel.DataAnnotations;
namespace AirportBooking.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTimeValue)
            {
                return dateTimeValue > DateTime.Now;
            }
            return false;
        }
    }
}
