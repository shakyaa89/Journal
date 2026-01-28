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
            try
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
            catch
            {
                System.Diagnostics.Debug.WriteLine("Error registering user.");
                return false;
            }
        }

        // Login user
        public async Task<User?> LoginUserAsync(string email, string password)
        {
            try
            {
                User? user = await _authRepository.CheckUserExistence(email);
            
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    string userString = System.Text.Json.JsonSerializer.Serialize(user);
                    await SecureStorage.SetAsync("user", userString);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Error logging in user.");
                return null;
            }
        }

        // Update user details
        public async Task<bool> UpdateUser(User user) => await _authRepository.UpdateUserAsync(user);

        // Get current logged-in user
        public async Task<User?> GetCurrentUser()
        {
            try
            {
                string userString = await SecureStorage.GetAsync("user") ?? "";
                if (!string.IsNullOrEmpty(userString))
                {
                    User? storageUser = System.Text.Json.JsonSerializer.Deserialize<User>(userString);
                    return storageUser;
                }

                return null;
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Error retrieving current user.");
                return null;
            }
        }
        // Logout user
        public void LogoutUser() => SecureStorage.Remove("user");
        
    }
}
