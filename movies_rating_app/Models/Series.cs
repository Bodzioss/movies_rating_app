using System.ComponentModel.DataAnnotations;

namespace MoviesRatingApp.API.Models
{
    public class Series
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        [Required]
        public int GenreID { get; set; }

        [Range(1800,2100)]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }
        [Range(1800, 2100)]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
    }
}
