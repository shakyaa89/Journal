using Journal.Models;

namespace Journal.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        public Dictionary<string, double> GetMoodDistribution(
            List<JournalEntry> entries)
        {
            var positiveMoods = new List<string>
            {
                "Happy", "Excited", "Relaxed", "Grateful", "Confident", "Calm"
            };

            var neutralMoods = new List<string>
            {
                "Thoughtful", "Curious", "Nostalgic", "Bored"
            };

            var negativeMoods = new List<string>
            {
                "Sad", "Angry", "Stressed", "Lonely", "Anxious"
            };

            int positive = 0;
            int neutral = 0;
            int negative = 0;

            foreach (var entry in entries)
            {
                if (string.IsNullOrWhiteSpace(entry.Mood))
                    continue;

                if (positiveMoods.Contains(entry.Mood))
                    positive++;
                else if (neutralMoods.Contains(entry.Mood))
                    neutral++;
                else if (negativeMoods.Contains(entry.Mood))
                    negative++;
            }

            int total = positive + neutral + negative;
            if (total == 0) total = 1;

            return new Dictionary<string, double>
            {
                { "Positive", Math.Round(positive * 100.0 / total, 2) },
                { "Neutral",  Math.Round(neutral  * 100.0 / total, 2) },
                { "Negative", Math.Round(negative * 100.0 / total, 2) }
            };
        }

        public string? GetMostFrequentMood(List<JournalEntry> entries)
        {
            return entries
                .Where(e => !string.IsNullOrWhiteSpace(e.Mood))
                .GroupBy(e => e.Mood)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()
                ?.Key;
        }

        public int GetCurrentDailyStreak(List<JournalEntry> entries)
        {
            if (entries == null || entries.Count == 0)
                return 0;

            var today = DateTime.UtcNow.Date;

            var daysWithEntries = entries
                .Select(e => e.CreatedAt.Date)
                .Distinct()
                .ToHashSet();

            int streak = 0;
            var current = today;

            while (daysWithEntries.Contains(current))
            {
                streak++;
                current = current.AddDays(-1);
            }

            return streak;
        }

        public int GetLongestStreak(List<JournalEntry> entries)
        {
            if (entries == null || entries.Count == 0)
                return 0;

            var dates = entries
                .Select(e => e.CreatedAt.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            int longest = 0;
            int current = 0;
            DateTime? prev = null;

            foreach (var date in dates)
            {
                if (prev == null || date == prev.Value.AddDays(1))
                {
                    current++;
                }
                else
                {
                    current = 1;
                }

                if (current > longest)
                    longest = current;

                prev = date;
            }

            return longest;
        }

        public List<DateTime> GetMissedDays(List<JournalEntry> entries)
        {
            var result = new List<DateTime>();

            if (entries == null || entries.Count == 0)
                return result;

            var datesWithEntries = entries
                .Select(e => e.CreatedAt.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            var start = datesWithEntries.First();
            var end = DateTime.UtcNow.Date;

            var set = datesWithEntries.ToHashSet();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                if (!set.Contains(dt))
                    result.Add(dt);
            }

            return result;
        }

    }
}
