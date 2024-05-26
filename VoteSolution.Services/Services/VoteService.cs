using System.Threading.Tasks;
using VoteSolution.Services.Interfaces;

namespace VoteSolution.Services
{
    public class VoteService : IVoteService
    {
        private readonly IBlockchainService _blockchainService;

        public VoteService(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public Task<bool> CheckUserAddress(string userAddress)
        {
            if (userAddress == "0xE1724818D579622972542819dd95569135C0F52E")
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }


        public async Task CreateVoteAsync(string voteName)
        {
            // comentado para no hacer demasiadas transacciones
            //a await _blockchainService.CreateVoteAsync(voteName);
        }
    }
}
