using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.GenreDtos
{
    public class GenreForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Genre name cannot be longer than 50 characters.")]
        public string? Name { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
