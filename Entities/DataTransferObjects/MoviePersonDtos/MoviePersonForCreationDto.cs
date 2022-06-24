using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MoviePersonDtos
{
    public class MoviePersonForCreationDto
    {
        [Required(ErrorMessage = "PersonID is required")]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "MovieID is required")]
        public int MovieID { get; set; }
    }
}
