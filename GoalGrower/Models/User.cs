using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoalGrower.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public decimal BankAmount { get; set; }

        // Navigation properties
        public List<Transaction>? Transactions { get; set; }
        public List<Goal>? Goals { get; set; }
    }
}
