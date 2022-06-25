using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MovieGenreDtos
{
    public class MovieGenreDto
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }
    }
}
