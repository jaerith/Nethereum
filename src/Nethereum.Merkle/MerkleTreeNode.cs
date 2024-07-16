﻿using Nethereum.Util;

namespace Nethereum.Merkle
{
    public class MerkleTreeNode
    {
        public byte[] Hash { get; set; }
        public MerkleTreeNode(byte[] hash)
        {
            Hash = hash;
        }

        public int Compare(MerkleTreeNode other)
        {
            return MerkleTreeNodeComparer.Current.Compare(this, other);
        }

        public int Compare(byte[] hashOther)
        {
            return ByteArrayComparer.Current.Compare(this.Hash, hashOther);
        }

        public bool Matches(byte[] hashOther)
        {
            return Compare(hashOther) == 0;
        }

        public bool Matches(MerkleTreeNode other)
        {
            return Compare(other) == 0;
        }

        public MerkleTreeNode Clone()
        {
            return new MerkleTreeNode(Hash);
        }
    }

}
