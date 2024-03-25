using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_Visualizer
{
    internal class Block
    {
        public int number {  get; set; }
        public int nonce { get; set; }
        public StringBuilder data {  get; set; }
        public StringBuilder hash { get; set; }
        public StringBuilder prev_hash { get; set; }
        public bool isValid {  get; set; }
        public Block(int number, int nonce, string prev_hash) {
            this.number = number;
            this.nonce = nonce; 
            this.prev_hash = new StringBuilder(prev_hash);
            this.data = new StringBuilder("");
            this.hash = new StringBuilder();
            this.isValid = true;
        }

        public void UpdateHash(string newHash)
        {
            this.hash.Clear();
            this.hash.Append(newHash);

            if (newHash.StartsWith(Hash.target))
                isValid = true;
            else 
                isValid =false;
        }
    }
}
