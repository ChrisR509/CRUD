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
    public class UserController
    {
        private readonly IUserRepository _repository;
        public UserController()
        {
            _repository = new UserRepository();
        }
        public async ValueTask<IEnumerable<User>> GetAll()
        {
            return await _repository.GetUsers();
        }
    }
}
