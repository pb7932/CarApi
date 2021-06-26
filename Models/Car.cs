using System.ComponentModel.DataAnnotations;

namespace CarApi.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; }

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