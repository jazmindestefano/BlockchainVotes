using VoteSolution.Entities.Models;

namespace VoteSolution.Services.Interfaces
{
    public interface IVoteService
    {
        void CreateVotationAsync(Votation votation);

        List<Votation> GetAllVotationsAsync();
    }
}
