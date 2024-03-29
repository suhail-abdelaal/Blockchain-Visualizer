using System.Numerics;
using System.Security.Cryptography;
using System.Text;


namespace Blockchain_Visualizer
{
    internal class BlockHashUtility
    {
        // Target value for hash (leading zeros)
        public static string Target = "0000";

        // Method to calculate SHA-256 hash of a string input
        public static string CalculateSHA256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        // Method to mine a block (find nonce to meet hash target)
        public static void Mine(Block block)
        {
            if (block.IsValid)  // If block is already valid, no need to mine
                return;

            string data = CombineData(block);  // Combine block data
            data = data.Replace("-" + block.Nonce, "-"); // Remove previous nonce

            BigInteger nonce = new BigInteger(-1);
            StringBuilder newData = new StringBuilder();

            string hash = block.BlkHash.ToString();
            while (!hash.StartsWith(Target)) // Keep calculating hash until target is met
            {
                newData.Clear();
                ++nonce;
                newData.Append(data + nonce.ToString());
                hash = CalculateSHA256(newData.ToString());
            }

            block.UpdateHash(hash); // Update block hash with the mined hash
            block.Nonce = nonce.ToString(); // Update block nonce with the mined nonce
        }

        // Method to combine block data for hashing
        public static string CombineData(Block block)
        {
            StringBuilder dataCombined = new StringBuilder();
            dataCombined.Append(block.Number.ToString());
            dataCombined.Append(block.Data.ToString());
            dataCombined.Append(block.PrevHash.ToString());
            dataCombined.Append(block.MerkleRoot.ToString());
            dataCombined.Append("-" + block.Nonce.ToString());
            return dataCombined.ToString();
        }

        // Method to update the entire blockchain with new hash values
        public static void UpdateChain(Block[] blocks, int index)
        {
            blocks[index].UpdateHash(CalculateSHA256(CombineData(blocks[index])));
            for (int i = index + 1; i < blocks.Length; i++)
            {
                blocks[i].PrevHash = blocks[i - 1].BlkHash;
                blocks[i].UpdateHash(CalculateSHA256(CombineData(blocks[i])));
            }
        }

        // Event handler to allow only numbers input in TextBoxes
        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
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
