using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Series
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        public String? Description { get; set; }
        [Required(ErrorMessage = "Start year is required")]
        [Range(1800,2100)]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }
        [Range(1800, 2100)]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
        [JsonIgnore]
        public virtual ICollection<Season>? Seasons { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
        [JsonIgnore]
        public virtual ICollection<MoviePerson>? MoviePeople { get; set; }
        


    }
}
