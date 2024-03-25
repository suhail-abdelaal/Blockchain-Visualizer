﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain_Visualizer
{
    internal class Hash
    {

        public static string target = "00000";
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
            string hash = block.hash.ToString();
            data = data.Replace(block.nonce.ToString(), "");

            int nonce = -1;
            StringBuilder new_data = new StringBuilder();

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
            data_combined.Append(block.nonce.ToString());
            return data_combined.ToString();
        }

    }
}