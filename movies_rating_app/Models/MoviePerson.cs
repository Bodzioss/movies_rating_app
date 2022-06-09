using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesRatingApp.API.Models
{
    public class MoviePerson
    {
        public int ID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int MovieID { get; set; }
        [JsonIgnore]
        [ForeignKey("PersonID")]
        public virtual Person? Person { get; set; }
        [JsonIgnore]
        [ForeignKey("MovieID")]
        public virtual Movie? Movie { get; set; }

    }
}
