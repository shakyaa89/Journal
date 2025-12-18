using System;
using System.Collections.Generic;

namespace Project.Models   // <-- Make sure this is NOT 'Journal'
{
    public class Journal
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Static list to hold all journal entries
        public static List<Journal> Journals { get; } = new List<Journal>();

        // Method to save a journal entry
        public void Save()
        {
            Journals.Add(this);
        }
    }
}
