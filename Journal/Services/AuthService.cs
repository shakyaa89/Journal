using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Journal.Models;
using Journal.Repositories;

namespace Journal.Services
{
    public class AuthService: IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        // Register a new user
        public async Task<bool> RegisterUserAsync(string fullName, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Email and password are required.");

            if(await _authRepository.CheckEmailExistence(email))
                throw new Exception("Email is already registered.");

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.UtcNow
            };

            return await _authRepository.AddUserAsync(user);
        }

        public async Task<User?> LoginUserAsync(string email, string password)
        {
            User? user = await _authRepository.CheckUserExistence(email);
            
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        private User? _currentUser;
        public void SetCurrentUser(User user) => _currentUser = user;
        public User? GetCurrentUser() => _currentUser;
        public void Logout() => _currentUser = null;
    }
}
