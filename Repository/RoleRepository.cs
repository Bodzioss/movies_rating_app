using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await GetAll().OrderBy(x => x.Name)
                                 .ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int roleID)
        {
            return await GetByCondition(x => x.ID.Equals(roleID)).FirstOrDefaultAsync();
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
