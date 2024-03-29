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
    public partial class UC_Blockchain : UserControl
    {
        Block[] blocks;
        public UC_Blockchain()
        {
            blocks = new Block[4];
            blocks[0] = new Block("1", "0", "0000000000000000000000000000000000000000000000000000000000000000");
            Hash.Mine(blocks[0]);
            for (int i = 1; i < blocks.Length; i++)
            {
                blocks[i] = new Block((i + 1).ToString(), "0", blocks[i - 1].hash.ToString());
                Hash.Mine(blocks[i]);
            }
            InitializeComponent();

            Chain_EventHandler();

        }

        private void Chain_EventHandler()
        {
            tb_block1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 0);
            tb_nonce1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 0);
            tb_data1.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", 0);

            tb_block2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 1);
            tb_nonce2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 1);
            tb_data2.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", 1);

            tb_block3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 2);
            tb_nonce3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 2);
            tb_data3.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", 2);

            tb_block4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", 3);
            tb_nonce4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", 3);
            tb_data4.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", 3);
        }

        private void UC_Blockchain_Load(object sender, EventArgs e)
        {
            tb_block1.Text = blocks[0].number;
            tb_nonce1.Text = blocks[0].nonce;
            tb_prev1.Text = blocks[0].prev_hash.ToString();
            tb_hash1.Text = blocks[0].hash.ToString();

            tb_block2.Text = blocks[1].number;
            tb_nonce2.Text = blocks[1].nonce;
            tb_prev2.Text = blocks[1].prev_hash.ToString();
            tb_hash2.Text = blocks[1].hash.ToString();

            tb_block3.Text = blocks[2].number;
            tb_nonce3.Text = blocks[2].nonce;
            tb_prev3.Text = blocks[2].prev_hash.ToString();
            tb_hash3.Text = blocks[2].hash.ToString();


            tb_block4.Text = blocks[3].number;
            tb_nonce4.Text = blocks[3].nonce;
            tb_prev4.Text = blocks[3].prev_hash.ToString();
            tb_hash4.Text = blocks[3].hash.ToString();
        }

        private void UpdateBackgroundColor(Block block, int idx)
        {

            switch (idx)
            {
                case 0:
                    {
                        if (block.isValid)
                            panel1.BackColor = Color.MediumAquamarine;
                        else
                            panel1.BackColor = Color.Crimson;
                    }
                    break;
                case 1:
                    {
                        if (block.isValid)
                            panel2.BackColor = Color.MediumAquamarine;
                        else
                            panel2.BackColor = Color.Crimson;
                    }
                    break;
                case 2:
                    {
                        if (block.isValid)
                            panel3.BackColor = Color.MediumAquamarine;
                        else
                            panel3.BackColor = Color.Crimson;
                    }
                    break;
                case 3:
                    {
                        if (block.isValid)
                            panel4.BackColor = Color.MediumAquamarine;
                        else
                            panel4.BackColor = Color.Crimson;
                    }
                    break;
            }
        }

        public void Chain_TextChanged(object sender, EventArgs e, string member, int block_idx)
        {
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "number")
                blocks[block_idx].number = changedTextBox.Text;

            else if (member == "nonce")
                blocks[block_idx].nonce = changedTextBox.Text;

            else if (member == "data")
            {
                blocks[block_idx].data.Clear();
                blocks[block_idx].data.Append(changedTextBox.Text);
            }

            Hash.UpdateChain(blocks, block_idx);
            UpdateChainTextBoxes();

        }

        private void Mine_Click(object sender, EventArgs e, int block_idx)
        {
            Hash.Mine(blocks[block_idx]);
            Hash.UpdateChain(blocks, block_idx);

            UpdateChainTextBoxes();
        }

        private void UpdateChainTextBoxes()
        {
            tb_nonce1.Text = blocks[0].nonce;
            tb_prev1.Text = blocks[0].prev_hash.ToString();
            tb_hash1.Text = blocks[0].hash.ToString();
            UpdateBackgroundColor(blocks[0], 0);

            tb_nonce2.Text = blocks[1].nonce;
            tb_prev2.Text = blocks[1].prev_hash.ToString();
            tb_hash2.Text = blocks[1].hash.ToString();
            UpdateBackgroundColor(blocks[1], 1);

            tb_nonce3.Text = blocks[2].nonce;
            tb_prev3.Text = blocks[2].prev_hash.ToString();
            tb_hash3.Text = blocks[2].hash.ToString();
            UpdateBackgroundColor(blocks[2], 2);

            tb_nonce4.Text = blocks[3].nonce;
            tb_prev4.Text = blocks[3].prev_hash.ToString();
            tb_hash4.Text = blocks[3].hash.ToString();
            UpdateBackgroundColor(blocks[3], 3);
        }

        private void tb_block1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }
    }
}
