using MedicalManagment.Abstracts;
using MedicalManagment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Controllers
{
    public class AuthController
    {
        private readonly IUserRepository _userRepository;
        public AuthController()
        {
            _userRepository = new UserRepository();
        }
    }
}
