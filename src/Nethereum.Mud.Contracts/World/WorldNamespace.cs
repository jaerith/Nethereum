﻿using Nethereum.Web3;
using System.Threading.Tasks;
using Nethereum.BlockchainProcessing.Services;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using System.Threading;
using Nethereum.BlockchainProcessing;
using System.Collections.Generic;
using Nethereum.Mud.Contracts.Core.StoreEvents;
using Nethereum.Mud.Contracts.World.Systems.AccessManagementSystem;
using Nethereum.Mud.Contracts.World.Systems.BalanceTransferSystem;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem;
using Nethereum.Mud.Contracts.World.Systems.RegistrationSystem;
using Nethereum.Mud.Contracts.Core.Systems;
using Nethereum.Mud.Contracts.World.Systems.BatchCallSystem.ContractDefinition;
using Nethereum.Mud.Contracts.World.Systems.RegistrationSystem.ContractDefinition;
using Nethereum.Mud.Contracts.World.Tables;
using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.Mud.Contracts.Core.Namespaces;
using Nethereum.Mud.Contracts.Store;

namespace Nethereum.Mud.Contracts.World
{
    public class WorldNamespace : NamespaceCore<WorldNamespaceResource, WorldSystemServices, WorldTableServices>
    {
        public WorldService WorldService { get; protected set; }
        
        public WorldNamespace(IWeb3 web3, string contractAddress) : base(new WorldNamespaceResource(), web3, contractAddress)
        {
            WorldService = new WorldService(web3, contractAddress);
            Tables = new WorldTableServices(web3, contractAddress);
            Systems = new WorldSystemServices(web3, contractAddress);
        }
    }
}
