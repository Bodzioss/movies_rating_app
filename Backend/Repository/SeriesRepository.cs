using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Series>> GetAllSeriesAsync()
        {
            return await GetAll().OrderBy(x => x.Title)
                                 .ToListAsync();
        }

        public async Task<Series> GetSeriesByIdAsync(int seriesID)
        {
            return await GetByCondition(x => x.ID.Equals(seriesID)).FirstOrDefaultAsync();
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
