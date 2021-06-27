using System.ComponentModel.DataAnnotations;
using CarApi.Dtos;
using CarApi.Models;

namespace CarApi.Validators
{
    public class PriceRangeValidatorAttribute : ValidationAttribute
    {
        public PriceRangeValidatorAttribute(int price)
        {
            Price = price;
        }

        public int Price { get; }

        public string GetErrorMessage() => $"Price needs to be greater than {Price}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = (CarCreateDto)validationContext.ObjectInstance;
            var carPrice = (int)value;

            if (carPrice < Price)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}