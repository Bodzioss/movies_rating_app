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

        public IEnumerable<MovieGenre> GetAllMovieGenres()
        {
            return GetAll().OrderBy(x => x.ID).ToList();
        }

        public MovieGenre GetMovieGenreById(int movieGenreID)
        {
            return GetByCondition(x => x.ID.Equals(movieGenreID))
            .FirstOrDefault();
        }

        public void CreateMovieGenre(MovieGenre movieGenre)
        {
            Create(movieGenre);
        }
        public void UpdateMovieGenre(MovieGenre movieGenre)
        {
            Update(movieGenre);
        }

        public void DeleteMovieGenre(MovieGenre movieGenre)
        {
            Delete(movieGenre);
        }


    }
}
