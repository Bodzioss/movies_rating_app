using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISeriesRepository : IRepositoryBase<Series>
    {
        Task<IEnumerable<Series>> GetAllSeriesAsync();
        Task<Series> GetSeriesByIdAsync(int seriesID);
        void CreateSeries(Series series);
        void UpdateSeries(Series series);
        void DeleteSeries(Series series);
    }
}
