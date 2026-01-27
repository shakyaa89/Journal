using Journal.Models;

namespace Journal.Services
{
    public interface IJournalService
    {
        Task<JournalEntry> AddJournalEntryAsync(string title, string content, string mood, string secondaryMood1, string secondaryMood2, List<string>? tags, int wordCount, int userId);
        Task<List<JournalEntry>> GetAllJournalsAsync(int userId);
        Task<JournalEntry?> GetJournalByIdAsync(int id);
        Task<bool> DeleteJournalAsync(int id);
        Task<JournalEntry?> UpdateJournalEntryAsync(int id,string title,string content,string mood,string secondaryMood1,string secondaryMood2, List<string>? tags, int userId, int wordCount, DateTime updatedAt);
    }
}
