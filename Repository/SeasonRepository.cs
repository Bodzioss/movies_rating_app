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
    public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
    {
        public SeasonRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Season> GetAllSeasons()
        {
            return GetAll().OrderBy(x => x.Number).ToList();
        }

        public Season GetSeasonById(int seasonID)
        {
            return GetByCondition(x => x.ID.Equals(seasonID))
            .FirstOrDefault();
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
