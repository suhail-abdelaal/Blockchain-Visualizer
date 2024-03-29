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

namespace Blockchain_Visualizer.UserControls
{
    // UserControl representing a distributed blockchain view
    public partial class UC_Distributed : UserControl
    {
        // Arrays to hold blocks for each chain
        Block[] Ablocks;
        Block[] Bblocks;
        Block[] Cblocks;

        // Constructor
        public UC_Distributed()
        {
            // Initialize block arrays
            Ablocks = new Block[4];
            Bblocks = new Block[4];
            Cblocks = new Block[4];

            // Initialize genesis blocks and mine them
            Ablocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            BlockHashUtility.Mine(Ablocks[0]);
            BlockHashUtility.Mine(Bblocks[0]);
            BlockHashUtility.Mine(Cblocks[0]);

            // Generate subsequent blocks for each chain and mine them
            for (int i = 1; i < Ablocks.Length; i++)
            {
                string previousHash = Ablocks[i - 1].BlkHash.ToString();

                Ablocks[i] = new Block((i + 1).ToString(), "0", previousHash);
                BlockHashUtility.Mine(Ablocks[i]);

                Bblocks[i] = new Block(Ablocks[i].Number, "0", previousHash);
                Bblocks[i].Nonce = Ablocks[i].Nonce;
                Bblocks[i].BlkHash = Ablocks[i].BlkHash;

                Cblocks[i] = new Block(Ablocks[i].Number, "0", previousHash);
                Cblocks[i].Nonce = Ablocks[i].Nonce;
                Cblocks[i].BlkHash = Ablocks[i].BlkHash;
            }

            // Initialize UI components
            InitializeComponent();

            // Attach event handlers to update UI components
            Chain_A_EventHandler();
            Chain_B_EventHandler();
            Chain_C_EventHandler();
        }

        // Event handler for loading the control
        private void UC_Distributed_Load(object sender, EventArgs e)
        {
            UC_Distributed_Load_Chain_A();
            UC_Distributed_Load_Chain_B();
            UC_Distributed_Load_Chain_C();
        }

        // Load data for Chain A into UI components
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
        }

