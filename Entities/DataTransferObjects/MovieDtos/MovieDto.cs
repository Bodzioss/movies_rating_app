using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MovieDtos
{
    public class MovieDto
    {
        public int ID { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int MovieLength { get; set; }

    }
}
