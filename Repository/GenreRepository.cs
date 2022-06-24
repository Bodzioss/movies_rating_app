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
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await GetAll().OrderBy(x => x.Name)
                                 .ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int genreID)
        {
            return await GetByCondition(x => x.ID.Equals(genreID)).FirstOrDefaultAsync();
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
