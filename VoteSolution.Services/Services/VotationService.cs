using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using VoteSolution.Entities.Data;
using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;

namespace VoteSolution.Services.Services
{
    public class VotationService : IVoteService
    {
        private readonly IBlockchainService _blockchainService;
        private readonly IVotationRepository _votationRepository;
        private static List<Votation> _votations = new List<Votation>();

        public VotationService(IBlockchainService blockchainService, IVotationRepository votationRepository)
        {
            _votationRepository = votationRepository;
            _blockchainService = blockchainService;
        }

        public Votation GetVotationById(int votationId) => _votationRepository.GetVotationById(votationId);

        public Option AddVoteToOption(int optionId) => _votationRepository.AddVoteToOption(optionId);
        
        // que el metodo tenga Async, significa que devuelve una Task
        public List<Votation> GetAllVotations() => _votationRepository.GetAllVotations();

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
