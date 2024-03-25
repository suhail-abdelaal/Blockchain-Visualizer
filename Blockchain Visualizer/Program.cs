using System.Security.Cryptography;
using System.Text;

namespace Blockchain_Visualizer
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {/*
            string hash = "";
            string input = "Who is your favorite fearless hero?";
            int nonce = 0;
            while (!hash.StartsWith("0000"))
            {
                string str = input + nonce.ToString();
                hash = CalculateSHA256(str);
                Console.WriteLine(hash);
                ++nonce;
            }
            Console.WriteLine(nonce);
            */
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}