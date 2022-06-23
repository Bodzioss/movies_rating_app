using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.EpisodeDtos
{
    public class EpisodeForUpdateDto
    {
        [Required(ErrorMessage = "Episode number is required")]
        [Range(0, 100)]
        public int Number { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title name cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "SeasonID is required")]
        public int SeasonID { get; set; }
    }
}
