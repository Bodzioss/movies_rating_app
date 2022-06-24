using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.GenreDtos
{
    public class GenreDto
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        //public virtual ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