        // Load data for Chain B into UI components
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
        }

        // Load data for Chain C into UI components
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
        }

        // Event handler to update Chain A
        private void Chain_A_EventHandler()
        {
            tb_block_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 0);
            tb_nonce_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 0);
            tb_data_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 0);

            tb_block_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 1);
            tb_nonce_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 1);
            tb_data_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 1);

            tb_block_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 2);
            tb_nonce_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 2);
            tb_data_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 2);

            tb_block_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 3);
            tb_nonce_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 3);
            tb_data_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 3);
        }

        // Event handler to update Chain B
        private void Chain_B_EventHandler()
        {
            tb_block_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 0);
            tb_nonce_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 0);
            tb_data_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 0);

            tb_block_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 1);
            tb_nonce_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 1);
            tb_data_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 1);

            tb_block_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 2);
            tb_nonce_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 2);
            tb_data_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 2);

            tb_block_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 3);
            tb_nonce_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 3);
            tb_data_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 3);
        }

        // Event handler to update Chain C
        private void Chain_C_EventHandler()
        {
            tb_block_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Cblocks, 0);
            tb_nonce_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Cblocks, 0);
            tb_data_c1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Cblocks, 0);

            tb_block_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Cblocks, 1);
            tb_nonce_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Cblocks, 1);
            tb_data_c2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Cblocks, 1);

            tb_block_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Cblocks, 2);
            tb_nonce_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Cblocks, 2);
            tb_data_c3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Cblocks, 2);

            tb_block_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Cblocks, 3);
            tb_nonce_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Cblocks, 3);
            tb_data_c4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", Cblocks, 3);
        }

        // Method to handle text changes in UI components for block data
        public void Chain_TextChanged(object sender, EventArgs e, string member, Block[] blocks, int block_idx)
        {
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "number")
                blocks[block_idx].Number = changedTextBox.Text;
            else if (member == "nonce")
                blocks[block_idx].Nonce = changedTextBox.Text;
            else if (member == "data")
            {
                blocks[block_idx].Data.Clear();
                blocks[block_idx].Data.Append(changedTextBox.Text);
            }

            BlockHashUtility.UpdateChain(blocks, block_idx);

            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks)
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks)
                UpdateChain_C_TextBoxes();
        }

        // Method to handle mining a block
        private void Mine_Click(object sender, EventArgs e, Block[] blocks, int block_idx)
        {
            BlockHashUtility.Mine(blocks[block_idx]);
            BlockHashUtility.UpdateChain(blocks, block_idx);

            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks)
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks)
                UpdateChain_C_TextBoxes();
        }

        // Method to update UI components for Chain A
        private void UpdateChain_A_TextBoxes()
        {
            tb_nonce_a1.Text = Ablocks[0].Nonce;
            tb_prev_a1.Text = Ablocks[0].PrevHash.ToString();
            tb_hash_a1.Text = Ablocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[0], 0, panel1);

            tb_nonce_a2.Text = Ablocks[1].Nonce;
            tb_prev_a2.Text = Ablocks[1].PrevHash.ToString();
            tb_hash_a2.Text = Ablocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[1], 0, panel2);

            tb_nonce_a3.Text = Ablocks[2].Nonce;
            tb_prev_a3.Text = Ablocks[2].PrevHash.ToString();
            tb_hash_a3.Text = Ablocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[2], 0, panel3);

            tb_nonce_a4.Text = Ablocks[3].Nonce;
            tb_prev_a4.Text = Ablocks[3].PrevHash.ToString();
            tb_hash_a4.Text = Ablocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Ablocks[3], 0, panel4);
        }

        // Method to update UI components for Chain B
        private void UpdateChain_B_TextBoxes()
        {
            tb_nonce_b1.Text = Bblocks[0].Nonce;
            tb_prev_b1.Text = Bblocks[0].PrevHash.ToString();
            tb_hash_b1.Text = Bblocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[0], 0, panel5);

            tb_nonce_b2.Text = Bblocks[1].Nonce;
            tb_prev_b2.Text = Bblocks[1].PrevHash.ToString();
            tb_hash_b2.Text = Bblocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[1], 0, panel6);

            tb_nonce_b3.Text = Bblocks[2].Nonce;
            tb_prev_b3.Text = Bblocks[2].PrevHash.ToString();
            tb_hash_b3.Text = Bblocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[2], 0, panel7);

            tb_nonce_b4.Text = Bblocks[3].Nonce;
            tb_prev_b4.Text = Bblocks[3].PrevHash.ToString();
            tb_hash_b4.Text = Bblocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Bblocks[3], 0, panel8);
        }

        // Method to update UI components for Chain C
        private void UpdateChain_C_TextBoxes()
        {
            tb_nonce_c1.Text = Cblocks[0].Nonce;
            tb_prev_c1.Text = Cblocks[0].PrevHash.ToString();
            tb_hash_c1.Text = Cblocks[0].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[0], 0, panel9);

            tb_nonce_c2.Text = Cblocks[1].Nonce;
            tb_prev_c2.Text = Cblocks[1].PrevHash.ToString();
            tb_hash_c2.Text = Cblocks[1].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[1], 0, panel10);

            tb_nonce_c3.Text = Cblocks[2].Nonce;
            tb_prev_c3.Text = Cblocks[2].PrevHash.ToString();
            tb_hash_c3.Text = Cblocks[2].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[2], 0, panel11);

            tb_nonce_c4.Text = Cblocks[3].Nonce;
            tb_prev_c4.Text = Cblocks[3].PrevHash.ToString();
            tb_hash_c4.Text = Cblocks[3].BlkHash.ToString();
            UpdateBackgroundColor(Cblocks[3], 0, panel12);
        }

        // Method to update background color of a panel based on block validity
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

        private void tb_block_a1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            BlockHashUtility.OnlyNumbers(sender, e);
        }
    }
}
