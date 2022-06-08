using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.API.Models
{
    public class MoviePerson
    {
        public int ID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int MovieID { get; set; }

    }
}
