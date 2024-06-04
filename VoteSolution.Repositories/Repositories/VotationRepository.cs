using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using VoteSolution.Entities.Data;
using VoteSolution.Entities.Models;

namespace Repositories.Repositories;

public class VotationRepository: IVotationRepository
{
    private readonly ApplicationDbContext _context;

    public VotationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Option GetOptionById(int optionId) => _context.Options.Single(o => o.Id == optionId);
    public Option AddVoteToOption(int optionId)
    {
        var option = GetOptionById(optionId);
        option.TotalVotes = option.TotalVotes + 1;
        _context.SaveChanges();
        return option;
    }
    public Votation GetVotationById(int votationId) => _context.Votations.Include(v => v.Options).Single(v => v.Id == votationId);
    public List<Votation> GetAllVotations() => _context.Votations.Include(v => v.Options).ToList();

}