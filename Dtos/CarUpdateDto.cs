using System.ComponentModel.DataAnnotations;

namespace CarApi.Dtos
{
    public class CarUpdateDto
    {
        [Required]
        public int price { get; set; }

        [Required]
        public int power { get; set; }
    }
}