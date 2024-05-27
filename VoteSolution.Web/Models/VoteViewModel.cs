using VoteSolution.Entities;

namespace VoteSolution.Web.Models
{
    public class VoteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public VoteViewModel()
        {

        }

        public VoteViewModel(Vote entidad)
        {
            Id = entidad.Id;
            Name = entidad.Name;
            Description = entidad.Description;
        }

        public static List<VoteViewModel> MapearAListaModel(List<Vote> votes)
        {
            return votes.Select(v => new VoteViewModel(v)).ToList();
        }

        public Vote MapearAEntidad()
        {
            return new Vote
            {
                Id = Id,
                Name = Name,
                Description = Description,
            };
        }
    }
}
