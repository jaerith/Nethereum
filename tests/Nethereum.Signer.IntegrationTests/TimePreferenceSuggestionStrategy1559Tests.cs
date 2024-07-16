using System.Collections.Generic;
using System.Threading;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Fee1559Suggestions;
using Nethereum.Web3.Accounts;
using Nethereum.XUnitEthereumClients;
using Xunit;
// ReSharper disable ConsiderUsingConfigureAwait

namespace Nethereum.Signer.IntegrationTests
{
    [Collection(EthereumClientIntegrationFixture.ETHEREUM_CLIENT_COLLECTION_DEFAULT)]
    public class TimePreferenceSuggestionStrategy1559Tests
    {
        private readonly EthereumClientIntegrationFixture _ethereumClientIntegrationFixture;

        public TimePreferenceSuggestionStrategy1559Tests(EthereumClientIntegrationFixture ethereumClientIntegrationFixture)
        {
            _ethereumClientIntegrationFixture = ethereumClientIntegrationFixture;
        }
        
        [Fact]
        public async void ShouldBeAbleToCalculateHistoryAndSend1000sOfTransactions()
        {
            if (_ethereumClientIntegrationFixture.EthereumClient == EthereumClient.Geth)
            {
                var receiveAddress = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";
                var listTransactionHashes = new List<string>();
                var web3 = _ethereumClientIntegrationFixture.GetWeb3();
                web3.TransactionReceiptPolling.SetPollingRetryIntervalInMilliseconds(2000);
#if NETCOREAPP3_1_OR_GREATER || NET50
                EthECKey.SignRecoverable = true;
#endif
                var feeStrategy = new TimePreferenceFeeSuggestionStrategy(web3.Client);
                for (var x = 0; x < 10; x++)
                {
                    Thread.Sleep(500);
                    var fee = await feeStrategy.SuggestFeeAsync().ConfigureAwait(false);
                    for (int i = 0; i < 50; i++)
                    {
                        var encoded = await web3.TransactionManager.SendTransactionAsync(
                            new TransactionInput()
                            {
                                Type = new HexBigInteger(2),
                                From = web3.TransactionManager.Account.Address,
                                MaxFeePerGas = new HexBigInteger(fee.MaxFeePerGas.Value),
                                MaxPriorityFeePerGas = new HexBigInteger(fee.MaxPriorityFeePerGas.Value),
                                To = receiveAddress,
                                Value = new HexBigInteger(10)
                            }).ConfigureAwait(false);
                        listTransactionHashes.Add(encoded);
                   }
                }

                foreach (var tx in listTransactionHashes)
                {   
                    
                    var receipt = await web3.TransactionReceiptPolling.PollForReceiptAsync(tx);
                    Assert.True(receipt.Succeeded());
                }
            }
        }
    }
}