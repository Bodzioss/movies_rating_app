using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesRatingApp.API.Models
{
    public class MovieGenre
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        [JsonIgnore]
        [ForeignKey("MovieID")]
        public virtual Movie? Movie { get; set; }
        [JsonIgnore]
        [ForeignKey("GenreID")]
        public virtual Genre? Genre { get; set; }

    }
}
