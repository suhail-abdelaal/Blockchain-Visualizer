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

namespace Blockchain_Visualizer.UserControls
{
    // UserControl for displaying and interacting with a blockchain
    public partial class UC_Blockchain : UserControl
    {
        Block[] blocks; // Array to hold blocks of the blockchain

        // Constructor
        public UC_Blockchain()
        {
            // Initialize the blockchain with 4 blocks and mine each block
            blocks = new Block[4];
            blocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            BlockHashUtility.Mine(blocks[0]);
            for (int i = 1; i < blocks.Length; i++)
            {
                blocks[i] = new Block((i + 1).ToString(), "0", blocks[i - 1].BlkHash.ToString());
                BlockHashUtility.Mine(blocks[i]);
            }
            InitializeComponent();

            // Attach event handlers for text changed events of text boxes
            Chain_EventHandler();
        }

        // Method to attach event handlers for text changed events of text boxes
        private void Chain_EventHandler()
        {
            tb_block1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 0);
            tb_nonce1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 0);
            tb_data1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", 0);

            tb_block2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 1);
            tb_nonce2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 1);
            tb_data2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", 1);

            tb_block3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 2);
            tb_nonce3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 2);
            tb_data3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", 2);

            tb_block4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 3);
            tb_nonce4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 3);
            tb_data4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data", 3);
        }

        // Event handler for loading the user control
        private void UC_Blockchain_Load(object sender, EventArgs e)
        {
            // Update text boxes with block data for each block in the blockchain
            tb_block1.Text = blocks[0].Number;
            tb_nonce1.Text = blocks[0].Nonce;
            tb_prev1.Text = blocks[0].PrevHash.ToString();
            tb_hash1.Text = blocks[0].BlkHash.ToString();

            tb_block2.Text = blocks[1].Number;
            tb_nonce2.Text = blocks[1].Nonce;
            tb_prev2.Text = blocks[1].PrevHash.ToString();
            tb_hash2.Text = blocks[1].BlkHash.ToString();

            tb_block3.Text = blocks[2].Number;
            tb_nonce3.Text = blocks[2].Nonce;
            tb_prev3.Text = blocks[2].PrevHash.ToString();
            tb_hash3.Text = blocks[2].BlkHash.ToString();

            tb_block4.Text = blocks[3].Number;
            tb_nonce4.Text = blocks[3].Nonce;
            tb_prev4.Text = blocks[3].PrevHash.ToString();
            tb_hash4.Text = blocks[3].BlkHash.ToString();
        }

        // Method to update background color based on block validity
        private void UpdateBackgroundColor(Block block, int idx)
        {
            // Update background color of panels based on block validity
            switch (idx)
            {
                case 0:
                    if (block.IsValid)
                        panel1.BackColor = Color.MediumAquamarine; // Valid block color
                    else
                        panel1.BackColor = Color.Crimson; // Invalid block color
                    break;
                case 1:
                    if (block.IsValid)
                        panel2.BackColor = Color.MediumAquamarine; // Valid block color
                    else
                        panel2.BackColor = Color.Crimson; // Invalid block color
                    break;
                case 2:
                    if (block.IsValid)
                        panel3.BackColor = Color.MediumAquamarine; // Valid block color
                    else
                        panel3.BackColor = Color.Crimson; // Invalid block color
                    break;
                case 3:
                    if (block.IsValid)
                        panel4.BackColor = Color.MediumAquamarine; // Valid block color
                    else
                        panel4.BackColor = Color.Crimson; // Invalid block color
                    break;
            }
        }

        // Event handler for text changed events in text boxes
        public void Chain_TextChanged(object sender, EventArgs e, string member, int block_idx)
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

            // Update chain and text boxes with new block data
            BlockHashUtility.UpdateChain(blocks, block_idx);
            UpdateChainTextBoxes();
        }

        // Event handler for mining a block
        private void Mine_Click(object sender, EventArgs e, int block_idx)
        {
            // Mine the block
            BlockHashUtility.Mine(blocks[block_idx]);
            // Update chain with new block data
            BlockHashUtility.UpdateChain(blocks, block_idx);

            // Update text boxes with new block data
            UpdateChainTextBoxes();
        }

        // Method to update text boxes with block data
        private void UpdateChainTextBoxes()
        {
            // Update text boxes with data for each block in the blockchain
            tb_nonce1.Text = blocks[0].Nonce;
            tb_prev1.Text = blocks[0].PrevHash.ToString();
            tb_hash1.Text = blocks[0].BlkHash.ToString();
            UpdateBackgroundColor(blocks[0], 0);

            tb_nonce2.Text = blocks[1].Nonce;
            tb_prev2.Text = blocks[1].PrevHash.ToString();
            tb_hash2.Text = blocks[1].BlkHash.ToString();
            UpdateBackgroundColor(blocks[1], 1);

            tb_nonce3.Text = blocks[2].Nonce;
            tb_prev3.Text = blocks[2].PrevHash.ToString();
            tb_hash3.Text = blocks[2].BlkHash.ToString();
            UpdateBackgroundColor(blocks[2], 2);

            tb_nonce4.Text = blocks[3].Nonce;
            tb_prev4.Text = blocks[3].PrevHash.ToString();
            tb_hash4.Text = blocks[3].BlkHash.ToString();
            UpdateBackgroundColor(blocks[3], 3);
        }

        // Event handler for handling key press events (allows only numbers in text boxes)
        private void tb_block1_KeyPress(object sender, KeyPressEventArgs e)
        {
            BlockHashUtility.OnlyNumbers(sender, e);
        }
    }
}
