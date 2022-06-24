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

        public IEnumerable<Series> GetAllSeries()
        {
            return GetAll().OrderBy(x => x.Title).ToList();
        }

        public Series GetSeriesById(int seriesID)
        {
            return GetByCondition(x => x.ID.Equals(seriesID))
            .FirstOrDefault();
        }

        public void CreateSeries(Series series)
        {
            Create(series);
        }

        public void UpdateSeries(Series series)
        {
            Update(series);
        }

        public void DeleteSeries(Series series)
        {
            Delete(series);
        }

    }
}
