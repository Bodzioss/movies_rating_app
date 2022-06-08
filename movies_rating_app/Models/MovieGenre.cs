using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.API.Models
{
    public class MovieGenre
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }

    }
}
