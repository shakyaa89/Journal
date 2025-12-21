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
        public JournalEntry AddJournalEntry(string title, string content, string mood, int userId)
        {
            var journal = new JournalEntry
            {
                Title = title,
                Content = content,
                Mood = mood,
                UserId = userId
            };

            _context.Journals.Add(journal);
            _context.SaveChanges();

            return journal;
        }

        // Get all journal entries
        public List<JournalEntry> GetAllJournals(int userId)
        {
            return _context.Journals
                .Where(j => j.UserId == userId)
                .OrderByDescending(j => j.CreatedAt)
                .ToList();
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
