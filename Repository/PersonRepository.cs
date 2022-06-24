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
        public IEnumerable<Person> GetAllPeople()
        {
            return GetAll().OrderBy(x => x.LastName).OrderBy(x => x.FirstName).ToList();
        }

        public Person GetPersonById(int personID)
        {
            return GetByCondition(x => x.ID.Equals(personID))
            .FirstOrDefault();
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
