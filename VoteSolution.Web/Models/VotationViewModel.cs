using System.ComponentModel.DataAnnotations;
using VoteSolution.Entities.Models;

namespace VoteSolution.Web.Models
{
    public class VotationViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public List<string> Options { get; set; } = new List<string>();
    }
}
