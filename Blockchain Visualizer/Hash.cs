using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_Visualizer
{
    internal class Hash
    {

        public static string target = "0000";
        public static string CalculateSHA256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower(); ;
        }
        public static void Mine(Block block)
        {
            if (block.isValid)
                return;

            string data = CombineData(block);
            data = data.Replace("-" + block.nonce.ToString(), "-");

            BigInteger nonce = new BigInteger(-1);
            StringBuilder new_data = new StringBuilder();

            string hash = block.hash.ToString();
            while (!hash.StartsWith(target))
            {
                new_data.Clear();
                ++nonce;
                new_data.Append(data + nonce.ToString());
                hash = CalculateSHA256(new_data.ToString());
            }

            block.UpdateHash(hash);
            block.nonce = nonce;
        }

        public static string CombineData(Block block)
        {
            StringBuilder data_combined = new StringBuilder();
            data_combined.Append(block.number.ToString());
            data_combined.Append(block.data.ToString());
            data_combined.Append(block.prev_hash.ToString());
            data_combined.Append(block.merkle_root.ToString());
            data_combined.Append("-" + block.nonce.ToString());
            return data_combined.ToString();
        }

        public static void UpdateChain(Block[] blocks, int idx)
        {
            blocks[idx].UpdateHash(Hash.CalculateSHA256(Hash.CombineData(blocks[idx])));
            for (int i = idx + 1; i < blocks.Length; i++)
            {
                blocks[i].prev_hash = blocks[i - 1].hash;
                blocks[i].UpdateHash(Hash.CalculateSHA256(Hash.CombineData(blocks[i])));
            }
        }

        public static void onlyNumbers(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
