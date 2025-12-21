using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Journal.Models;

namespace Journal
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=JournalDb;Username=journaluser;Password=Hello123");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
