using System;
using System.Collections.Generic;

namespace Project.Models   
{
    public class Journal
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<string> Tags { get; set; } = new List<string>();
        public string Mood { get; set; } = string.Empty;

        public static List<Journal> Journals { get; } = new List<Journal>();

        public void CreateJournalEntry()
        {
            Journals.Add(this);
        }
    }
}
