using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesRatingApp.API.Models
{
    public class Season
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        [Required]
        public int SeriesID { get; set; }
        [JsonIgnore]
        [ForeignKey("SeriesID")]
        public virtual Series? Series { get; set; }
        [JsonIgnore]
        public virtual ICollection<Episode>? Episodes { get; set; }
    }
}
