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
        Task<IEnumerable<MoviePerson>> GetAllMoviePeopleAsync();
        Task<MoviePerson> GetMoviePersonByIdAsync(int moviePersonID);
        void CreateMoviePerson(MoviePerson moviePerson);
        void UpdateMoviePerson(MoviePerson moviePerson);
        void DeleteMoviePerson(MoviePerson moviePerson);
    }
}
