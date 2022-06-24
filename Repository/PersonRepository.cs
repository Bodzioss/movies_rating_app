using System;
using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await GetAll().OrderBy(x => x.LastName)
                           .OrderBy(x => x.FirstName)
                           .ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personID)
        {
            return await GetByCondition(x => x.ID.Equals(personID)).FirstOrDefaultAsync();
        }

        public void CreatePerson(Person person)
        {
            Create(person);
        }

        public void UpdatePerson(Person person)
        {
            Update(person);
        }

        public void DeletePerson(Person person)
        {
            Delete(person);
        }


    }
}
