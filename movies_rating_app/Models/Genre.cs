using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesRatingApp.API.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Genre name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
