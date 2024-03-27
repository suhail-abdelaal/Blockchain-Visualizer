using System.Security.Cryptography;
using System.Text;

namespace Blockchain_Visualizer
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}