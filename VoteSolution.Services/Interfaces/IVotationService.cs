using VoteSolution.Entities.Models;

namespace VoteSolution.Services.Interfaces
{
    public interface IVotationService
    {
        Task CreateVotationAsync(Votation votation);
    }
}