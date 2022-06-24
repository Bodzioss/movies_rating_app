using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.SeriesDtos
{
    public class SeriesDto
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public String? Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

    }
}
