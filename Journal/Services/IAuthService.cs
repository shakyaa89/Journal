using Journal.Models;

namespace Journal.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(string fullName, string email, string password);

        Task<User?> LoginUserAsync(string email, string password);

        Task<User?> GetCurrentUser();

        void LogoutUser();

        Task<bool> UpdateUser(User user);
    }
}
