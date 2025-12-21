using Microsoft.EntityFrameworkCore;
using Journal.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<JournalEntry> Journals { get; set; }
    public DbSet<User> Users { get; set; }
}