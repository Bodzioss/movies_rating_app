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
    public class MovieGenreRepository : RepositoryBase<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<MovieGenre>> GetAllMovieGenresAsync()
        {
            return await GetAll().OrderBy(x => x.ID)
                                 .ToListAsync();
        }

        public async Task<MovieGenre> GetMovieGenreByIdAsync(int movieGenreID)
        {
            return await GetByCondition(x => x.ID.Equals(movieGenreID)).FirstOrDefaultAsync();
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
