using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Genre name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
