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
            throw new NotImplementedException();
        }

        public Genre GetGenreById(int genreID)
        {
            throw new NotImplementedException();
        }

        public void CreateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void UpdateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
