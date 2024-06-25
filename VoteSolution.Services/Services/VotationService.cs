using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using VoteSolution.Entities.Data;
using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;
using VoteSolution.Entities.Data;
using System.Threading.Tasks;
using VoteSolution.Services.DTO;

namespace VoteSolution.Services.Services
{
    public class VotationService : IVotationService
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

        public List<Votation> GetAllVotations() => _votationRepository.GetAllVotations();

        public Votation CreateVotation(CreateVotationDto votationForm)
        {
            var newVotation = new Votation
            {
                Title = votationForm.Title,
                Description = votationForm.Description,
                IsActive = true,
                Options = votationForm.Options.Select(o => new Option(o)).ToList()
            };

            _blockchainService.CreateVotationAsync(votationForm.Title);
            
            return _votationRepository.CreateVotation(newVotation);
        }
        public void CloseVotation(int votationId)
        {
            _votationRepository.CloseVotation(votationId);
        }
    }
}