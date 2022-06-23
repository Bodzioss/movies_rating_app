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

        public void CreateSeason(Season season)
        {
            throw new NotImplementedException();
        }

        public void DeleteSeason(Season season)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Season> GetAllSeasons()
        {
            throw new NotImplementedException();
        }

        public Season GetSeasonById(int seasonID)
        {
            throw new NotImplementedException();
        }

        public void UpdateSeason(Season season)
        {
            throw new NotImplementedException();
        }
    }
}
