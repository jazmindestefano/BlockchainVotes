using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSolution.Entities.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public bool isWinner { get; set; }

        public int PeopleVoted { get; set; }

        public int VotationId { get; set; }

        [ForeignKey("VotationId")]
        public Votation? Votation { get; set; }
    }
}
