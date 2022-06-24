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
        public IEnumerable<Role> GetAllRoles()
        {
            return GetAll().OrderBy(x => x.Name).ToList();
        }

        public Role GetRoleById(int roleID)
        {
            return GetByCondition(x => x.ID.Equals(roleID))
            .FirstOrDefault();
        }

        public void CreateRole(Role role)
        {
            Create(role);
        }

        public void UpdateRole(Role role)
        {
            Update(role);
        }

        public void DeleteRole(Role role)
        {
            Delete(role);
        }

    }
}
