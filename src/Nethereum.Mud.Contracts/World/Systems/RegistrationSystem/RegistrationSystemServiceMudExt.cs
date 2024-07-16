using Nethereum.Contracts;
using Nethereum.Mud.Contracts.Core.Systems;
using System.Collections.Generic;
using Nethereum.ABI.Model;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Mud.Contracts.World.Systems.RegistrationSystem.ContractDefinition;
using Nethereum.Contracts.Create2Deployment;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Mud.Contracts.World.Systems.RegistrationSystem
{
    public class RegistrationSystemResource: SystemResource
    {
        public RegistrationSystemResource() : base("Registration", string.Empty) { }
    }

    public partial class RegistrationSystemService : ISystemService<RegistrationSystemResource>
    {
        public IResource Resource => this.GetResource();

        public ISystemServiceResourceRegistration SystemServiceResourceRegistrator
        {
            get
            {
                return this.GetSystemServiceResourceRegistration<RegistrationSystemResource, RegistrationSystemService>();
            }
        }

        public List<FunctionABI> GetSystemFunctionABIs()
        {
            return GetAllFunctionABIs();
        }

        public string CalculateCreate2Address(string deployerAddress, string salt, params ByteCodeLibrary[] byteCodeLibraries)
        {
            return new RegistrationSystemDeployment().CalculateCreate2Address(deployerAddress, salt, byteCodeLibraries);
        }

        public Task<Create2ContractDeploymentTransactionResult> DeployCreate2ContractAsync(string deployerAddress, string salt, params ByteCodeLibrary[] byteCodeLibraries)
        {
            var create2ProxyDeployerService = Web3.Eth.Create2DeterministicDeploymentProxyService;
            var accessManagementSystemDeployment = new RegistrationSystemDeployment();
            return create2ProxyDeployerService.DeployContractRequestAsync(accessManagementSystemDeployment, deployerAddress, salt, byteCodeLibraries);
        }

        public Task<Create2ContractDeploymentTransactionReceiptResult> DeployCreate2ContractAndWaitForReceiptAsync(string deployerAddress, string salt, ByteCodeLibrary[] byteCodeLibraries, CancellationToken cancellationToken = default)
        {
            var create2ProxyDeployerService = Web3.Eth.Create2DeterministicDeploymentProxyService;
            var accessManagementSystemDeployment = new RegistrationSystemDeployment();
            return create2ProxyDeployerService.DeployContractRequestAndWaitForReceiptAsync(accessManagementSystemDeployment, deployerAddress, salt, byteCodeLibraries, cancellationToken);
        }
    }
}
