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
    public class MovieGenreRepository : RepositoryBase<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreateMovieGenre(MovieGenre movieGenre)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovieGenre(MovieGenre movieGenre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieGenre> GetAllMovieGenres()
        {
            throw new NotImplementedException();
        }

        public MovieGenre GetMovieGenreById(int movieGenreID)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovieGenre(MovieGenre movieGenre)
        {
            throw new NotImplementedException();
        }
    }
}
