using Journal.Models;

namespace Journal.Repositories

{
    public interface IAuthRepository
    {
        Task<bool> CheckEmailExistence(string email);
        Task<User?> CheckUserExistence(string email);
        Task<bool> AddUserAsync(User user);

        Task<bool> UpdateUserAsync(User user);
    }
}
