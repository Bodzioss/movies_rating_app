using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public String? Title { get; set; }
        public String? Description { get; set; }
        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1,1000)]
        [Display(Name = "Movie Length")]
        public int MovieLength { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
        [JsonIgnore]
        public virtual ICollection<MoviePerson>? MoviePeople { get; set; }
    }
}
