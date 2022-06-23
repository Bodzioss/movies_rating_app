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
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void CreateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int roleID)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
