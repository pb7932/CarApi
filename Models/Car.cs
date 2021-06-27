using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} lenght must be between {2} and {1}", MinimumLength = 2)]
        [Remote(action: "VerifyUniqueName", controller: "Cars")]
        public string name { get; set; }

        public int price { get; set; }

        [Required]
        public int power { get; set; }
    }
}