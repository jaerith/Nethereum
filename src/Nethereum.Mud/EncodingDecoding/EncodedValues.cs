﻿namespace Nethereum.Mud.EncodingDecoding
{
    public class EncodedValues
    {
        public byte[] StaticData { get; set; }
        public byte[] EncodedLengths { get; set; }
        public byte[] DynamicData { get; set; }
    }
}
