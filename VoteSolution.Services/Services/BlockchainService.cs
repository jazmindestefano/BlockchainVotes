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
            _contract = _web3.Eth.GetContract(ContractAbi.ContractAbi.ABI, "0x07920c83A2FD18c063996bDaf6e64f5BAda679e1");
        }

        public async Task CreateVoteAsync(string voteName)
        {
            try
            {
                var createVoteFunction = _contract.GetFunction("createVote");
                var gas = new HexBigInteger(3000000);
                var value = new HexBigInteger(0);

                var transactionReceipt = await createVoteFunction.SendTransactionAndWaitForReceiptAsync("0xE1724818D579622972542819dd95569135C0F52E", gas, value, null, voteName);


                Console.WriteLine($"Transacción enviada. Hash de la transacción: {transactionReceipt.TransactionHash}");
                Console.WriteLine($"Transacción enviada. Block de la transacción: {transactionReceipt.BlockHash}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo una excepción al enviar la transacción: {ex.Message}");
            }

        }
    }
}
