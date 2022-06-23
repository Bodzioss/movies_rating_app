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
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            return GetAll().OrderBy(x => x.ID).ToList();
        }

        public Movie GetMovieById(int movieID)
        {
            return GetByCondition(x => x.ID.Equals(movieID))
            .FirstOrDefault();
        }

        public void CreateMovie(Movie movie)
        {
            Create(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            Update(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            Delete(movie);
        }


    }
}
