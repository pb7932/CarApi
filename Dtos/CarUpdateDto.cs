using System.ComponentModel.DataAnnotations;

namespace CarApi.Dtos
{
    public class CarUpdateDto
    {
        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string name { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public int power { get; set; }
    }
}