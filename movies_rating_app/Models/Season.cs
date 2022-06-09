using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.API.Models
{
    public class Season
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        [Required]
        public int SeriesID { get; set; }
        [ForeignKey("SeriesID")]
        public virtual Series? Series { get; set; }
        public virtual ICollection<Episode>? Episodes { get; set; }
    }
}
