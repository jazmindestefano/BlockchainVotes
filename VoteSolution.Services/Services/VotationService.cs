using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;
using VoteSolution.Entities.Data;
using System.Threading.Tasks;

namespace VoteSolution.Services.Services
{
    public class VotationService : IVotationService
    {
        private readonly IBlockchainService _blockchainService;
        private readonly ApplicationDbContext _context;
        private static List<Votation> _votations = new List<Votation>();

        public VotationService(IBlockchainService blockchainService, ApplicationDbContext context)
        {
            _blockchainService = blockchainService;
            _context = context;
        }

        public async Task CreateVotationAsync(Votation votation)
        {
            var newVotation = new Votation
            {
                Title = votation.Title,
                Description = votation.Description,
                IsActive = true,
                Options = votation.Options
            };

            _context.Votations.Add(newVotation);
            await _context.SaveChangesAsync();
            //await _blockchainService.CreateVoteAsync(votation.Title);
        }
    }
}
