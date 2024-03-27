using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain_Visualizer.UserControls
{
    public partial class UC_Tokens : UserControl
    {

        Block[] Ablocks;
        Block[] Bblocks;
        Block[] Cblocks;
        public UC_Tokens()
        {

            Ablocks = new Block[4];
            Bblocks = new Block[4];
            Cblocks = new Block[4];

            Ablocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");


            for (int i = 1; i < Ablocks.Length; i++)
            {
                Ablocks[i] = new Block();
                Bblocks[i] = new Block();
                Cblocks[i] = new Block();
            }

            FillTransactions();

            Ablocks[0].CalculateMerkleRoot();
            Bblocks[0].CalculateMerkleRoot();
            Cblocks[0].CalculateMerkleRoot();

            Hash.Mine(Ablocks[0]);
            Hash.Mine(Bblocks[0]);
            Hash.Mine(Cblocks[0]);




            for (int i = 1; i < Ablocks.Length; i++)
            {
                string previousHash = Ablocks[i - 1].hash.ToString();

                Ablocks[i].number = i + 1;
                Ablocks[i].nonce = 0;
                Ablocks[i].prev_hash.Append(previousHash);
                Ablocks[i].CalculateMerkleRoot();

                Hash.Mine(Ablocks[i]);

                Bblocks[i].number = i + 1;
                Bblocks[i].hash = Ablocks[i].hash;
                Bblocks[i].prev_hash.Append(previousHash);
                Bblocks[i].nonce = Ablocks[i].nonce;
                Bblocks[i].merkle_root = Ablocks[i].merkle_root;

                Cblocks[i].number = i + 1;
                Cblocks[i].hash = Ablocks[i].hash;
                Cblocks[i].prev_hash.Append(previousHash);
                Cblocks[i].nonce = Ablocks[i].nonce;
                Cblocks[i].merkle_root = Ablocks[i].merkle_root;

            }
            InitializeComponent();

            /*            chain_A_onChanging();
                        chain_B_onChanging();
                        chain_C_onChanging();*/
        }

        private void UC_Tokens_Load(object sender, EventArgs e)
        {

        }

        private void FillTransactions()
        {
            // Block 1
            Ablocks[0].transactions[0] = new Transaction(10.24, "Suhail", "Omar");
            Ablocks[0].transactions[1] = new Transaction(5.5, "AbdelRahman", "Naser");
            Ablocks[0].transactions[2] = new Transaction(25.0, "Taha", "Amr");
            Ablocks[0].transactions[3] = new Transaction(37.65, "Saif", "Mostafa");

            Bblocks[0].CopyTransactions(Ablocks[0].transactions);
            Cblocks[0].CopyTransactions(Ablocks[0].transactions);

            //Block 2
            Ablocks[1].transactions[0] = new Transaction(12.3, "Sara", "Yaser");
            Ablocks[1].transactions[1] = new Transaction(45.0, "Nada", "Ola");
            Ablocks[1].transactions[2] = new Transaction(0, "", "");
            Ablocks[1].transactions[3] = new Transaction(0, "", "");

            Bblocks[1].CopyTransactions(Ablocks[1].transactions);
            Cblocks[1].CopyTransactions(Ablocks[1].transactions);

            //Block 3
            Ablocks[2].transactions[0] = new Transaction(6.25, "Omar", "AbdelRahman");
            Ablocks[2].transactions[1] = new Transaction(5.0, "Naser", "Mohammed");
            Ablocks[2].transactions[2] = new Transaction(33.65, "Tarek", "Hassan");
            Ablocks[2].transactions[3] = new Transaction(30.33, "Ola", "Sara");

            Bblocks[2].CopyTransactions(Ablocks[2].transactions);
            Cblocks[2].CopyTransactions(Ablocks[2].transactions);

            //Block 4
            Ablocks[3].transactions[0] = new Transaction(8.3, "Yaser", "Suhail");
            Ablocks[3].transactions[1] = new Transaction(22.25, "Esraa", "Nada");
            Ablocks[3].transactions[2] = new Transaction(11.0, "Omar", "Basmala");
            Ablocks[3].transactions[3] = new Transaction(0, "", "");

            Bblocks[3].CopyTransactions(Ablocks[3].transactions);
            Cblocks[3].CopyTransactions(Ablocks[3].transactions);
        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void textBox106_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }

        private void UC_Tokens_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }
    }
}
