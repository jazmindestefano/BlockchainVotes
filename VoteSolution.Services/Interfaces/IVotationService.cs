using VoteSolution.Entities.Models;

namespace VoteSolution.Services.Interfaces
{
    public interface IVotationService
    {
        Task CreateVotationAsync(Votation votation);

        List<Votation> GetAllVotations();

        Option AddVoteToOption(int optionId);

        Votation GetVotationById(int votationId);
        
        
    }
}