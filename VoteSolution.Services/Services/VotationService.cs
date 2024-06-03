using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;

namespace VoteSolution.Services
{
    public class VotationService : IVoteService
    {
        private readonly IBlockchainService _blockchainService;
        private static List<Votation> _votations = new List<Votation>();

        public VotationService(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        // que el metodo tenga Async, significa que devuelve una Task
        public List<Votation> GetAllVotationsAsync()
        {
            return _votations
                .OrderBy(v => v.Id)
                .ToList();
        }


        public void CreateVotationAsync(Votation votation)
        {
            votation.Id = _votations.Count == 0
                            ? 1 :
                            _votations.Max(v => v.Id) + 1;

            _votations.Add(votation);

            // comentado para no hacer demasiadas transacciones, NO DESCOMENTAR

            // await _blockchainService.CreateVotationAsync(votation.Name);
        }
    }
}
