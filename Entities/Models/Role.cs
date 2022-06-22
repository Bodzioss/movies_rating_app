using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Role name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person>? People { get; set; }
    }
}
