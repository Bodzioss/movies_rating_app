using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMovieGenreRepository : IRepositoryBase<MovieGenre>
    {
        IEnumerable<MovieGenre> GetAllMovieGenres();
        MovieGenre GetMovieGenreById(int movieGenreID);
        void CreateMovieGenre(MovieGenre movieGenre);
        void UpdateMovieGenre(MovieGenre movieGenre);
        void DeleteMovieGenre(MovieGenre movieGenre);
    }
}
