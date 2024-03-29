using System.Text;

namespace Blockchain_Visualizer
{
    // Class representing a single transaction
    public class Transaction
    {
        // Properties representing various attributes of a transaction
        public int Amount { get; set; }    // Amount of currency transferred
        public string Sender { get; set; } // Sender's address
        public string Receiver { get; set; }   // Receiver's address
        public string Tx_Hash { get; set; }   // Hash of the transaction

        // Constructor to initialize a transaction with given parameters
        public Transaction(int amount, string sender, string receiver)
        {
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
            CalculateTransactionHash(); // Calculate hash of the transaction
        }

        // Method to calculate the hash of the transaction
        public void CalculateTransactionHash()
        {
            StringBuilder transaction = new StringBuilder();
            transaction.Append(Amount.ToString());   // Append amount to the transaction
            transaction.Append(Sender);              // Append sender's address
            transaction.Append(Receiver);            // Append receiver's address
            Tx_Hash = BlockHashUtility.CalculateSHA256(transaction.ToString()); // Calculate SHA-256 hash
        }
    }
}
