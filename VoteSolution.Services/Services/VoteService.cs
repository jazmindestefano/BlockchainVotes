﻿using VoteSolution.Services.Interfaces;
using VoteSolution.Entities.Models;

namespace VoteSolution.Services
{
    public class VoteService : IVoteService
    {
        private readonly IBlockchainService _blockchainService;
        private static List<Vote> _votes = new List<Vote>();

        public VoteService(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        public List<Vote> GetAllVotes()
        {
            return _votes
                .OrderBy(v => v.Id)
                .ToList();
        }


        public void CreateVoteAsync(Vote vote)
        {
            vote.Id = _votes.Count == 0
                            ? 1 :
                            _votes.Max(v => v.Id) + 1;

            _votes.Add(vote);

            // comentado para no hacer demasiadas transacciones

            // await _blockchainService.CreateVoteAsync(vote.Name);
        }
    }
}
