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
    public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Episode> GetAllEpisodes()
        {
            return GetAll().OrderBy(x => x.Season.Number).OrderBy(x => x.Number).ToList();
        }

        public Episode GetEpisodeById(int episodeID)
        {
            return GetByCondition(x => x.ID.Equals(episodeID))
            .FirstOrDefault();
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
