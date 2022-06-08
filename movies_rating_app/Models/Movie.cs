using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.API.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public String? Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,1000)]
        [Display(Name = "Movie Length")]
        public int MovieLength { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
    }
}
