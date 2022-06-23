using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMoviePersonRepository : IRepositoryBase<MoviePerson>
    {
        IEnumerable<MoviePerson> GetAllMoviePerson();
        MoviePerson GetMoviePersonById(int moviePersonID);
        void CreateMoviePerson(MoviePerson moviePerson);
        void UpdateMoviePerson(MoviePerson moviePerson);
        void DeleteMoviePerson(MoviePerson moviePerson);
    }
}
