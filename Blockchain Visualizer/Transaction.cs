using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_Visualizer
{
    public class Transaction
    {
        public int amount {  get; set; }
        public string sender { get; set; }
        public string receiver {  get; set; }
        public string hash {  get; set; }

        public Transaction(int amount, string sender, string receiver)
        {
            this.amount = amount;
            this.sender = sender;
            this.receiver = receiver;
            CalculateTransactionHash();
        }

        public void CalculateTransactionHash()
        {
            StringBuilder transaction = new StringBuilder();
            transaction.Append(this.amount.ToString());
            transaction.Append(this.sender);
            transaction.Append(this.receiver);
            hash = Hash.CalculateSHA256(transaction.ToString());
        }
    }
}
