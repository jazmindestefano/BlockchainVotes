using VoteSolution.Entities.Models;

namespace Repositories.Interfaces;

public interface IVotationRepository
{
    Option GetOptionById(int optionId);
    Option AddVoteToOption(int optionId);
    Votation GetVotationById(int votationId);
    List<Votation> GetAllVotations();
}