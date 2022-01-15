using MedicalManagment.Abstracts;
using MedicalManagment.Models;
using MedicalManagment.Repository;
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
        public async ValueTask<(bool, User, string)> VerifyUser(string userName, string password)
        {
            try
            {
                var currentUser = await _userRepository.GetUserAsync(userName);
                if (currentUser == null) return (false, null, "Usuario no encontrado");
                if (currentUser.Password != password) return (false, null, "Contraseña incorrecta.");
                else return (true, currentUser, null);
            }
            catch (System.Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
