using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MovieDtos
{
    public class MovieForCreationDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public String? Title { get; set; }
        public String? Description { get; set; }
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        [Range(1, 1000)]
        public int MovieLength { get; set; }
    }
}
