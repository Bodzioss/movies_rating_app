using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.SeasonDtos
{
    public class SeasonDto
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int SeriesID { get; set; }
    }
}
