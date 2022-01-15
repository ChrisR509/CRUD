using MedicalManagment.Abstracts;
using MedicalManagment.Models;
using MedicalManagment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Controllers
{
    public class RoleController
    {
        private readonly IRoleRepository roleRepository;
        public RoleController()
        {
            roleRepository = new RoleRepository();
        }
        public async ValueTask<IEnumerable<Role>> GetRolesAsync()
        {
            return await roleRepository.GetRoles();
        }
        public async ValueTask<bool> AddRoleAsync(Role role)
        {
            return await roleRepository.AddRoleAsync(role);
        }
    }
}
