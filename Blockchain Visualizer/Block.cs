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
        public string data {  get; set; }
        public string hash { get; set; }
        public string prev_hash { get; set; }
        Block(int number, int nonce, string prev_hash) {
            this.number = number;
            this.nonce = nonce; 
            this.prev_hash = prev_hash;
            this.data = "";
        }
    }
}
