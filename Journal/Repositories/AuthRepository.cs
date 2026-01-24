using Microsoft.EntityFrameworkCore;
using Journal.Models;

namespace Journal.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExistence(string email) => await _context.Users.AnyAsync(u => u.Email == email);
        

        public async Task<User?> CheckUserExistence(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (existingUser == null) return false;

                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
