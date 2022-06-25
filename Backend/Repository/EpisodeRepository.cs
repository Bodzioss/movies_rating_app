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
    public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Episode>> GetAllEpisodesAsync()
        {
            return await GetAll().OrderBy(x => x.Season.Number)
                                 .OrderBy(x => x.Number)
                                 .ToListAsync();
        }

        public async Task<Episode> GetEpisodeByIdAsync(int episodeID)
        {
            return await GetByCondition(x => x.ID.Equals(episodeID)).FirstOrDefaultAsync();
        }

        public void CreateEpisode(Episode episode)
        {
            Create(episode);
        }

        public void UpdateEpisode(Episode episode)
        {
            Update(episode);
        }

        public void DeleteEpisode(Episode episode)
        {
            Delete(episode);
        }
    }
}
