// IJournalRepository

using Journal.Models;

namespace Journal.Repositories

{
    public interface IJournalRepository
    {
        Task<JournalEntry> AddJournalEntryAsync(JournalEntry entry);
        Task<List<JournalEntry>> FetchJournalEntriesAsync(int userId);
        Task<JournalEntry?> FetchJournalByIdAsync(int journalId);
        Task<bool> DeleteJournalEntry(int journalId);
    }
}
