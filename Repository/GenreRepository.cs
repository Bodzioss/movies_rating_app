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
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return GetAll().OrderBy(x => x.Name).ToList();
        }

        public Genre GetGenreById(int genreID)
        {
            return GetByCondition(x => x.ID.Equals(genreID))
            .FirstOrDefault();
        }

        public void CreateGenre(Genre genre)
        {
            Create(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            Update(genre);
        }

        public void DeleteGenre(Genre genre)
        {
            Delete(genre);
        }
    }
}
