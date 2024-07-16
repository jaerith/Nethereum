﻿using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Mud.EncodingDecoding;
using static Nethereum.Mud.Contracts.World.Tables.SystemsTableRecord;

namespace Nethereum.Mud.Contracts.World.Tables
{
    public class SystemsTableRecord : TableRecord<SystemsKey, SystemsValue>
    {
        public SystemsTableRecord() : base("world", "Systems")
        {
        }

        public class SystemsKey
        {
            [Parameter("bytes32", "systemId", 1)]
            public byte[] SystemId { get; set; }

            public Resource GetSystemIdResource()
            {
                return ResourceEncoder.Decode(SystemId);
            }
        }

        public class SystemsValue
        {
            [Parameter("address", "system", 1)]
            public string System { get; set; }
            [Parameter("bool", "publicAccess", 2)]
            public bool PublicAccess { get; set; }
        }
    }

}

