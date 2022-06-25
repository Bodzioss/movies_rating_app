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
    public class MoviePersonRepository : RepositoryBase<MoviePerson>, IMoviePersonRepository
    {
        public MoviePersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
        public async Task<IEnumerable<MoviePerson>> GetAllMoviePeopleAsync()
        {
            return await GetAll().OrderBy(x => x.ID)
                                 .ToListAsync();
        }

        public async Task<MoviePerson> GetMoviePersonByIdAsync(int moviePersonID)
        {
            return await GetByCondition(x => x.ID.Equals(moviePersonID)).FirstOrDefaultAsync();
        }

        public void CreateMoviePerson(MoviePerson moviePerson)
        {
            Create(moviePerson);
        }

        public void UpdateMoviePerson(MoviePerson moviePerson)
        {
            Update(moviePerson);
        }

        public void DeleteMoviePerson(MoviePerson moviePerson)
        {
            Delete(moviePerson);
        }


    }
}
