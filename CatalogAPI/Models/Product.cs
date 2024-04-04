using CatalogAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [FirstLetterUpperValidation]
        public string? Name { get; set; }
        public string? Descricao { get; set; }

        [Required]
        public double Price { get; set; }
        public string? ImagelUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime Register { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
