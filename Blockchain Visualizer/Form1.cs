using System.Security.Cryptography;
using System.Text;

namespace Blockchain_Visualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tb_data.Text = "";
            tb_data.TextChanged += tb_data_TextChanged;
        }

        private void tb_data_TextChanged(object sender, EventArgs e)
        {
            tb_hash.Text = CalculateSHA256(tb_data.Text);
        }

        private string CalculateSHA256(string input)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower(); ;
        }
    }
}