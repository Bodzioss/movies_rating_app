using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
        IEnumerable<Movie> GetAllMovie();
        Movie GetMovieById(int movieID);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
    }
}
