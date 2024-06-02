using System.ComponentModel.DataAnnotations;

namespace VoteSolution.Entities.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Description { get; set; }
    }
}
