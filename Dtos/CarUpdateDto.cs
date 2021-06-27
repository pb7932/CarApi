using System.ComponentModel.DataAnnotations;
using CarApi.Validators;

namespace CarApi.Dtos
{
    public class CarUpdateDto
    {
        [Required]
        [PriceRangeValidator(200)]
        public int price { get; set; }

        [Required]
        public int power { get; set; }
    }
}