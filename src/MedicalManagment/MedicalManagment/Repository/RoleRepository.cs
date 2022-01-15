using MedicalManagment.Abstracts;
using MedicalManagment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalManagment.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository() : base("sp_GetRoles")
        {
        }

        public async ValueTask<bool> AddRoleAsync(Role role)
        {
            try
            {
                return await CreateAsync($"INSERT INTO [Role] VALUES (NEWID(), ${role.IsCreated}, ${role.CreatedBy}, ${role.CreatedOn}, ${role.IsUpdated}, ${role.UpdatedBy}, ${role.UpdatedOn}, ${role.IsDeleted}, ${role.DeletedBy}, ${role.DeletedOn}, ${role.RoleName});");
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<IEnumerable<Role>> GetRoles()
        {
            var result = await All;
            return result;
        }
    }
}
