using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;
using Journal.Models;

namespace Journal.Services
{
    public class AuthService
    {
        private readonly AppDbContext db_context;

        public AuthService(AppDbContext context)
        {
            db_context = context;
        }

        // Register a new user
        public async Task<User> RegisterUser(string fullName, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Email and password are required.");

            // Check if email already exists
            if (await db_context.Users.AnyAsync(u => u.Email == email))
                throw new Exception("Email already registered.");

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.UtcNow
            };

            db_context.Users.Add(user);
            await db_context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            var user = await db_context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {

                return user;
            }
            return null;
        }

        private User? _currentUser;
        public void SetCurrentUser(User user) => _currentUser = user;
        public User? GetCurrentUser() => _currentUser;
        public void Logout() => _currentUser = null;
    }
}
