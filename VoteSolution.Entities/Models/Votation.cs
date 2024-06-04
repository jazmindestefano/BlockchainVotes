using System.ComponentModel.DataAnnotations;

namespace VoteSolution.Entities.Models
{
    public class Votation
    {
        public Votation(string title, string description)
        {
            Title = title;
            Description = description;
        }
        
        public Votation() {}

        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public List<Option> Options { get; set; } = new List<Option>();

    }
}
