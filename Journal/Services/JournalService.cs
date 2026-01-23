using Microsoft.EntityFrameworkCore;
using Journal.Models;
using Journal.Repositories;
using System.Diagnostics;

namespace Journal.Services
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository _journalRepository;

        public JournalService(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<JournalEntry> AddJournalEntryAsync(string title, string content, string mood, string secondaryMood1, string secondaryMood2, List<string>? tags, int userId)
        {
            var journal = new JournalEntry
            {
                Title = title,
                Content = content,
                Mood = mood,
                SecondaryMood1 = secondaryMood1,
                SecondaryMood2 = secondaryMood2,
                Tags = tags,
                UserId = userId
            };

            return await _journalRepository.AddJournalEntryAsync(journal);
        }


        // Get all journal entries
        public async Task<List<JournalEntry>> GetAllJournalsAsync(int userId)
        {
            return await _journalRepository.FetchJournalEntriesAsync(userId);
        }


        // Get single journal by ID
        public async Task<JournalEntry?> GetJournalByIdAsync(int id)
        {
            return await _journalRepository.FetchJournalByIdAsync(id);
        }

        // Delete a journal entry
        public async Task<bool> DeleteJournalAsync(int id)
        {
            return await _journalRepository.DeleteJournalEntry(id);
        }

        public async Task<JournalEntry?> UpdateJournalEntryAsync(
            int id,
            string title,
            string content,
            string mood,
            string secondaryMood1,
            string secondaryMood2,
            List<string>? tags,
            int userId,
            DateTime updatedAt)
        {
            var existing = await _journalRepository.FetchJournalByIdAsync(id);
            if (existing == null || existing.UserId != userId)
                return null;

            existing.Title = title;
            existing.Content = content;
            existing.Mood = mood;
            existing.SecondaryMood1 = secondaryMood1;
            existing.SecondaryMood2 = secondaryMood2;
            existing.Tags = tags;
            existing.UpdatedAt = updatedAt;

            return await _journalRepository.UpdateJournalEntryAsync(existing);
        }

    }
}


