using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MovieGenreDtos
{
    public class MovieGenreForCreationDto
    {
        [Required(ErrorMessage = "MovieID is required")]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "GenreID is required")]
        public int GenreID { get; set; }

    }
}
