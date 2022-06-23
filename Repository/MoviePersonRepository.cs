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

        public void CreateMoviePerson(MoviePerson moviePerson)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoviePerson(MoviePerson moviePerson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MoviePerson> GetAllMoviePerson()
        {
            throw new NotImplementedException();
        }

        public MoviePerson GetMoviePersonById(int moviePersonID)
        {
            throw new NotImplementedException();
        }

        public void UpdateMoviePerson(MoviePerson moviePerson)
        {
            throw new NotImplementedException();
        }
    }
}
