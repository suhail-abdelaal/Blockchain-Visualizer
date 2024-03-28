using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            Ablocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");


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

            chain_A_eventHandler();
            chain_B_eventHandler();
            chain_C_eventHandler();
        }

        private void UC_Tokens_Load(object sender, EventArgs e)
        {
            UC_Distributed_Load_Chain_A();
            UC_Distributed_Load_Chain_B();
            UC_Distributed_Load_Chain_C();
        }

        private void FillTransactions()
        {
            // Block 1
            Ablocks[0].transactions[0] = new Transaction(10, "Suhail", "Omar");
            Ablocks[0].transactions[1] = new Transaction(5, "AbdelRahman", "Naser");
            Ablocks[0].transactions[2] = new Transaction(25, "Taha", "Amr");
            Ablocks[0].transactions[3] = new Transaction(37, "Saif", "Mostafa");

            Bblocks[0].CopyTransactions(Ablocks[0].transactions);
            Cblocks[0].CopyTransactions(Ablocks[0].transactions);

            //Block 2
            Ablocks[1].transactions[0] = new Transaction(12, "Sara", "Yaser");
            Ablocks[1].transactions[1] = new Transaction(45, "Nada", "Ola");
            Ablocks[1].transactions[2] = new Transaction(0, "", "");
            Ablocks[1].transactions[3] = new Transaction(0, "", "");

            Bblocks[1].CopyTransactions(Ablocks[1].transactions);
            Cblocks[1].CopyTransactions(Ablocks[1].transactions);

            //Block 3
            Ablocks[2].transactions[0] = new Transaction(6, "Omar", "AbdelRahman");
            Ablocks[2].transactions[1] = new Transaction(5, "Naser", "Mohammed");
            Ablocks[2].transactions[2] = new Transaction(33, "Tarek", "Hassan");
            Ablocks[2].transactions[3] = new Transaction(30, "Ola", "Sara");

            Bblocks[2].CopyTransactions(Ablocks[2].transactions);
            Cblocks[2].CopyTransactions(Ablocks[2].transactions);

            //Block 4
            Ablocks[3].transactions[0] = new Transaction(8, "Yaser", "Suhail");
            Ablocks[3].transactions[1] = new Transaction(22, "Esraa", "Nada");
            Ablocks[3].transactions[2] = new Transaction(11, "Omar", "Basmala");
            Ablocks[3].transactions[3] = new Transaction(0, "", "");

            Bblocks[3].CopyTransactions(Ablocks[3].transactions);
            Cblocks[3].CopyTransactions(Ablocks[3].transactions);
        }

        private void chain_A_eventHandler()
        {
            // Block 1 
            tb_block_a1.TextChanged += chain_A_TextChanged;
            tb_nonce_a1.TextChanged += tb_nonce_a1_TextChanged;

            tx_amt1_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Ablocks, 0);
            tx_amt2_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Ablocks, 0);
            tx_amt3_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Ablocks, 0);
            tx_amt4_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Ablocks, 0);

            tx_send1_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Ablocks, 0);
            tx_send2_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Ablocks, 0);
            tx_send3_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Ablocks, 0);
            tx_send4_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Ablocks, 0);

            tx_receive1_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Ablocks, 0);
            tx_receive2_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Ablocks, 0);
            tx_receive3_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Ablocks, 0);
            tx_receive4_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Ablocks, 0);

            // Block 2
            tb_block_a2.TextChanged += tb_block_a2_TextChanged;
            tb_nonce_a2.TextChanged += tb_nonce_a2_TextChanged;

            tx_amt1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Ablocks, 1);
            tx_amt2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Ablocks, 1);

            tx_send1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Ablocks, 1);
            tx_send2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Ablocks, 1);

            tx_receive1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Ablocks, 1);
            tx_receive2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Ablocks, 1);

            // Blcok 3 
            tb_block_a3.TextChanged += tb_block_a3_TextChanged;
            tb_nonce_a3.TextChanged += tb_nonce_a3_TextChanged;

            tx_amt1_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Ablocks, 2);
            tx_amt2_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Ablocks, 2);
            tx_amt3_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Ablocks, 2);
            tx_amt4_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Ablocks, 2);

            tx_send1_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Ablocks, 2);
            tx_send2_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Ablocks, 2);
            tx_send3_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Ablocks, 2);
            tx_send4_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Ablocks, 2);

            tx_receive1_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Ablocks, 2);
            tx_receive2_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Ablocks, 2);
            tx_receive3_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Ablocks, 2);
            tx_receive4_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Ablocks, 2);


            // Block 4
            tb_block_a4.TextChanged += tb_block_a4_TextChanged;
            tb_nonce_a4.TextChanged += tb_nonce_a4_TextChanged;

            tx_amt1_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Ablocks, 3);
            tx_amt2_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Ablocks, 3);
            tx_amt3_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Ablocks, 3);

            tx_send1_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Ablocks, 3);
            tx_send2_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Ablocks, 3);
            tx_send3_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Ablocks, 3);

            tx_receive1_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Ablocks, 3);
            tx_receive2_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Ablocks, 3);
            tx_receive3_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Ablocks, 3);

        }

        private void chain_B_eventHandler()
        {
            tb_block_b1.TextChanged += tb_block_b1_TextChanged;
            tb_nonce_b1.TextChanged += tb_nonce_b1_TextChanged;

            // Block 1
            tx_amt1_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Bblocks, 0);
            tx_amt2_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Bblocks, 0);
            tx_amt3_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Bblocks, 0);
            tx_amt4_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Bblocks, 0);

            tx_send1_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Bblocks, 0);
            tx_send2_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Bblocks, 0);
            tx_send3_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Bblocks, 0);
            tx_send4_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Bblocks, 0);

            tx_receive1_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Bblocks, 0);
            tx_receive2_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Bblocks, 0);
            tx_receive3_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Bblocks, 0);
            tx_receive4_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Bblocks, 0);

            // Block 2
            tb_block_b2.TextChanged += tb_block_b2_TextChanged;
            tb_nonce_b2.TextChanged += tb_nonce_b2_TextChanged;

            tx_amt1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Bblocks, 1);
            tx_amt2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Bblocks, 1);

            tx_send1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Bblocks, 1);
            tx_send2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Bblocks, 1);

            tx_receive1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Bblocks, 1);
            tx_receive2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Bblocks, 1);

            // Blcok 3 
            tb_block_b3.TextChanged += tb_block_b3_TextChanged;
            tb_nonce_b3.TextChanged += tb_nonce_b3_TextChanged;

            tx_amt1_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Bblocks, 2);
            tx_amt2_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Bblocks, 2);
            tx_amt3_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Bblocks, 2);
            tx_amt4_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Bblocks, 2);

            tx_send1_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Bblocks, 2);
            tx_send2_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Bblocks, 2);
            tx_send3_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Bblocks, 2);
            tx_send4_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Bblocks, 2);

            tx_receive1_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Bblocks, 2);
            tx_receive2_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Bblocks, 2);
            tx_receive3_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Bblocks, 2);
            tx_receive4_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Bblocks, 2);


            // Block 4
            tb_block_b4.TextChanged += tb_block_b4_TextChanged;
            tb_nonce_b4.TextChanged += tb_nonce_b4_TextChanged;

            tx_amt1_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Bblocks, 3);
            tx_amt2_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Bblocks, 3);
            tx_amt3_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Bblocks, 3);

            tx_send1_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Bblocks, 3);
            tx_send2_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Bblocks, 3);
            tx_send3_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Bblocks, 3);

            tx_receive1_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Bblocks, 3);
            tx_receive2_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Bblocks, 3);
            tx_receive3_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Bblocks, 3);
        }

        private void chain_C_eventHandler()
        {
            tb_block_c1.TextChanged += tb_block_c1_TextChanged;
            tb_nonce_c1.TextChanged += tb_nonce_c1_TextChanged;

            // Block 1
            tx_amt1_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Cblocks, 0);
            tx_amt2_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Cblocks, 0);
            tx_amt3_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Cblocks, 0);
            tx_amt4_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Cblocks, 0);

            tx_send1_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Cblocks, 0);
            tx_send2_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Cblocks, 0);
            tx_send3_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Cblocks, 0);
            tx_send4_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Cblocks, 0);

            tx_receive1_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Cblocks, 0);
            tx_receive2_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Cblocks, 0);
            tx_receive3_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Cblocks, 0);
            tx_receive4_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Cblocks, 0);

            // Block 2
            tb_block_c2.TextChanged += tb_block_c2_TextChanged;
            tb_nonce_c2.TextChanged += tb_nonce_c2_TextChanged;

            tx_amt1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Cblocks, 1);
            tx_amt2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Cblocks, 1);

            tx_send1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Cblocks, 1);
            tx_send2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Cblocks, 1);

            tx_receive1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Cblocks, 1);
            tx_receive2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Cblocks, 1);

            // Blcok 3 
            tb_block_c3.TextChanged += tb_block_c3_TextChanged;
            tb_nonce_c3.TextChanged += tb_nonce_c3_TextChanged;

            tx_amt1_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Cblocks, 2);
            tx_amt2_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Cblocks, 2);
            tx_amt3_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Cblocks, 2);
            tx_amt4_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 4, Cblocks, 2);

            tx_send1_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Cblocks, 2);
            tx_send2_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Cblocks, 2);
            tx_send3_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Cblocks, 2);
            tx_send4_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 4, Cblocks, 2);

            tx_receive1_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Cblocks, 2);
            tx_receive2_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Cblocks, 2);
            tx_receive3_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Cblocks, 2);
            tx_receive4_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 4, Cblocks, 2);


            // Block 4
            tb_block_c4.TextChanged += tb_block_c4_TextChanged;
            tb_nonce_c4.TextChanged += tb_nonce_c4_TextChanged;

            tx_amt1_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Cblocks, 3);
            tx_amt2_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Cblocks, 3);
            tx_amt3_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 3, Cblocks, 3);

            tx_send1_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Cblocks, 3);
            tx_send2_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Cblocks, 3);
            tx_send3_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 3, Cblocks, 3);

            tx_receive1_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Cblocks, 3);
            tx_receive2_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Cblocks, 3);
            tx_receive3_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 3, Cblocks, 3);

        }

        public void Chain_TextChanged(object sender, EventArgs e, string member, int tx_number, Block[] blocks, int block_idx)
        {
            int idx = tx_number - 1;
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "amount")
            {
                if (changedTextBox.Text != "")
                    blocks[block_idx].transactions[idx].amount = int.Parse(changedTextBox.Text);
                else
                    blocks[block_idx].transactions[idx].amount = 0;
            }
            else if (member == "sender")
                blocks[block_idx].transactions[idx].sender = changedTextBox.Text;
            else if (member == "receiver")
                blocks[block_idx].transactions[idx].receiver = changedTextBox.Text;

            blocks[block_idx].transactions[idx].CalculateTransactionHash();
            blocks[block_idx].CalculateMerkleRoot();
            Hash.UpdateChain(blocks, block_idx);
            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks) 
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks) 
                UpdateChain_C_TextBoxes();
        }

        private void UpdateChain_A_TextBoxes()
        {
            tb_prev_a1.Text = Ablocks[0].prev_hash.ToString();
            tb_hash_a1.Text = Ablocks[0].hash.ToString();
            UpdateBackgroundColor(Ablocks[0], 0, panel1);

            tb_prev_a2.Text = Ablocks[1].prev_hash.ToString();
            tb_hash_a2.Text = Ablocks[1].hash.ToString();
            UpdateBackgroundColor(Ablocks[1], 0, panel2);

            tb_prev_a3.Text = Ablocks[2].prev_hash.ToString();
            tb_hash_a3.Text = Ablocks[2].hash.ToString();
            UpdateBackgroundColor(Ablocks[2], 0, panel3);

            tb_prev_a4.Text = Ablocks[3].prev_hash.ToString();
            tb_hash_a4.Text = Ablocks[3].hash.ToString();
            UpdateBackgroundColor(Ablocks[3], 0, panel4);
        }

        private void UpdateChain_B_TextBoxes()
        {
            tb_prev_b1.Text = Bblocks[0].prev_hash.ToString();
            tb_hash_b1.Text = Bblocks[0].hash.ToString();
            UpdateBackgroundColor(Bblocks[0], 0, panel5);

            tb_prev_b2.Text = Bblocks[1].prev_hash.ToString();
            tb_hash_b2.Text = Bblocks[1].hash.ToString();
            UpdateBackgroundColor(Bblocks[1], 0, panel6);

            tb_prev_b3.Text = Bblocks[2].prev_hash.ToString();
            tb_hash_b3.Text = Bblocks[2].hash.ToString();
            UpdateBackgroundColor(Bblocks[2], 0, panel7);

            tb_prev_b4.Text = Bblocks[3].prev_hash.ToString();
            tb_hash_b4.Text = Bblocks[3].hash.ToString();
            UpdateBackgroundColor(Bblocks[3], 0, panel8);
        }

        private void UpdateChain_C_TextBoxes()
        {
            tb_prev_c1.Text = Cblocks[0].prev_hash.ToString();
            tb_hash_c1.Text = Cblocks[0].hash.ToString();
            UpdateBackgroundColor(Cblocks[0], 0, panel9);

            tb_prev_c2.Text = Cblocks[1].prev_hash.ToString();
            tb_hash_c2.Text = Cblocks[1].hash.ToString();
            UpdateBackgroundColor(Cblocks[1], 0, panel10);

            tb_prev_c3.Text = Cblocks[2].prev_hash.ToString();
            tb_hash_c3.Text = Cblocks[2].hash.ToString();
            UpdateBackgroundColor(Cblocks[2], 0, panel11);

            tb_prev_c4.Text = Cblocks[3].prev_hash.ToString();
            tb_hash_c4.Text = Cblocks[3].hash.ToString();
            UpdateBackgroundColor(Cblocks[3], 0, panel12);
        }

        private void UpdateBackgroundColor(Block block, int idx, Panel panel)
        {

            switch (idx)
            {
                case 0:
                    {
                        if (block.isValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 1:
                    {
                        if (block.isValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 2:
                    {
                        if (block.isValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 3:
                    {
                        if (block.isValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
            }
        }

        private void UC_Distributed_Load_Chain_A()
        {
            tb_block_a1.Text = Ablocks[0].number.ToString();
            tb_nonce_a1.Text = Ablocks[0].nonce.ToString();
            tb_prev_a1.Text = Ablocks[0].prev_hash.ToString();
            tb_hash_a1.Text = Ablocks[0].hash.ToString();

            tb_block_a2.Text = Ablocks[1].number.ToString();
            tb_nonce_a2.Text = Ablocks[1].nonce.ToString();
            tb_prev_a2.Text = Ablocks[1].prev_hash.ToString();
            tb_hash_a2.Text = Ablocks[1].hash.ToString();

            tb_block_a3.Text = Ablocks[2].number.ToString();
            tb_nonce_a3.Text = Ablocks[2].nonce.ToString();
            tb_prev_a3.Text = Ablocks[2].prev_hash.ToString();
            tb_hash_a3.Text = Ablocks[2].hash.ToString();

            tb_block_a4.Text = Ablocks[3].number.ToString();
            tb_nonce_a4.Text = Ablocks[3].nonce.ToString();
            tb_prev_a4.Text = Ablocks[3].prev_hash.ToString();
            tb_hash_a4.Text = Ablocks[3].hash.ToString();


            // Transactions
            // Block 1
            tx_amt1_a1.Text = Ablocks[0].transactions[0].amount.ToString();
            tx_send1_a1.Text = Ablocks[0].transactions[0].sender;
            tx_receive1_a1.Text = Ablocks[0].transactions[0].receiver;

            tx_amt2_a1.Text = Ablocks[0].transactions[1].amount.ToString();
            tx_send2_a1.Text = Ablocks[0].transactions[1].sender;
            tx_receive2_a1.Text = Ablocks[0].transactions[1].receiver;

            tx_amt3_a1.Text = Ablocks[0].transactions[2].amount.ToString();
            tx_send3_a1.Text = Ablocks[0].transactions[2].sender;
            tx_receive3_a1.Text = Ablocks[0].transactions[2].receiver;

            tx_amt4_a1.Text = Ablocks[0].transactions[3].amount.ToString();
            tx_send4_a1.Text = Ablocks[0].transactions[3].sender;
            tx_receive4_a1.Text = Ablocks[0].transactions[3].receiver;

            // Block 2
            tx_amt1_a2.Text = Ablocks[1].transactions[0].amount.ToString();
            tx_send1_a2.Text = Ablocks[1].transactions[0].sender;
            tx_receive1_a2.Text = Ablocks[1].transactions[0].receiver;

            tx_amt2_a2.Text = Ablocks[1].transactions[1].amount.ToString();
            tx_send2_a2.Text = Ablocks[1].transactions[1].sender;
            tx_receive2_a2.Text = Ablocks[1].transactions[1].receiver;

            // Block 3
            tx_amt1_a3.Text = Ablocks[2].transactions[0].amount.ToString();
            tx_send1_a3.Text = Ablocks[2].transactions[0].sender;
            tx_receive1_a3.Text = Ablocks[2].transactions[0].receiver;

            tx_amt2_a3.Text = Ablocks[2].transactions[1].amount.ToString();
            tx_send2_a3.Text = Ablocks[2].transactions[1].sender;
            tx_receive2_a3.Text = Ablocks[2].transactions[1].receiver;

            tx_amt3_a3.Text = Ablocks[2].transactions[2].amount.ToString();
            tx_send3_a3.Text = Ablocks[2].transactions[2].sender;
            tx_receive3_a3.Text = Ablocks[2].transactions[2].receiver;

            tx_amt4_a3.Text = Ablocks[2].transactions[3].amount.ToString();
            tx_send4_a3.Text = Ablocks[2].transactions[3].sender;
            tx_receive4_a3.Text = Ablocks[2].transactions[3].receiver;

            // Block 4
            tx_amt1_a4.Text = Ablocks[3].transactions[0].amount.ToString();
            tx_send1_a4.Text = Ablocks[3].transactions[0].sender;
            tx_receive1_a4.Text = Ablocks[3].transactions[0].receiver;

            tx_amt2_a4.Text = Ablocks[3].transactions[1].amount.ToString();
            tx_send2_a4.Text = Ablocks[3].transactions[1].sender;
            tx_receive2_a4.Text = Ablocks[3].transactions[1].receiver;

            tx_amt3_a4.Text = Ablocks[3].transactions[2].amount.ToString();
            tx_send3_a4.Text = Ablocks[3].transactions[2].sender;
            tx_receive3_a4.Text = Ablocks[3].transactions[2].receiver;

        }

        private void UC_Distributed_Load_Chain_B()
        {
            tb_block_b1.Text = Bblocks[0].number.ToString();
            tb_nonce_b1.Text = Bblocks[0].nonce.ToString();
            tb_prev_b1.Text = Bblocks[0].prev_hash.ToString();
            tb_hash_b1.Text = Bblocks[0].hash.ToString();

            tb_block_b2.Text = Bblocks[1].number.ToString();
            tb_nonce_b2.Text = Bblocks[1].nonce.ToString();
            tb_prev_b2.Text = Bblocks[1].prev_hash.ToString();
            tb_hash_b2.Text = Bblocks[1].hash.ToString();

            tb_block_b3.Text = Bblocks[2].number.ToString();
            tb_nonce_b3.Text = Bblocks[2].nonce.ToString();
            tb_prev_b3.Text = Bblocks[2].prev_hash.ToString();
            tb_hash_b3.Text = Bblocks[2].hash.ToString();

            tb_block_b4.Text = Bblocks[3].number.ToString();
            tb_nonce_b4.Text = Bblocks[3].nonce.ToString();
            tb_prev_b4.Text = Bblocks[3].prev_hash.ToString();
            tb_hash_b4.Text = Bblocks[3].hash.ToString();

            // Transactions
            // Block 1
            tx_amt1_b1.Text = Bblocks[0].transactions[0].amount.ToString();
            tx_send1_b1.Text = Bblocks[0].transactions[0].sender;
            tx_receive1_b1.Text = Bblocks[0].transactions[0].receiver;

            tx_amt2_b1.Text = Bblocks[0].transactions[1].amount.ToString();
            tx_send2_b1.Text = Bblocks[0].transactions[1].sender;
            tx_receive2_b1.Text = Bblocks[0].transactions[1].receiver;

            tx_amt3_b1.Text = Bblocks[0].transactions[2].amount.ToString();
            tx_send3_b1.Text = Bblocks[0].transactions[2].sender;
            tx_receive3_b1.Text = Bblocks[0].transactions[2].receiver;

            tx_amt4_b1.Text = Bblocks[0].transactions[3].amount.ToString();
            tx_send4_b1.Text = Bblocks[0].transactions[3].sender;
            tx_receive4_b1.Text = Bblocks[0].transactions[3].receiver;

            // Block 2
            tx_amt1_b2.Text = Bblocks[1].transactions[0].amount.ToString();
            tx_send1_b2.Text = Bblocks[1].transactions[0].sender;
            tx_receive1_b2.Text = Bblocks[1].transactions[0].receiver;

            tx_amt2_b2.Text = Bblocks[1].transactions[1].amount.ToString();
            tx_send2_b2.Text = Bblocks[1].transactions[1].sender;
            tx_receive2_b2.Text = Bblocks[1].transactions[1].receiver;

            // Block 3
            tx_amt1_b3.Text = Bblocks[2].transactions[0].amount.ToString();
            tx_send1_b3.Text = Bblocks[2].transactions[0].sender;
            tx_receive1_b3.Text = Bblocks[2].transactions[0].receiver;

            tx_amt2_b3.Text = Bblocks[2].transactions[1].amount.ToString();
            tx_send2_b3.Text = Bblocks[2].transactions[1].sender;
            tx_receive2_b3.Text = Bblocks[2].transactions[1].receiver;

            tx_amt3_b3.Text = Bblocks[2].transactions[2].amount.ToString();
            tx_send3_b3.Text = Bblocks[2].transactions[2].sender;
            tx_receive3_b3.Text = Bblocks[2].transactions[2].receiver;

            tx_amt4_b3.Text = Bblocks[2].transactions[3].amount.ToString();
            tx_send4_b3.Text = Bblocks[2].transactions[3].sender;
            tx_receive4_b3.Text = Bblocks[2].transactions[3].receiver;

            // Block 4
            tx_amt1_b4.Text = Bblocks[3].transactions[0].amount.ToString();
            tx_send1_b4.Text = Bblocks[3].transactions[0].sender;
            tx_receive1_b4.Text = Bblocks[3].transactions[0].receiver;

            tx_amt2_b4.Text = Bblocks[3].transactions[1].amount.ToString();
            tx_send2_b4.Text = Bblocks[3].transactions[1].sender;
            tx_receive2_b4.Text = Bblocks[3].transactions[1].receiver;

            tx_amt3_b4.Text = Bblocks[3].transactions[2].amount.ToString();
            tx_send3_b4.Text = Bblocks[3].transactions[2].sender;
            tx_receive3_b4.Text = Bblocks[3].transactions[2].receiver;
        }

        private void UC_Distributed_Load_Chain_C()
        {
            tb_block_c1.Text = Cblocks[0].number.ToString();
            tb_nonce_c1.Text = Cblocks[0].nonce.ToString();
            tb_prev_c1.Text = Cblocks[0].prev_hash.ToString();
            tb_hash_c1.Text = Cblocks[0].hash.ToString();

            tb_block_c2.Text = Cblocks[1].number.ToString();
            tb_nonce_c2.Text = Cblocks[1].nonce.ToString();
            tb_prev_c2.Text = Cblocks[1].prev_hash.ToString();
            tb_hash_c2.Text = Cblocks[1].hash.ToString();

            tb_block_c3.Text = Cblocks[2].number.ToString();
            tb_nonce_c3.Text = Cblocks[2].nonce.ToString();
            tb_prev_c3.Text = Cblocks[2].prev_hash.ToString();
            tb_hash_c3.Text = Cblocks[2].hash.ToString();

            tb_block_c4.Text = Cblocks[3].number.ToString();
            tb_nonce_c4.Text = Cblocks[3].nonce.ToString();
            tb_prev_c4.Text = Cblocks[3].prev_hash.ToString();
            tb_hash_c4.Text = Cblocks[3].hash.ToString();


            // Transactions
            // Block 1
            tx_amt1_c1.Text = Cblocks[0].transactions[0].amount.ToString();
            tx_send1_c1.Text = Cblocks[0].transactions[0].sender;
            tx_receive1_c1.Text = Cblocks[0].transactions[0].receiver;

            tx_amt2_c1.Text = Cblocks[0].transactions[1].amount.ToString();
            tx_send2_c1.Text = Cblocks[0].transactions[1].sender;
            tx_receive2_c1.Text = Cblocks[0].transactions[1].receiver;

            tx_amt3_c1.Text = Cblocks[0].transactions[2].amount.ToString();
            tx_send3_c1.Text = Cblocks[0].transactions[2].sender;
            tx_receive3_c1.Text = Cblocks[0].transactions[2].receiver;

            tx_amt4_c1.Text = Cblocks[0].transactions[3].amount.ToString();
            tx_send4_c1.Text = Cblocks[0].transactions[3].sender;
            tx_receive4_c1.Text = Cblocks[0].transactions[3].receiver;

            // Block 2
            tx_amt1_c2.Text = Cblocks[1].transactions[0].amount.ToString();
            tx_send1_c2.Text = Cblocks[1].transactions[0].sender;
            tx_receive1_c2.Text = Cblocks[1].transactions[0].receiver;

            tx_amt2_c2.Text = Cblocks[1].transactions[1].amount.ToString();
            tx_send2_c2.Text = Cblocks[1].transactions[1].sender;
            tx_receive2_c2.Text = Cblocks[1].transactions[1].receiver;

            // Block 3
            tx_amt1_c3.Text = Cblocks[2].transactions[0].amount.ToString();
            tx_send1_c3.Text = Cblocks[2].transactions[0].sender;
            tx_receive1_c3.Text = Cblocks[2].transactions[0].receiver;

            tx_amt2_c3.Text = Cblocks[2].transactions[1].amount.ToString();
            tx_send2_c3.Text = Cblocks[2].transactions[1].sender;
            tx_receive2_c3.Text = Cblocks[2].transactions[1].receiver;

            tx_amt3_c3.Text = Cblocks[2].transactions[2].amount.ToString();
            tx_send3_c3.Text = Cblocks[2].transactions[2].sender;
            tx_receive3_c3.Text = Cblocks[2].transactions[2].receiver;

            tx_amt4_c3.Text = Cblocks[2].transactions[3].amount.ToString();
            tx_send4_c3.Text = Cblocks[2].transactions[3].sender;
            tx_receive4_c3.Text = Cblocks[2].transactions[3].receiver;

            // Block 4
            tx_amt1_c4.Text = Cblocks[3].transactions[0].amount.ToString();
            tx_send1_c4.Text = Cblocks[3].transactions[0].sender;
            tx_receive1_c4.Text = Cblocks[3].transactions[0].receiver;

            tx_amt2_c4.Text = Cblocks[3].transactions[1].amount.ToString();
            tx_send2_c4.Text = Cblocks[3].transactions[1].sender;
            tx_receive2_c4.Text = Cblocks[3].transactions[1].receiver;

            tx_amt3_c4.Text = Cblocks[3].transactions[2].amount.ToString();
            tx_send3_c4.Text = Cblocks[3].transactions[2].sender;
            tx_receive3_c4.Text = Cblocks[3].transactions[2].receiver;
        }

        private void chain_A_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_a1.Text == "")
                Ablocks[0].number = 0;
            else
                Ablocks[0].number = BigInteger.Parse(tb_block_a1.Text);

            Hash.UpdateChain(Ablocks, 0);
            UpdateChain_A_TextBoxes();
        }

        private void tb_nonce_a1_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_a1.Text == "")
                Ablocks[0].nonce = 0;
            else
                Ablocks[0].nonce = BigInteger.Parse(tb_nonce_a1.Text);

            Hash.UpdateChain(Ablocks, 0);
            UpdateChain_A_TextBoxes();
        }

        private void btn_mine_a1_Click(object sender, EventArgs e)
        {
            Hash.Mine(Ablocks[0]);
            tb_nonce_a1.Text = Ablocks[0].nonce.ToString();
            tb_hash_a1.Text = Ablocks[0].hash.ToString();
            Hash.UpdateChain(Ablocks, 0);
            UpdateChain_A_TextBoxes();
        }

        private void tb_block_a2_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_a2.Text == "")
                Ablocks[1].number = 0;
            else
                Ablocks[1].number = BigInteger.Parse(tb_block_a2.Text);

            Hash.UpdateChain(Ablocks, 1);
            UpdateChain_A_TextBoxes();
        }

        private void tb_nonce_a2_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_a2.Text == "")
                Ablocks[1].nonce = 0;
            else
                Ablocks[1].nonce = BigInteger.Parse(tb_nonce_a2.Text);

            Hash.UpdateChain(Ablocks, 1);
            UpdateChain_A_TextBoxes();
        }


        private void btn_mine_a2_Click(object sender, EventArgs e)
        {
            Hash.Mine(Ablocks[1]);
            tb_nonce_a2.Text = Ablocks[1].nonce.ToString();
            tb_hash_a2.Text = Ablocks[1].hash.ToString();
            Hash.UpdateChain(Ablocks, 1);
            UpdateChain_A_TextBoxes();
        }

        private void tb_block_a3_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_a3.Text == "")
                Ablocks[2].number = 0;
            else
                Ablocks[2].number = BigInteger.Parse(tb_block_a3.Text);

            Hash.UpdateChain(Ablocks, 2);
            UpdateChain_A_TextBoxes();
        }

        private void tb_nonce_a3_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_a3.Text == "")
                Ablocks[2].nonce = 0;
            else
                Ablocks[2].nonce = BigInteger.Parse(tb_nonce_a3.Text);

            Hash.UpdateChain(Ablocks, 2);
            UpdateChain_A_TextBoxes();
        }


        private void btn_mine_a3_Click(object sender, EventArgs e)
        {
            Hash.Mine(Ablocks[2]);
            tb_nonce_a3.Text = Ablocks[2].nonce.ToString();
            tb_hash_a3.Text = Ablocks[2].hash.ToString();
            Hash.UpdateChain(Ablocks, 2);
            UpdateChain_A_TextBoxes();
        }

        private void tb_block_a4_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_a4.Text == "")
                Ablocks[3].number = 0;
            else
                Ablocks[3].number = BigInteger.Parse(tb_block_a4.Text);


            Hash.UpdateChain(Ablocks, 3);
            UpdateChain_A_TextBoxes();
        }

        private void tb_nonce_a4_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_a4.Text == "")
                Ablocks[3].nonce = 0;
            else
                Ablocks[3].nonce = BigInteger.Parse(tb_nonce_a4.Text);

            Hash.UpdateChain(Ablocks, 3);
            UpdateChain_A_TextBoxes();
        }


        private void btn_mine_a4_Click(object sender, EventArgs e)
        {
            Hash.Mine(Ablocks[3]);
            tb_nonce_a4.Text = Ablocks[3].nonce.ToString();
            tb_hash_a4.Text = Ablocks[3].hash.ToString();
            Hash.UpdateChain(Ablocks, 3);
            UpdateChain_A_TextBoxes();
        }

        private void tb_block_b1_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_b1.Text == "")
                Bblocks[0].number = 0;
            else
                Bblocks[0].number = BigInteger.Parse(tb_block_b1.Text);

            Hash.UpdateChain(Bblocks, 0);
            UpdateChain_B_TextBoxes();
        }

        private void tb_nonce_b1_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_b1.Text == "")
                Bblocks[0].nonce = 0;
            else
                Bblocks[0].nonce = BigInteger.Parse(tb_nonce_b1.Text);

            Hash.UpdateChain(Bblocks, 0);
            UpdateChain_B_TextBoxes();
        }


        private void btn_mine_b1_Click(object sender, EventArgs e)
        {
            Hash.Mine(Bblocks[0]);
            tb_nonce_b1.Text = Bblocks[0].nonce.ToString();
            tb_hash_b1.Text = Bblocks[0].hash.ToString();
            Hash.UpdateChain(Bblocks, 0);
            UpdateChain_B_TextBoxes();
        }

        private void tb_block_b2_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_b2.Text == "")
                Bblocks[1].number = 0;
            else
                Bblocks[1].number = BigInteger.Parse(tb_block_b2.Text);

            Hash.UpdateChain(Bblocks, 1);
            UpdateChain_B_TextBoxes();
        }

        private void tb_nonce_b2_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_b2.Text == "")
                Bblocks[1].nonce = 0;
            else
                Bblocks[1].nonce = BigInteger.Parse(tb_nonce_b2.Text);

            Hash.UpdateChain(Bblocks, 1);
            UpdateChain_B_TextBoxes();
        }



        private void btn_mine_b2_Click(object sender, EventArgs e)
        {
            Hash.Mine(Bblocks[1]);
            tb_nonce_b2.Text = Bblocks[1].nonce.ToString();
            tb_hash_b2.Text = Bblocks[1].hash.ToString();
            Hash.UpdateChain(Bblocks, 1);
            UpdateChain_B_TextBoxes();
        }

        private void tb_block_b3_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_b3.Text == "")
                Bblocks[2].number = 0;
            else
                Bblocks[2].number = BigInteger.Parse(tb_block_b3.Text);

            Hash.UpdateChain(Bblocks, 2);
            UpdateChain_B_TextBoxes();
        }

        private void tb_nonce_b3_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_b3.Text == "")
                Bblocks[2].nonce = 0;
            else
                Bblocks[2].nonce = BigInteger.Parse(tb_nonce_b3.Text);

            Hash.UpdateChain(Bblocks, 2);
            UpdateChain_B_TextBoxes();
        }


        private void btn_mine_b3_Click(object sender, EventArgs e)
        {
            Hash.Mine(Bblocks[2]);
            tb_nonce_b3.Text = Bblocks[2].nonce.ToString();
            tb_hash_b3.Text = Bblocks[2].hash.ToString();
            Hash.UpdateChain(Bblocks, 2);
            UpdateChain_B_TextBoxes();
        }

        private void tb_block_b4_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_b4.Text == "")
                Bblocks[3].number = 0;
            else
                Bblocks[3].number = BigInteger.Parse(tb_block_b4.Text);

            Hash.UpdateChain(Bblocks, 3);
            UpdateChain_B_TextBoxes();
        }

        private void tb_nonce_b4_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_b4.Text == "")
                Bblocks[3].nonce = 0;
            else
                Bblocks[3].nonce = BigInteger.Parse(tb_nonce_b4.Text);

            Hash.UpdateChain(Bblocks, 3);
            UpdateChain_B_TextBoxes();
        }

        private void btn_mine_b4_Click(object sender, EventArgs e)
        {
            Hash.Mine(Bblocks[3]);
            tb_nonce_b4.Text = Bblocks[3].nonce.ToString();
            tb_hash_b4.Text = Bblocks[3].hash.ToString();
            Hash.UpdateChain(Bblocks, 3);
            UpdateChain_B_TextBoxes();
        }

        private void tb_block_c1_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_c1.Text == "")
                Cblocks[0].number = 0;
            else
                Cblocks[0].number = BigInteger.Parse(tb_block_c1.Text);

            Hash.UpdateChain(Cblocks, 0);
            UpdateChain_C_TextBoxes();
        }

        private void tb_nonce_c1_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_c1.Text == "")
                Cblocks[0].nonce = 0;
            else
                Cblocks[0].nonce = BigInteger.Parse(tb_nonce_c1.Text);

            Hash.UpdateChain(Cblocks, 0);
            UpdateChain_C_TextBoxes();
        }

        private void btn_mine_c1_Click(object sender, EventArgs e)
        {
            Hash.Mine(Cblocks[0]);
            tb_nonce_c1.Text = Cblocks[0].nonce.ToString();
            tb_hash_c1.Text = Cblocks[0].hash.ToString();
            Hash.UpdateChain(Cblocks, 0);
            UpdateChain_C_TextBoxes();
        }

        private void tb_block_c2_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_c2.Text == "")
                Cblocks[1].number = 0;
            else
                Cblocks[1].number = BigInteger.Parse(tb_block_c2.Text);


            Hash.UpdateChain(Cblocks, 1);
            UpdateChain_C_TextBoxes();
        }

        private void tb_nonce_c2_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_c2.Text == "")
                Cblocks[1].nonce = 0;
            else
                Cblocks[1].nonce = BigInteger.Parse(tb_nonce_c2.Text);

            Hash.UpdateChain(Cblocks, 1);
            UpdateChain_C_TextBoxes();
        }

        private void btn_mine_c2_Click(object sender, EventArgs e)
        {
            Hash.Mine(Cblocks[1]);
            tb_nonce_c2.Text = Cblocks[1].nonce.ToString();
            tb_hash_c2.Text = Cblocks[1].hash.ToString();
            Hash.UpdateChain(Cblocks, 1);
            UpdateChain_C_TextBoxes();
        }

        private void tb_block_c3_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_c3.Text == "")
                Cblocks[2].number = 0;
            else
                Cblocks[2].number = BigInteger.Parse(tb_block_c3.Text);

            Hash.UpdateChain(Cblocks, 2);
            UpdateChain_C_TextBoxes();
        }

        private void tb_nonce_c3_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_c3.Text == "")
                Cblocks[2].nonce = 0;
            else
                Cblocks[2].nonce = BigInteger.Parse(tb_nonce_c3.Text);

            Hash.UpdateChain(Cblocks, 2);
            UpdateChain_C_TextBoxes();
        }



        private void btn_mine_c3_Click(object sender, EventArgs e)
        {
            Hash.Mine(Cblocks[2]);
            tb_nonce_c3.Text = Cblocks[2].nonce.ToString();
            tb_hash_c3.Text = Cblocks[2].hash.ToString();
            Hash.UpdateChain(Cblocks, 2);
            UpdateChain_C_TextBoxes();
        }

        private void tb_block_c4_TextChanged(object sender, EventArgs e)
        {
            if (tb_block_c4.Text == "")
                Cblocks[3].number = 0;
            else
                Cblocks[3].number = BigInteger.Parse(tb_block_c4.Text);

            Hash.UpdateChain(Cblocks, 3);
            UpdateChain_C_TextBoxes();
        }

        private void tb_nonce_c4_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_c4.Text == "")
                Cblocks[3].nonce = 0;
            else
                Cblocks[3].nonce = BigInteger.Parse(tb_nonce_c4.Text);

            Hash.UpdateChain(Cblocks, 3);
            UpdateChain_C_TextBoxes();
        }


        private void btn_mine_c4_Click(object sender, EventArgs e)
        {
            Hash.Mine(Cblocks[3]);
            tb_nonce_c4.Text = Cblocks[3].nonce.ToString();
            tb_hash_c4.Text = Cblocks[3].hash.ToString();
            Hash.UpdateChain(Cblocks, 3);
            UpdateChain_C_TextBoxes();
        }


        private void UC_Tokens_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }

    }
}
