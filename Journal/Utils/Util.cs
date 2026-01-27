using System.Text.RegularExpressions;


namespace Journal.Utils
{
    public class Util
    {
        // Get the appropriate icon for a given mood
        public static string GetMoodIcon(string moods)
        {
            List<string> positiveMoods = ["Happy", "Excited", "Relaxed", "Grateful", "Confident"];
            List<string> neutralMoods = ["Calm", "Thoughtful", "Curious", "Nostalgic", "Bored"];
            List<string> negativeMoods = ["Sad", "Angry", "Stressed", "Lonely", "Anxious"];

            // Return icon based on mood category
            if (positiveMoods.Contains(moods))
                return "fa-face-smile";
            else if (neutralMoods.Contains(moods))
                return "fa-face-meh";
            else if (negativeMoods.Contains(moods))
                return "fa-face-frown";

            return "fa-face-smile";
        }

        // Calculate word count from HTML content
        public static int GetWordCount(string? html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return 0;

            // Remove HTML tags and count words
            var text = Regex.Replace(html, "<.*?>", " ");
            text = Regex.Replace(text, @"\s+", " ").Trim();

            return string.IsNullOrEmpty(text) ? 0 : text.Split(' ').Length;
        }
    }
}
