using System.ComponentModel.DataAnnotations;

namespace VoteSolution.Entities.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        //public int IdVotation { get; set; }
    }
}
