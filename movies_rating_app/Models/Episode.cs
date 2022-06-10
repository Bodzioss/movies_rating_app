using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesRatingApp.API.Models
{
    public class Episode
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title name cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "SeasonID is required")]
        [ForeignKey("SeasonID")]
        public int SeasonID { get; set; }

        [JsonIgnore]
        public virtual Season? Season { get; set; }
    }
}
