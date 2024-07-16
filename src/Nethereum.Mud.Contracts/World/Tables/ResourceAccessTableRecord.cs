﻿using static Nethereum.Mud.Contracts.World.Tables.ResourceAccessTableRecord;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Mud.EncodingDecoding;

namespace Nethereum.Mud.Contracts.World.Tables
{
    /*
     *  ResourceAccess: {
      schema: {
        resourceId: "ResourceId",
        caller: "address",
        access: "bool",
      },
      key: ["resourceId", "caller"],
    },
     */
    public class ResourceAccessTableRecord : TableRecord<ResourceAccessKey, ResourceAccessValue>
    {
        public ResourceAccessTableRecord() : base("world", "ResourceAccess")
        {

        }
        public class ResourceAccessKey
        {
            [Parameter("bytes32", "resourceId", 1)]
            public byte[] ResourceId { get; set; }
            [Parameter("address", "caller", 2)]
            public string Caller { get; set; }

            public Resource GetResourceIdResource()
            {
                return ResourceEncoder.Decode(ResourceId);
            }
        }


        public class ResourceAccessValue
        {
            [Parameter("bool", 1)]
            public bool Access { get; set; }
        }
    }



}
