using System;
using System.ComponentModel.DataAnnotations;

namespace BookBuddy.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Mnenje ne sme presegati 500 znakov.")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int BookId { get; set; }
    }
}