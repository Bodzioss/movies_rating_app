using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SeriesRepository : RepositoryBase<Series>, ISeriesRepository
    {
        public SeriesRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreateSeries(Series series)
        {
            throw new NotImplementedException();
        }

        public void DeleteSeries(Series series)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Series> GetAllSeries()
        {
            throw new NotImplementedException();
        }

        public Series GetSeriesById(int seriesID)
        {
            throw new NotImplementedException();
        }

        public void UpdateSeries(Series series)
        {
            throw new NotImplementedException();
        }
    }
}
