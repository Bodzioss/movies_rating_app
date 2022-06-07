using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [ForeignKey("Id")]
        public int DirectorID { get; set; }
        public int GenreID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public String? Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Year")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,1000)]
        [Display(Name = "Movie Length")]
        public int MovieLength { get; set; }
    }
}
