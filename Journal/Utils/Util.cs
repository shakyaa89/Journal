using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
