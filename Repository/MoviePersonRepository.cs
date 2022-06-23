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
    public class MoviePersonRepository : RepositoryBase<MoviePerson>, IMoviePersonRepository
    {
        public MoviePersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
        public IEnumerable<MoviePerson> GetAllMoviePerson()
        {
            return GetAll().OrderBy(x => x.ID).ToList();
        }

        public MoviePerson GetMoviePersonById(int moviePersonID)
        {
            return GetByCondition(x => x.ID.Equals(moviePersonID))
            .FirstOrDefault();
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
