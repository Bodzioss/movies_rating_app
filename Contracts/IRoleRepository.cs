using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int roleID);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
    }
}
