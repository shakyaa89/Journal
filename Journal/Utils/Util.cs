using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Utils
{
    public class Util
    {
        public static string GetMoodIcon(string moods)
        {
            List<string> positiveMoods = new List<string> { "Happy", "Excited", "Relaxed", "Grateful", "Confident" };
            List<string> neutralMoods = new List<string> { "Calm", "Thoughtful", "Curious", "Nostalgic", "Bored" };
            List<string> negativeMoods = new List<string> { "Sad", "Angry", "Stressed", "Lonely", "Anxious" };

            if (positiveMoods.Contains(moods))
                return "fa-face-smile";
            else if (neutralMoods.Contains(moods))
                return "fa-face-meh";
            else if (negativeMoods.Contains(moods))
                return "fa-face-frown";

            return "fa-face-smile";
        }
    }
}
