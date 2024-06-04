using VoteSolution.Entities.Models;

namespace VoteSolution.Web.Models
{
    public class VoteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public List<string> Options { get; set; } = new List<string>();

        public VoteViewModel() {}

        public VoteViewModel(Votation entidad)
        {
            Id = entidad.Id;
            Title = entidad.Title;
            Description = entidad.Description;
        }

        public static List<VoteViewModel> MapearAListaModel(List<Votation> votes)
        {
            return votes.Select(v => new VoteViewModel(v)).ToList();
        }

        public Votation MapearAEntidad()
        {
            return new Votation
            {
                Id = Id,
                Title = Title,
                Description = Description,
            };
        }
    }
}
