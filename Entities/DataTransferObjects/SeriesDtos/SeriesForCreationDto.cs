using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.SeriesDtos
{
    public class SeriesForCreationDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string? Title { get; set; }
        public String? Description { get; set; }
        [Required(ErrorMessage = "Start year is required")]
        [Range(1800, 2100)]
        public int StartYear { get; set; }
        [Range(1800, 2100)]
        public int EndYear { get; set; }
    }
}
