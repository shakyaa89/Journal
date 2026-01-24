using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journal.Models
{
    public class JournalEntry
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string Mood { get; set; } = string.Empty;

        [Required]
        public string SecondaryMood1 { get; set; } = string.Empty;

        [Required]
        public string SecondaryMood2 { get; set; } = string.Empty;

        public List<string>? Tags { get; set; } = new();

        [Required]
        public int WordCount { get; set; } = 0;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
