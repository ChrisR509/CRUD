using MedicalManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Abstracts
{
    public interface IUserRepository : IRepository<User>
    {
        public ValueTask<IEnumerable<User>> GetUsers();
    }
}
