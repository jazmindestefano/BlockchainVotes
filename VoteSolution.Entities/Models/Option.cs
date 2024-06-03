using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSolution.Entities.Models
{
    public class Option
    {
        public Option(string name, int votationId)
        {
            Name = name;
            VotationId = votationId;
        }

        public Option() {}

        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalVotes { get; set; } = 0;

        public int VotationId { get; set; }

        public Votation Votation { get; set; }
        
    }
}
