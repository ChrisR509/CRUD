using MedicalManagment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalManagment.Abstracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        ValueTask<IEnumerable<Role>> GetRoles();
        ValueTask<bool> AddRoleAsync(Role role);
    }
}
