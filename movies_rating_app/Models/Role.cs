using System.ComponentModel.DataAnnotations;

namespace MoviesRatingApp.API.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Role name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
