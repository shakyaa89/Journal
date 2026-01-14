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
    }
}
