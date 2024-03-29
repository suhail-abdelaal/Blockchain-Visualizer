using System.Text;
namespace Blockchain_Visualizer
{
    public class Block
    {
        public string Number { get; set; }            // Block number
        public string Nonce { get; set; }             // Nonce value
        public StringBuilder Data { get; set; }       // Data stored in the block
        public StringBuilder BlkHash { get; set; }    // Hash of the block
        public StringBuilder PrevHash { get; set; }   // Hash of the previous block
        public StringBuilder MerkleRoot { get; set; } // Merkle root of transactions in the block
        public Transaction[] Transactions { get; set; } // Array of transactions in the block
        public bool IsValid { get; set; }             // Flag indicating if the block is valid

        // Constructor with parameters
        public Block(string number, string nonce, string prevHash)
        {
            this.Number = number;
            this.Nonce = nonce;
            this.PrevHash = new StringBuilder(prevHash);
            Data = new StringBuilder();
            BlkHash = new StringBuilder();
            Transactions = new Transaction[4];
            IsValid = false;
            MerkleRoot = new StringBuilder();
        }

        // Default constructor
        public Block()
        {
            Data = new StringBuilder();
            BlkHash = new StringBuilder();
            PrevHash = new StringBuilder();
            Transactions = new Transaction[4];
            IsValid = false;
            MerkleRoot = new StringBuilder();
        }

        // Method to copy transactions to the block
        public void CopyTransactions(Transaction[] txs)
        {
            Array.Copy(txs, Transactions, txs.Length);
        }

        // Method to calculate the Merkle root of transactions
        public void CalculateMerkleRoot()
        {
            StringBuilder txsCombined = new StringBuilder();
            foreach (var transaction in Transactions)
            {
                txsCombined.Append(transaction.Tx_Hash);
            }

            MerkleRoot.Clear();
            MerkleRoot.Append(BlockHashUtility.CalculateSHA256(txsCombined.ToString()));
        }

        // Method to update the hash of the block
        public void UpdateHash(string newHash)
        {
            BlkHash.Clear();
            BlkHash.Append(newHash);

            IsValid = newHash.StartsWith(BlockHashUtility.Target);
        }
    }
}
