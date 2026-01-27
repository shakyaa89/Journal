using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;


namespace Journal.Utils
{
    public class Util
    {
        public static string GetMoodIcon(string moods)
        {
            List<string> positiveMoods = ["Happy", "Excited", "Relaxed", "Grateful", "Confident"];
            List<string> neutralMoods = ["Calm", "Thoughtful", "Curious", "Nostalgic", "Bored"];
            List<string> negativeMoods = ["Sad", "Angry", "Stressed", "Lonely", "Anxious"];

            if (positiveMoods.Contains(moods))
                return "fa-face-smile";
            else if (neutralMoods.Contains(moods))
                return "fa-face-meh";
            else if (negativeMoods.Contains(moods))
                return "fa-face-frown";

            return "fa-face-smile";
        }

        public static int GetWordCount(string? html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return 0;

            var text = Regex.Replace(html, "<.*?>", " ");
            text = Regex.Replace(text, @"\s+", " ").Trim();

            return string.IsNullOrEmpty(text) ? 0 : text.Split(' ').Length;
        }
    }
}
