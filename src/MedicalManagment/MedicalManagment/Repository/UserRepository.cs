using MedicalManagment.Abstracts;
using MedicalManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base("sp_GetUsers")
        {

        }

        public async ValueTask<User> GetUserAsync(string userName)
        {
            var result = await GetAsync(u => u.UserName == userName, "sp_GetUser");
            return result;
        }

        public async ValueTask<IEnumerable<User>> GetUsers()
        {
            var result = await All;
            return result;
        }

    }
}
