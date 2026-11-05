using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.Business
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService()
        {
            _userRepository = new UserRepository();
        }

        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            if (string.IsNullOrEmpty(password))
                return null;

            return _userRepository.GetByCredentials(username, password);
        }

        public void Logout()
        {
            // In the pilot this simply clears the session.
            // In production it would integrate with Entra ID.
        }
    }
}
