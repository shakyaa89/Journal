// JournalRepository

using Microsoft.EntityFrameworkCore;
using Journal.Models;

namespace Journal.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly AppDbContext _context;

        public JournalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JournalEntry> AddJournalEntryAsync(JournalEntry entry)
        {
            await _context.Journals.AddAsync(entry);
            await _context.SaveChangesAsync();

            return entry;
        }

        public async Task<List<JournalEntry>> FetchJournalEntriesAsync(int userId)
        {
            return await _context.Journals
                     .Where(j => j.UserId == userId)
                     .ToListAsync();
        }

        public async Task<JournalEntry?> FetchJournalByIdAsync(int journalId)
        {
            return await _context.Journals.FindAsync(journalId);
        }

        public async Task<bool> DeleteJournalEntry(int journalId)
        {
            var journal = _context.Journals.Find(journalId);
            if (journal == null) return false;

            _context.Journals.Remove(journal);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
