using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class MoviePerson
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "PersonID is required")]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "MovieID is required")]
        public int MovieID { get; set; }
        [JsonIgnore]
        [ForeignKey("PersonID")]
        public virtual Person? Person { get; set; }
        [JsonIgnore]
        [ForeignKey("MovieID")]
        public virtual Movie? Movie { get; set; }

    }
}
