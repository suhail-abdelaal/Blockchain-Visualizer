using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_Visualizer
{
    public class Block
    {
        public BigInteger number {  get; set; }
        public BigInteger nonce { get; set; }
        public StringBuilder data {  get; set; }
        public StringBuilder hash { get; set; }
        public StringBuilder prev_hash { get; set; }
        public StringBuilder merkle_root { get; set; }
        public Transaction[] transactions { get; set; }
        public bool isValid {  get; set; }

        public Block(BigInteger number, BigInteger nonce, string prev_hash) {
            this.number = number;
            this.nonce = nonce; 
            this.prev_hash = new StringBuilder(prev_hash);
            data = new StringBuilder();
            hash = new StringBuilder();
            transactions = new Transaction[4];
            isValid = false;
            merkle_root = new StringBuilder();
        }

        public Block()
        {
            data = new StringBuilder();
            hash = new StringBuilder();
            prev_hash = new StringBuilder();
            transactions = new Transaction[4];
            isValid = false;
            merkle_root = new StringBuilder();
        }

        public void CopyTransactions(Transaction[] txs)
        {
            Array.Copy(txs, transactions, txs.Length);
        }

        public void CalculateMerkleRoot()
        {
            StringBuilder txs_combined = new StringBuilder();
            for (int i = 0; i < transactions.Length; ++i)
                txs_combined.Append(transactions[i].hash);

            merkle_root.Clear();
            merkle_root.Append(Hash.CalculateSHA256(txs_combined.ToString()));
        }

        public void UpdateHash(string newHash)
        {
            hash.Clear();
            hash.Append(newHash);

            isValid = newHash.StartsWith(Hash.target);
        }
    }
}
