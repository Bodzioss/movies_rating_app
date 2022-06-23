using System;
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
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPersonById(int personID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
