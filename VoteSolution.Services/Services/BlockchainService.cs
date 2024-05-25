using System;
using System.Text;
using System.Threading.Tasks;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.Standards.ERC20.ContractDefinition;
using Nethereum.Web3;
using VoteSolution.Services.Interfaces;
using Nethereum.Hex.HexTypes;

namespace VoteSolution.Services.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly Web3 _web3;
        private readonly Contract _contract;

        public BlockchainService(Web3 web3)
        {
            _web3 = web3;
            _contract = _web3.Eth.GetContract(ContractAbi.ContractAbi.ABI, "0xfe6c2dc1828860ffd1f30c84f6e7827489c3829f");
        }

        public async Task CreateVoteAsync(string voteName)
        {
            // Obtén la referencia de la función createVote
            var createVoteFunction = _contract.GetFunction("createVote");

            // Envía la transacción y obtén el hash de la transacción
            var transactionHash = await createVoteFunction.SendTransactionAsync("0xE1724818D579622972542819dd95569135C0F52E", new HexBigInteger(3000000), null, voteName);

            // Imprime el hash de la transacción
            Console.WriteLine($"Transacción enviada. Hash de la transacción: {transactionHash}");
        }
    }
}
