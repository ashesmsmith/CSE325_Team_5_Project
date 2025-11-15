using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalGrower.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty; // e.g., "income" or "expense"

        [Required]
        public DateTime Date { get; set; }

        // Foreign keys
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Goal")]
        public int? GoalId { get; set; }

        // Navigation properties
        public User? User { get; set; }
        public Goal? Goal { get; set; }
    }
}
