﻿using Nethereum.DataServices.Etherscan.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Nethereum.DataServices.Etherscan
{


    public class EtherscanApiContractsService
    {
        public EtherscanRequestService EtherscanRequestService { get; private set; } 

        public EtherscanApiContractsService(EtherscanRequestService etherscanRequestService) 
        {
            EtherscanRequestService = etherscanRequestService;
        }

        public async Task<EtherscanResponse<List<EtherscanGetSourceCodeResponse>>> GetSourceCodeAsync(string address)
        {
            var url = $"{EtherscanRequestService.BaseUrl}api?module=contract&action=getsourcecode&address={address}&apikey={EtherscanRequestService.ApiKey}";
            return await EtherscanRequestService.GetDataAsync<List<EtherscanGetSourceCodeResponse>>(url).ConfigureAwait(false);
        }

        public async Task<EtherscanResponse<string>> GetAbiAsync(string address)
        {
            var url = $"{EtherscanRequestService.BaseUrl}api?module=contract&action=getabi&address={address}&apikey={EtherscanRequestService.ApiKey}";
            return await EtherscanRequestService.GetDataAsync<string>(url).ConfigureAwait(false);
        }

        public async Task<EtherscanResponse<List<EtherscanGetContractCreatorResponse>>> GetContractCreatorAndCreationTxHashAsync(params string[] addresses)
        {
            var url = $"{EtherscanRequestService.BaseUrl}api?module=contract&action=getcontractcreation&contractaddresses={string.Join(",",addresses)}&apikey={EtherscanRequestService.ApiKey}";
            return await EtherscanRequestService.GetDataAsync<List<EtherscanGetContractCreatorResponse>>(url).ConfigureAwait(false);
        }
    }
}
