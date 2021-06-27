using System.ComponentModel.DataAnnotations;
using CarApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Dtos
{
    public class CarCreateDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0} lenght must be between {2} and {1}", MinimumLength = 2)]
        [Remote(action: "VerifyUnique", controller: "Cars")]

        public string name { get; set; }

        [Required]
        [PriceRangeValidator(200)]
        public int price { get; set; }

        [Required]
        public int power { get; set; }
    }
}