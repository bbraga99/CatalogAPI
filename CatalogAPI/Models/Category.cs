using CatalogAPI.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogAPI.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();   
        }

        [Key]
        public int CategoryId { get; set; }

        [FirstLetterUpperValidation]
        [Required]
        public string? Name { get; set; }
        public string? ImagemUrl { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; } // definindo relacionamento 1 para muitos
    }
}
