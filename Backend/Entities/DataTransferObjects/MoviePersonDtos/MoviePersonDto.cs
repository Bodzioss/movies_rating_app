using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.MoviePersonDtos
{
    public class MoviePersonDto
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int MovieID { get; set; }
    }
}
