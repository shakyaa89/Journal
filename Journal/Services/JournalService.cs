using Journal.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Services
{
    public class JournalService
    {
        private readonly AppDbContext _context;

        public JournalService(AppDbContext context)
        {
            _context = context;
        }

        // Add a new journal entry
        public async Task<JournalEntry> AddJournalEntryAsync(string title, string content, string mood, string secondaryMood1, string secondaryMood2, int userId)
        {
            var journal = new JournalEntry
            {
                Title = title,
                Content = content,
                Mood = mood,
                SecondaryMood1 = secondaryMood1,
                SecondaryMood2 = secondaryMood2,
                UserId = userId
            };

            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();

            return journal;
        }


        // Get all journal entries
        public async Task<List<JournalEntry>> GetAllJournalsAsync(int userId)
        {
            var journals = await _context.Journals
                             .Where(j => j.UserId == userId)
                             .ToListAsync();
            return journals;
        }


        // Get single journal by ID
        public JournalEntry? GetJournalById(int id)
        {
            return _context.Journals.Find(id);
        }

        // Update a journal entry
        public bool UpdateJournal(JournalEntry journal)
        {
            _context.Journals.Update(journal);
            return _context.SaveChanges() > 0;
        }

        // Delete a journal entry
        public bool DeleteJournal(int id)
        {
            var journal = _context.Journals.Find(id);
            if (journal == null) return false;

            _context.Journals.Remove(journal);
            return _context.SaveChanges() > 0;
        }
    }
}
