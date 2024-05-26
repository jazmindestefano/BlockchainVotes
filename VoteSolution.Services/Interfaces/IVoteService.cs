using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSolution.Services.Interfaces
{
    public interface IVoteService
    {
        Task<bool> CheckUserAddress(string userAddress);

        Task CreateVoteAsync(string voteName);
    }
}
