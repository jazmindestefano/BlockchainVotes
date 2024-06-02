using System.ComponentModel.DataAnnotations;

namespace VoteSolution.Entities.Models
{
    public class Votation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Description { get; set; }

        public bool isActive { get; set; }

        public List<Option>? Options { get; set; } = new List<Option>();
    }
}
