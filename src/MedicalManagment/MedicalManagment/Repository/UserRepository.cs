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

        public async ValueTask<IEnumerable<User>> GetUsers()
        {
            await OpenConnection();
            var result = await All;
            await CloseConnection();
            return result;
        }

    }
}
