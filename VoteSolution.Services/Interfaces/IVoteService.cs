using VoteSolution.Entities.Models;

namespace VoteSolution.Services.Interfaces
{
    public interface IVoteService
    {
        void CreateVoteAsync(Vote vote);

        List<Vote> GetAllVotes();
    }
}