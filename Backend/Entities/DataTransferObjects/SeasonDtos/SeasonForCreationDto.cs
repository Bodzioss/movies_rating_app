using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.SeasonDtos
{
    public class SeasonForCreationDto
    {
        [Required(ErrorMessage = "Season number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "SeriesID is required")]
        public int SeriesID { get; set; }
    }
}
