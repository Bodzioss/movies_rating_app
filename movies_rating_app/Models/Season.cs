using System.ComponentModel.DataAnnotations;

namespace MoviesRatingApp.API.Models
{
    public class Season
    {
        public int ID { get; set; }
        public int Number { get; set; }
        [Required]
        public int SeriesID { get; set; }
    }
}
