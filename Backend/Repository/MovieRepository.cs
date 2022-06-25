using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await GetAll().OrderBy(x => x.ID)
                                 .ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int movieID)
        {
            return await GetByCondition(x => x.ID.Equals(movieID)).FirstOrDefaultAsync();
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
