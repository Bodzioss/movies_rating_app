using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRatingApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [ForeignKey("Id")]
        //public Director DirectorID { get; set; }
        //public int GenreID { get; set; }
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public String? Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public int MovieLength { get; set; }
    }
}
