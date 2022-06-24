using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEpisodeRepository : IRepositoryBase<Episode>
    {
        IEnumerable<Episode> GetAllEpisodes();
        Episode GetEpisodeById(int episodeID);
        void CreateEpisode(Episode episode);
        void UpdateEpisode(Episode episode);
        void DeleteEpisode(Episode episode);
    }
}
