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
    public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
    {
        public SeasonRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Season>> GetAllSeasonsAsync()
        {
            return await GetAll().OrderBy(x => x.Number)
                                 .ToListAsync();
        }

        public async Task<Season> GetSeasonByIdAsync(int seasonID)
        {
            return await GetByCondition(x => x.ID.Equals(seasonID)).FirstOrDefaultAsync();
        }

        public void CreateSeason(Season season)
        {
            Create(season);
        }

        public void UpdateSeason(Season season)
        {
            Update(season);
        }

        public void DeleteSeason(Season season)
        {
            Delete(season);
        }

    }
}
