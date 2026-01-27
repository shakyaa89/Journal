using Journal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Services
{
    public interface IAnalyticsService
    {
        Dictionary<string, double> GetMoodDistribution(List<JournalEntry> entries);

        public string? GetMostFrequentMood(List<JournalEntry> entries);

        public int GetCurrentDailyStreak(List<JournalEntry> entries);

        public int GetLongestStreak(List<JournalEntry> entries);

        public List<DateTime> GetMissedDays(List<JournalEntry> entries);

        Dictionary<string, double> GetAverageWordCountPerDay(List<JournalEntry> entries);

        Dictionary<string, int> GetTagFrequency(List<JournalEntry> entries);

    }
}
