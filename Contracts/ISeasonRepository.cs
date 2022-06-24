using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISeasonRepository : IRepositoryBase<Season>
    {
        Task<IEnumerable<Season>> GetAllSeasonsAsync();
        Task<Season> GetSeasonByIdAsync(int seasonID);
        void CreateSeason(Season season);
        void UpdateSeason(Season season);
        void DeleteSeason(Season season);
    }
}
