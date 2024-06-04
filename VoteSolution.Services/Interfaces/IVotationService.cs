using VoteSolution.Entities.Models;
using VoteSolution.Services.DTO;

namespace VoteSolution.Services.Interfaces
{
    public interface IVotationService
    {
        Votation CreateVotation(CreateVotationDto votationForm);

        List<Votation> GetAllVotations();

        Option AddVoteToOption(int optionId);

        Votation GetVotationById(int votationId);
        
        
    }
}