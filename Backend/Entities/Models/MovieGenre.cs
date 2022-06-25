using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class MovieGenre
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "MovieID is required")]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "GenreID is required")]
        public int GenreID { get; set; }

        [JsonIgnore]
        [ForeignKey("MovieID")]
        public virtual Movie? Movie { get; set; }
        [JsonIgnore]
        [ForeignKey("GenreID")]
        public virtual Genre? Genre { get; set; }

    }
}
