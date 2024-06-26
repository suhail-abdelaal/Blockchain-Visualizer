﻿using Microsoft.VisualBasic.Devices;
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

        // Declaration of three arrays to hold Block objects representing blockchain data for chains A, B, and C
        Block[] Ablocks;
        Block[] Bblocks;
        Block[] Cblocks;

        // Constructor for the UC_Tokens class
        public UC_Tokens()
        {
            // Initialize the blockchain arrays with a length of 4
            Ablocks = new Block[4];
            Bblocks = new Block[4];
            Cblocks = new Block[4];

            // Create genesis blocks for chains A, B, and C
            Ablocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");

            // Loop through the remaining blocks to initialize them
            for (int i = 1; i < Ablocks.Length; i++)
            {
                Ablocks[i] = new Block();
                Bblocks[i] = new Block();
                Cblocks[i] = new Block();
            }

            // Fill transaction data for the blocks
            FillTransactions();

            // Calculate Merkle root and mine genesis blocks for each chain
            Ablocks[0].CalculateMerkleRoot();
            Bblocks[0].CalculateMerkleRoot();
            Cblocks[0].CalculateMerkleRoot();
            BlockHashUtility.Mine(Ablocks[0]);
            BlockHashUtility.Mine(Bblocks[0]);
            BlockHashUtility.Mine(Cblocks[0]);

            // Loop through the blocks (starting from index 1) to initialize them with relevant data
            for (int i = 1; i < Ablocks.Length; i++)
            {
                string previousHash = Ablocks[i - 1].BlkHash.ToString();

                // Initialize blocks for chains A, B, and C with relevant data
                Ablocks[i].Number = (i + 1).ToString();
                Ablocks[i].Nonce = "0";
                Ablocks[i].PrevHash.Append(previousHash);
                Ablocks[i].CalculateMerkleRoot();
                BlockHashUtility.Mine(Ablocks[i]);

                Bblocks[i].Number = (i + 1).ToString();
                Bblocks[i].BlkHash = Ablocks[i].BlkHash;
                Bblocks[i].PrevHash.Append(previousHash);
                Bblocks[i].Nonce = Ablocks[i].Nonce;
                Bblocks[i].MerkleRoot = Ablocks[i].MerkleRoot;

                Cblocks[i].Number = (i + 1).ToString();
                Cblocks[i].BlkHash = Ablocks[i].BlkHash;
                Cblocks[i].PrevHash.Append(previousHash);
                Cblocks[i].Nonce = Ablocks[i].Nonce;
                Cblocks[i].MerkleRoot = Ablocks[i].MerkleRoot;
            }

            // Initialize UI components and event handlers
            InitializeComponent();
            Chain_A_EventHandler();
            Chain_B_EventHandler();
            Chain_C_EventHandler();
        }

        // Method to load blockchain data into the user interface
        private void UC_Tokens_Load(object sender, EventArgs e)
        {
            UC_Distributed_Load_Chain_A();
            UC_Distributed_Load_Chain_B();
            UC_Distributed_Load_Chain_C();
        }

        // Method to load blockchain data for chain A into the user interface
        private void UC_Distributed_Load_Chain_A()
        {
            tb_block_a1.Text = Ablocks[0].Number;
            tb_nonce_a1.Text = Ablocks[0].Nonce;
            tb_prev_a1.Text = Ablocks[0].PrevHash.ToString();
            tb_hash_a1.Text = Ablocks[0].BlkHash.ToString();

            tb_block_a2.Text = Ablocks[1].Number;
            tb_nonce_a2.Text = Ablocks[1].Nonce;
            tb_prev_a2.Text = Ablocks[1].PrevHash.ToString();
            tb_hash_a2.Text = Ablocks[1].BlkHash.ToString();

            tb_block_a3.Text = Ablocks[2].Number;
            tb_nonce_a3.Text = Ablocks[2].Nonce;
            tb_prev_a3.Text = Ablocks[2].PrevHash.ToString();
            tb_hash_a3.Text = Ablocks[2].BlkHash.ToString();

            tb_block_a4.Text = Ablocks[3].Number;
            tb_nonce_a4.Text = Ablocks[3].Nonce;
            tb_prev_a4.Text = Ablocks[3].PrevHash.ToString();
            tb_hash_a4.Text = Ablocks[3].BlkHash.ToString();


            // Transactions
            // Block 1
            tx_amt1_a1.Text = Ablocks[0].Transactions[0].Amount.ToString();
            tx_send1_a1.Text = Ablocks[0].Transactions[0].Sender;
            tx_receive1_a1.Text = Ablocks[0].Transactions[0].Receiver;

            tx_amt2_a1.Text = Ablocks[0].Transactions[1].Amount.ToString();
            tx_send2_a1.Text = Ablocks[0].Transactions[1].Sender;
            tx_receive2_a1.Text = Ablocks[0].Transactions[1].Receiver;

            tx_amt3_a1.Text = Ablocks[0].Transactions[2].Amount.ToString();
            tx_send3_a1.Text = Ablocks[0].Transactions[2].Sender;
            tx_receive3_a1.Text = Ablocks[0].Transactions[2].Receiver;

            tx_amt4_a1.Text = Ablocks[0].Transactions[3].Amount.ToString();
            tx_send4_a1.Text = Ablocks[0].Transactions[3].Sender;
            tx_receive4_a1.Text = Ablocks[0].Transactions[3].Receiver;

            // Block 2
            tx_amt1_a2.Text = Ablocks[1].Transactions[0].Amount.ToString();
            tx_send1_a2.Text = Ablocks[1].Transactions[0].Sender;
            tx_receive1_a2.Text = Ablocks[1].Transactions[0].Receiver;

            tx_amt2_a2.Text = Ablocks[1].Transactions[1].Amount.ToString();
            tx_send2_a2.Text = Ablocks[1].Transactions[1].Sender;
            tx_receive2_a2.Text = Ablocks[1].Transactions[1].Receiver;

            // Block 3
            tx_amt1_a3.Text = Ablocks[2].Transactions[0].Amount.ToString();
            tx_send1_a3.Text = Ablocks[2].Transactions[0].Sender;
            tx_receive1_a3.Text = Ablocks[2].Transactions[0].Receiver;

            tx_amt2_a3.Text = Ablocks[2].Transactions[1].Amount.ToString();
            tx_send2_a3.Text = Ablocks[2].Transactions[1].Sender;
            tx_receive2_a3.Text = Ablocks[2].Transactions[1].Receiver;

            tx_amt3_a3.Text = Ablocks[2].Transactions[2].Amount.ToString();
            tx_send3_a3.Text = Ablocks[2].Transactions[2].Sender;
            tx_receive3_a3.Text = Ablocks[2].Transactions[2].Receiver;

            tx_amt4_a3.Text = Ablocks[2].Transactions[3].Amount.ToString();
            tx_send4_a3.Text = Ablocks[2].Transactions[3].Sender;
            tx_receive4_a3.Text = Ablocks[2].Transactions[3].Receiver;

            // Block 4
            tx_amt1_a4.Text = Ablocks[3].Transactions[0].Amount.ToString();
            tx_send1_a4.Text = Ablocks[3].Transactions[0].Sender;
            tx_receive1_a4.Text = Ablocks[3].Transactions[0].Receiver;

            tx_amt2_a4.Text = Ablocks[3].Transactions[1].Amount.ToString();
            tx_send2_a4.Text = Ablocks[3].Transactions[1].Sender;
            tx_receive2_a4.Text = Ablocks[3].Transactions[1].Receiver;

            tx_amt3_a4.Text = Ablocks[3].Transactions[2].Amount.ToString();
            tx_send3_a4.Text = Ablocks[3].Transactions[2].Sender;
            tx_receive3_a4.Text = Ablocks[3].Transactions[2].Receiver;

        }

        // Method to load blockchain data for chain B into the user interface
        private void UC_Distributed_Load_Chain_B()
        {
            tb_block_b1.Text = Bblocks[0].Number;
            tb_nonce_b1.Text = Bblocks[0].Nonce;
            tb_prev_b1.Text = Bblocks[0].PrevHash.ToString();
            tb_hash_b1.Text = Bblocks[0].BlkHash.ToString();

            tb_block_b2.Text = Bblocks[1].Number;
            tb_nonce_b2.Text = Bblocks[1].Nonce;
            tb_prev_b2.Text = Bblocks[1].PrevHash.ToString();
            tb_hash_b2.Text = Bblocks[1].BlkHash.ToString();

            tb_block_b3.Text = Bblocks[2].Number;
            tb_nonce_b3.Text = Bblocks[2].Nonce;
            tb_prev_b3.Text = Bblocks[2].PrevHash.ToString();
            tb_hash_b3.Text = Bblocks[2].BlkHash.ToString();

            tb_block_b4.Text = Bblocks[3].Number;
            tb_nonce_b4.Text = Bblocks[3].Nonce;
            tb_prev_b4.Text = Bblocks[3].PrevHash.ToString();
            tb_hash_b4.Text = Bblocks[3].BlkHash.ToString();

            // Transactions
            // Block 1
            tx_amt1_b1.Text = Bblocks[0].Transactions[0].Amount.ToString();
            tx_send1_b1.Text = Bblocks[0].Transactions[0].Sender;
            tx_receive1_b1.Text = Bblocks[0].Transactions[0].Receiver;

            tx_amt2_b1.Text = Bblocks[0].Transactions[1].Amount.ToString();
            tx_send2_b1.Text = Bblocks[0].Transactions[1].Sender;
            tx_receive2_b1.Text = Bblocks[0].Transactions[1].Receiver;

            tx_amt3_b1.Text = Bblocks[0].Transactions[2].Amount.ToString();
            tx_send3_b1.Text = Bblocks[0].Transactions[2].Sender;
            tx_receive3_b1.Text = Bblocks[0].Transactions[2].Receiver;

            tx_amt4_b1.Text = Bblocks[0].Transactions[3].Amount.ToString();
            tx_send4_b1.Text = Bblocks[0].Transactions[3].Sender;
            tx_receive4_b1.Text = Bblocks[0].Transactions[3].Receiver;

            // Block 2
            tx_amt1_b2.Text = Bblocks[1].Transactions[0].Amount.ToString();
            tx_send1_b2.Text = Bblocks[1].Transactions[0].Sender;
            tx_receive1_b2.Text = Bblocks[1].Transactions[0].Receiver;

            tx_amt2_b2.Text = Bblocks[1].Transactions[1].Amount.ToString();
            tx_send2_b2.Text = Bblocks[1].Transactions[1].Sender;
            tx_receive2_b2.Text = Bblocks[1].Transactions[1].Receiver;

            // Block 3
            tx_amt1_b3.Text = Bblocks[2].Transactions[0].Amount.ToString();
            tx_send1_b3.Text = Bblocks[2].Transactions[0].Sender;
            tx_receive1_b3.Text = Bblocks[2].Transactions[0].Receiver;

            tx_amt2_b3.Text = Bblocks[2].Transactions[1].Amount.ToString();
            tx_send2_b3.Text = Bblocks[2].Transactions[1].Sender;
            tx_receive2_b3.Text = Bblocks[2].Transactions[1].Receiver;

            tx_amt3_b3.Text = Bblocks[2].Transactions[2].Amount.ToString();
            tx_send3_b3.Text = Bblocks[2].Transactions[2].Sender;
            tx_receive3_b3.Text = Bblocks[2].Transactions[2].Receiver;

            tx_amt4_b3.Text = Bblocks[2].Transactions[3].Amount.ToString();
            tx_send4_b3.Text = Bblocks[2].Transactions[3].Sender;
            tx_receive4_b3.Text = Bblocks[2].Transactions[3].Receiver;

            // Block 4
            tx_amt1_b4.Text = Bblocks[3].Transactions[0].Amount.ToString();
            tx_send1_b4.Text = Bblocks[3].Transactions[0].Sender;
            tx_receive1_b4.Text = Bblocks[3].Transactions[0].Receiver;

            tx_amt2_b4.Text = Bblocks[3].Transactions[1].Amount.ToString();
            tx_send2_b4.Text = Bblocks[3].Transactions[1].Sender;
            tx_receive2_b4.Text = Bblocks[3].Transactions[1].Receiver;

            tx_amt3_b4.Text = Bblocks[3].Transactions[2].Amount.ToString();
            tx_send3_b4.Text = Bblocks[3].Transactions[2].Sender;
            tx_receive3_b4.Text = Bblocks[3].Transactions[2].Receiver;
        }

        // Method to load blockchain data for chain C into the user interface
        private void UC_Distributed_Load_Chain_C()
        {
            tb_block_c1.Text = Cblocks[0].Number;
            tb_nonce_c1.Text = Cblocks[0].Nonce;
            tb_prev_c1.Text = Cblocks[0].PrevHash.ToString();
            tb_hash_c1.Text = Cblocks[0].BlkHash.ToString();

            tb_block_c2.Text = Cblocks[1].Number;
            tb_nonce_c2.Text = Cblocks[1].Nonce;
            tb_prev_c2.Text = Cblocks[1].PrevHash.ToString();
            tb_hash_c2.Text = Cblocks[1].BlkHash.ToString();

            tb_block_c3.Text = Cblocks[2].Number;
            tb_nonce_c3.Text = Cblocks[2].Nonce;
            tb_prev_c3.Text = Cblocks[2].PrevHash.ToString();
            tb_hash_c3.Text = Cblocks[2].BlkHash.ToString();

            tb_block_c4.Text = Cblocks[3].Number;
            tb_nonce_c4.Text = Cblocks[3].Nonce;
            tb_prev_c4.Text = Cblocks[3].PrevHash.ToString();
            tb_hash_c4.Text = Cblocks[3].BlkHash.ToString();


            // Transactions
            // Block 1
            tx_amt1_c1.Text = Cblocks[0].Transactions[0].Amount.ToString();
            tx_send1_c1.Text = Cblocks[0].Transactions[0].Sender;
            tx_receive1_c1.Text = Cblocks[0].Transactions[0].Receiver;

            tx_amt2_c1.Text = Cblocks[0].Transactions[1].Amount.ToString();
            tx_send2_c1.Text = Cblocks[0].Transactions[1].Sender;
            tx_receive2_c1.Text = Cblocks[0].Transactions[1].Receiver;

            tx_amt3_c1.Text = Cblocks[0].Transactions[2].Amount.ToString();
            tx_send3_c1.Text = Cblocks[0].Transactions[2].Sender;
            tx_receive3_c1.Text = Cblocks[0].Transactions[2].Receiver;

            tx_amt4_c1.Text = Cblocks[0].Transactions[3].Amount.ToString();
            tx_send4_c1.Text = Cblocks[0].Transactions[3].Sender;
            tx_receive4_c1.Text = Cblocks[0].Transactions[3].Receiver;

            // Block 2
            tx_amt1_c2.Text = Cblocks[1].Transactions[0].Amount.ToString();
            tx_send1_c2.Text = Cblocks[1].Transactions[0].Sender;
            tx_receive1_c2.Text = Cblocks[1].Transactions[0].Receiver;

            tx_amt2_c2.Text = Cblocks[1].Transactions[1].Amount.ToString();
            tx_send2_c2.Text = Cblocks[1].Transactions[1].Sender;
            tx_receive2_c2.Text = Cblocks[1].Transactions[1].Receiver;

            // Block 3
            tx_amt1_c3.Text = Cblocks[2].Transactions[0].Amount.ToString();
            tx_send1_c3.Text = Cblocks[2].Transactions[0].Sender;
            tx_receive1_c3.Text = Cblocks[2].Transactions[0].Receiver;

            tx_amt2_c3.Text = Cblocks[2].Transactions[1].Amount.ToString();
            tx_send2_c3.Text = Cblocks[2].Transactions[1].Sender;
            tx_receive2_c3.Text = Cblocks[2].Transactions[1].Receiver;

            tx_amt3_c3.Text = Cblocks[2].Transactions[2].Amount.ToString();
            tx_send3_c3.Text = Cblocks[2].Transactions[2].Sender;
            tx_receive3_c3.Text = Cblocks[2].Transactions[2].Receiver;

            tx_amt4_c3.Text = Cblocks[2].Transactions[3].Amount.ToString();
            tx_send4_c3.Text = Cblocks[2].Transactions[3].Sender;
            tx_receive4_c3.Text = Cblocks[2].Transactions[3].Receiver;

            // Block 4
            tx_amt1_c4.Text = Cblocks[3].Transactions[0].Amount.ToString();
            tx_send1_c4.Text = Cblocks[3].Transactions[0].Sender;
            tx_receive1_c4.Text = Cblocks[3].Transactions[0].Receiver;

            tx_amt2_c4.Text = Cblocks[3].Transactions[1].Amount.ToString();
            tx_send2_c4.Text = Cblocks[3].Transactions[1].Sender;
            tx_receive2_c4.Text = Cblocks[3].Transactions[1].Receiver;

            tx_amt3_c4.Text = Cblocks[3].Transactions[2].Amount.ToString();
            tx_send3_c4.Text = Cblocks[3].Transactions[2].Sender;
            tx_receive3_c4.Text = Cblocks[3].Transactions[2].Receiver;
        }

        // Method to fill transaction data for each block
        private void FillTransactions()
        {
            // Block 1
            Ablocks[0].Transactions[0] = new Transaction(10, "Suhail", "Omar");
            Ablocks[0].Transactions[1] = new Transaction(5, "AbdelRahman", "Naser");
            Ablocks[0].Transactions[2] = new Transaction(25, "Taha", "Amr");
            Ablocks[0].Transactions[3] = new Transaction(37, "Saif", "Mostafa");

            Bblocks[0].CopyTransactions(Ablocks[0].Transactions);
            Cblocks[0].CopyTransactions(Ablocks[0].Transactions);

            //Block 2
            Ablocks[1].Transactions[0] = new Transaction(12, "Sara", "Yaser");
            Ablocks[1].Transactions[1] = new Transaction(45, "Nada", "Ola");
            Ablocks[1].Transactions[2] = new Transaction(0, "", "");
            Ablocks[1].Transactions[3] = new Transaction(0, "", "");

            Bblocks[1].CopyTransactions(Ablocks[1].Transactions);
            Cblocks[1].CopyTransactions(Ablocks[1].Transactions);

            //Block 3
            Ablocks[2].Transactions[0] = new Transaction(6, "Omar", "AbdelRahman");
            Ablocks[2].Transactions[1] = new Transaction(5, "Naser", "Mohammed");
            Ablocks[2].Transactions[2] = new Transaction(33, "Tarek", "Hassan");
            Ablocks[2].Transactions[3] = new Transaction(30, "Ola", "Sara");

            Bblocks[2].CopyTransactions(Ablocks[2].Transactions);
            Cblocks[2].CopyTransactions(Ablocks[2].Transactions);

            //Block 4
            Ablocks[3].Transactions[0] = new Transaction(8, "Yaser", "Suhail");
            Ablocks[3].Transactions[1] = new Transaction(22, "Esraa", "Nada");
            Ablocks[3].Transactions[2] = new Transaction(11, "Omar", "Basmala");
            Ablocks[3].Transactions[3] = new Transaction(0, "", "");

            Bblocks[3].CopyTransactions(Ablocks[3].Transactions);
            Cblocks[3].CopyTransactions(Ablocks[3].Transactions);
        }

        // Event handler for updating transaction data when user input changes
        public void Chain_TextChanged(object sender, EventArgs e, string member, int tx_number, Block[] blocks, int block_idx)
        {
            int idx = tx_number - 1;
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "amount")
            {
                if (changedTextBox.Text != "")
                    blocks[block_idx].Transactions[idx].Amount = int.Parse(changedTextBox.Text);
                else
                    blocks[block_idx].Transactions[idx].Amount = 0;
            }
            else if (member == "sender")
                blocks[block_idx].Transactions[idx].Sender = changedTextBox.Text;
            else if (member == "receiver")
                blocks[block_idx].Transactions[idx].Receiver = changedTextBox.Text;

            blocks[block_idx].Transactions[idx].CalculateTransactionHash();
            blocks[block_idx].CalculateMerkleRoot();
            BlockHashUtility.UpdateChain(blocks, block_idx);
            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks) 
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks) 
                UpdateChain_C_TextBoxes();
        }

        // Event handler for updating block data when user input changes
        public void Chain_Block_Nonce_TextChanged(object sender, EventArgs e, string member, Block[] blocks, int block_idx)
        {
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;

            if (member == "number")
                blocks[block_idx].Number = changedTextBox.Text;

            else if (member == "nonce")
                blocks[block_idx].Nonce = changedTextBox.Text;

            BlockHashUtility.UpdateChain(blocks, block_idx);

            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks)
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks)
                UpdateChain_C_TextBoxes();
        }
        // Mines the block at the specified index within the provided array of blocks.
        private void Mine_Click(object sender, EventArgs e, Block[] blocks, int block_idx)
        {
            BlockHashUtility.Mine(blocks[block_idx]);
            BlockHashUtility.UpdateChain(blocks, block_idx);

            // Update the text boxes based on the block array
            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks)
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks)
                UpdateChain_C_TextBoxes();
        }

        // Updates the text boxes for Chain A based on the blocks in the Ablocks array.
        private void UpdateChain_A_TextBoxes()
        {
            // Update text boxes for each block in Chain A
            tb_prev_a1.Text = Ablocks[0].PrevHash.ToString();
            tb_hash_a1.Text = Ablocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[0], 0, panel1);

            tb_prev_a2.Text = Ablocks[1].PrevHash.ToString();
            tb_hash_a2.Text = Ablocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[1], 0, panel2);

            tb_prev_a3.Text = Ablocks[2].PrevHash.ToString();
            tb_hash_a3.Text = Ablocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[2], 0, panel3);

            tb_prev_a4.Text = Ablocks[3].PrevHash.ToString();
            tb_hash_a4.Text = Ablocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[3], 0, panel4);
        }

        // Updates the text boxes for Chain B based on the blocks in the Bblocks array.
        private void UpdateChain_B_TextBoxes()
        {
            // Update text boxes for each block in Chain B
            tb_prev_b1.Text = Bblocks[0].PrevHash.ToString();
            tb_hash_b1.Text = Bblocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[0], 0, panel5);

            tb_prev_b2.Text = Bblocks[1].PrevHash.ToString();
            tb_hash_b2.Text = Bblocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[1], 0, panel6);

            tb_prev_b3.Text = Bblocks[2].PrevHash.ToString();
            tb_hash_b3.Text = Bblocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[2], 0, panel7);

            tb_prev_b4.Text = Bblocks[3].PrevHash.ToString();
            tb_hash_b4.Text = Bblocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[3], 0, panel8);
        }

        // Updates the text boxes for Chain C based on the blocks in the Cblocks array.
        private void UpdateChain_C_TextBoxes()
        {
            // Update text boxes for each block in Chain C
            tb_prev_c1.Text = Cblocks[0].PrevHash.ToString();
            tb_hash_c1.Text = Cblocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[0], 0, panel9);

            tb_prev_c2.Text = Cblocks[1].PrevHash.ToString();
            tb_hash_c2.Text = Cblocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[1], 0, panel10);

            tb_prev_c3.Text = Cblocks[2].PrevHash.ToString();
            tb_hash_c3.Text = Cblocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[2], 0, panel11);

            tb_prev_c4.Text = Cblocks[3].PrevHash.ToString();
            tb_hash_c4.Text = Cblocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[3], 0, panel12);
        }

        private void UpdateBackgroundColor(Block block, int idx, Panel panel)
        {

            switch (idx)
            {
                case 0:
                    {
                        if (block.IsValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 1:
                    {
                        if (block.IsValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 2:
                    {
                        if (block.IsValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
                case 3:
                    {
                        if (block.IsValid)
                            panel.BackColor = Color.MediumAquamarine;
                        else
                            panel.BackColor = Color.Crimson;
                    }
                    break;
            }
        }

        // Event handler for handling user interactions and updating blockchain data for chain A
        private void Chain_A_EventHandler()
        {
            // Block 1 
            tb_block_a1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Ablocks, 0);
            tb_nonce_a1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Ablocks, 0);

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
            tb_block_a2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Ablocks, 1);
            tb_nonce_a2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Ablocks, 1);

            tx_amt1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Ablocks, 1);
            tx_amt2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Ablocks, 1);

            tx_send1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Ablocks, 1);
            tx_send2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Ablocks, 1);

            tx_receive1_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Ablocks, 1);
            tx_receive2_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Ablocks, 1);

            // Blcok 3 
            tb_block_a3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Ablocks, 2);
            tb_nonce_a3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Ablocks, 2);

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
            tb_block_a4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Ablocks, 3);
            tb_nonce_a4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Ablocks, 3);

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

        // Event handler for handling user interactions and updating blockchain data for chain B
        private void Chain_B_EventHandler()
        {
            tb_block_b1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Bblocks, 0);
            tb_nonce_b1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Bblocks, 0);

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
            tb_block_b2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Bblocks, 1);
            tb_nonce_b2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Bblocks, 1);

            tx_amt1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Bblocks, 1);
            tx_amt2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Bblocks, 1);

            tx_send1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Bblocks, 1);
            tx_send2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Bblocks, 1);

            tx_receive1_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Bblocks, 1);
            tx_receive2_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Bblocks, 1);

            // Blcok 3 
            tb_block_b3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Bblocks, 2);
            tb_nonce_b3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Bblocks, 2);

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
            tb_block_b4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Bblocks, 3);
            tb_nonce_b4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Bblocks, 3);

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

        // Event handler for handling user interactions and updating blockchain data for chain C
        private void Chain_C_EventHandler()
        {
            tb_block_c1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Cblocks, 0);
            tb_nonce_c1.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Cblocks, 0);

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
            tb_block_c2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Cblocks, 1);
            tb_nonce_c2.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Cblocks, 1);

            tx_amt1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 1, Cblocks, 1);
            tx_amt2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "amount", 2, Cblocks, 1);

            tx_send1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 1, Cblocks, 1);
            tx_send2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "sender", 2, Cblocks, 1);

            tx_receive1_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 1, Cblocks, 1);
            tx_receive2_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "receiver", 2, Cblocks, 1);

            // Blcok 3 
            tb_block_c3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Cblocks, 2);
            tb_nonce_c3.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Cblocks, 2);

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
            tb_block_c4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "number", Cblocks, 3);
            tb_nonce_c4.TextChanged += (sender, e) => Chain_Block_Nonce_TextChanged(sender, e, "nonce", Cblocks, 3);

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

        // Event handler for key press events in the UC_Tokens control.
        private void UC_Tokens_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers to be entered in the control
            BlockHashUtility.OnlyNumbers(sender, e);
        }

    }
}
