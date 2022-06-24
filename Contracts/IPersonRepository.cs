using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int personID);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
