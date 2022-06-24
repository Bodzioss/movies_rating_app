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
        Task<IEnumerable<MovieGenre>> GetAllMovieGenresAsync();
        Task<MovieGenre> GetMovieGenreByIdAsync(int movieGenreID);
        void CreateMovieGenre(MovieGenre movieGenre);
        void UpdateMovieGenre(MovieGenre movieGenre);
        void DeleteMovieGenre(MovieGenre movieGenre);
    }
}
