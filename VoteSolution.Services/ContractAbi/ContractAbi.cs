namespace VoteSolution.Services.ContractAbi
{
    public static class ContractAbi
    {
        public const string ABI = @"
        [
			{
				""anonymous"": false,
				""inputs"": [
					{
						""indexed"": true,
						""internalType"": ""uint256"",
						""name"": ""voteId"",
						""type"": ""uint256""
					},
					{
						""indexed"": false,
						""internalType"": ""string"",
						""name"": ""name"",
						""type"": ""string""
					}
				],
				""name"": ""VoteCreated"",
				""type"": ""event""
			},
			{
				""anonymous"": false,
				""inputs"": [
					{
						""indexed"": true,
						""internalType"": ""uint256"",
						""name"": ""voteId"",
						""type"": ""uint256""
					},
					{
						""indexed"": false,
						""internalType"": ""uint256"",
						""name"": ""voteCount"",
						""type"": ""uint256""
					}
				],
				""name"": ""Voted"",
				""type"": ""event""
			},
			{
				""inputs"": [
					{
						""internalType"": ""string"",
						""name"": ""name"",
						""type"": ""string""
					}
				],
				""name"": ""createVote"",
				""outputs"": [],
				""stateMutability"": ""nonpayable"",
				""type"": ""function""
			},
			{
				""inputs"": [
					{
						""internalType"": ""uint256"",
						""name"": ""voteId"",
						""type"": ""uint256""
					}
				],
				""name"": ""vote"",
				""outputs"": [],
				""stateMutability"": ""nonpayable"",
				""type"": ""function""
			},
			{
				""inputs"": [
					{
						""internalType"": ""uint256"",
						""name"": """",
						""type"": ""uint256""
					}
				],
				""name"": ""votes"",
				""outputs"": [
					{
						""internalType"": ""uint256"",
						""name"": ""id"",
						""type"": ""uint256""
					},
					{
						""internalType"": ""string"",
						""name"": ""name"",
						""type"": ""string""
					},
					{
						""internalType"": ""uint256"",
						""name"": ""voteCount"",
						""type"": ""uint256""
					}
				],
				""stateMutability"": ""view"",
				""type"": ""function""
			}
		]
        ";
    }
}
