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
            blocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");
            Hash.Mine(blocks[0]);
            for (int i = 1; i < blocks.Length; i++)
            {
                blocks[i] = new Block(i + 1, i, blocks[i - 1].hash.ToString());
                Hash.Mine(blocks[i]);
            }
            InitializeComponent();

            tb_block1.TextChanged += tb_block1_TextChanged;
            tb_nonce1.TextChanged += tb_nonce1_TextChanged;
            tb_data1.TextChanged += tb_data1_TextChanged;

            tb_block2.TextChanged += tb_block2_TextChanged;
            tb_nonce2.TextChanged += tb_nonce2_TextChanged;
            tb_data2.TextChanged += tb_data2_TextChanged;

            tb_block4.TextChanged += tb_block3_TextChanged;
            tb_nonce4.TextChanged += tb_nonce3_TextChanged;
            tb_data4.TextChanged += tb_data3_TextChanged;

            tb_block4.TextChanged += tb_block4_TextChanged;
            tb_nonce4.TextChanged += tb_nonce4_TextChanged;
            tb_data4.TextChanged += tb_data4_TextChanged;

        }

        private void UC_Blockchain_Load(object sender, EventArgs e)
        {
            tb_block1.Text = blocks[0].number.ToString();
            tb_nonce1.Text = blocks[0].nonce.ToString();
            tb_prev1.Text = blocks[0].prev_hash.ToString();
            tb_hash1.Text = blocks[0].hash.ToString();

            tb_block2.Text = blocks[1].number.ToString();
            tb_nonce2.Text = blocks[1].nonce.ToString();
            tb_prev2.Text = blocks[1].prev_hash.ToString();
            tb_hash2.Text = blocks[1].hash.ToString();

            tb_block3.Text = blocks[2].number.ToString();
            tb_nonce3.Text = blocks[2].nonce.ToString();
            tb_prev3.Text = blocks[2].prev_hash.ToString();
            tb_hash3.Text = blocks[2].hash.ToString();


            tb_block4.Text = blocks[3].number.ToString();
            tb_nonce4.Text = blocks[3].nonce.ToString();
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
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tb_hash4_TextChanged(object sender, EventArgs e)
        {
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void tb_block1_TextChanged(object sender, EventArgs e)
        {
            if (tb_block1.Text == "")
                blocks[0].number = 0;
            else
                blocks[0].number = BigInteger.Parse(tb_block1.Text);


            Hash.UpdateChain(blocks, 0);
            UpdateChainTextBoxes(0);
            UpdateBackgroundColor(blocks[0], 0);
        }

        private void tb_nonce1_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce1.Text == "")
                blocks[0].nonce = 0;
            else
                blocks[0].nonce = BigInteger.Parse(tb_nonce1.Text);


            Hash.UpdateChain(blocks, 0);
            UpdateChainTextBoxes(0);
            UpdateBackgroundColor(blocks[0], 0);
        }

        private void tb_data1_TextChanged(object sender, EventArgs e)
        {
            blocks[0].data.Clear();
            blocks[0].data.Append(tb_data1.Text);

            Hash.UpdateChain(blocks, 0);
            UpdateChainTextBoxes(0);
            UpdateBackgroundColor(blocks[0], 0);
        }

        private void UpdateChainTextBoxes(int block_idx)
        {
            tb_prev1.Text = blocks[0].prev_hash.ToString();
            tb_hash1.Text = blocks[0].hash.ToString();
            UpdateBackgroundColor(blocks[0], 0);

            tb_prev2.Text = blocks[1].prev_hash.ToString();
            tb_hash2.Text = blocks[1].hash.ToString();
            UpdateBackgroundColor(blocks[1], 1);

            tb_prev3.Text = blocks[2].prev_hash.ToString();
            tb_hash3.Text = blocks[2].hash.ToString();
            UpdateBackgroundColor(blocks[2], 2);

            tb_prev4.Text = blocks[3].prev_hash.ToString();
            tb_hash4.Text = blocks[3].hash.ToString();
            UpdateBackgroundColor(blocks[3], 3);
        }


        private void tb_block2_TextChanged(object sender, EventArgs e)
        {
            if (tb_block2.Text == "")
                blocks[1].number = 0;
            else
                blocks[1].number = BigInteger.Parse(tb_block2.Text);

            Hash.UpdateChain(blocks, 1);
            UpdateChainTextBoxes(1);
            UpdateBackgroundColor(blocks[1], 1);
        }

        private void tb_nonce2_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce2.Text == "")
                blocks[1].nonce = 0;
            else
                blocks[1].nonce = BigInteger.Parse(tb_nonce2.Text);

            Hash.UpdateChain(blocks, 1);
            UpdateChainTextBoxes(1);
            UpdateBackgroundColor(blocks[1], 1);
        }

        private void tb_data2_TextChanged(object sender, EventArgs e)
        {
            blocks[1].data.Clear();
            blocks[1].data.Append(tb_data2.Text);

            Hash.UpdateChain(blocks, 1);
            UpdateChainTextBoxes(1);
            UpdateBackgroundColor(blocks[1], 1);
        }

        private void tb_block3_TextChanged(object sender, EventArgs e)
        {
            if (tb_block3.Text == "")
                blocks[2].number = 0;
            else
                blocks[2].number = BigInteger.Parse(tb_block3.Text);

            Hash.UpdateChain(blocks, 2);
            UpdateChainTextBoxes(2);
            UpdateBackgroundColor(blocks[2], 2);
        }

        private void tb_nonce3_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce3.Text == "")
                blocks[2].nonce = 0;
            else
                blocks[2].nonce = BigInteger.Parse(tb_nonce3.Text);

            Hash.UpdateChain(blocks, 2);
            UpdateChainTextBoxes(2);
            UpdateBackgroundColor(blocks[2], 2);

        }

        private void tb_data3_TextChanged(object sender, EventArgs e)
        {
            blocks[2].data.Clear();
            blocks[2].data.Append(tb_data3.Text);

            Hash.UpdateChain(blocks, 2);
            UpdateChainTextBoxes(2);
            UpdateBackgroundColor(blocks[2], 2);
        }

        private void tb_block4_TextChanged(object sender, EventArgs e)
        {
            if (tb_block4.Text == "")
                blocks[3].number = 0;
            else
                blocks[3].number = BigInteger.Parse(tb_block4.Text);

            Hash.UpdateChain(blocks, 3);
            UpdateChainTextBoxes(3);
            UpdateBackgroundColor(blocks[3], 3);
        }

        private void tb_nonce4_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce4.Text == "")
                blocks[3].nonce = 0;
            else
                blocks[3].nonce = BigInteger.Parse(tb_nonce4.Text);

            Hash.UpdateChain(blocks, 3);
            UpdateChainTextBoxes(3);
            UpdateBackgroundColor(blocks[3], 3);
        }

        private void tb_data4_TextChanged(object sender, EventArgs e)
        {
            blocks[3].data.Clear();
            blocks[3].data.Append(tb_data4.Text);

            Hash.UpdateChain(blocks, 3);
            UpdateChainTextBoxes(3);
            UpdateBackgroundColor(blocks[3], 3);
        }

        private void btn_mine1_Click(object sender, EventArgs e)
        {
            Hash.Mine(blocks[0]);

            tb_nonce1.Text = blocks[0].nonce.ToString();
            tb_hash1.Text = blocks[0].hash.ToString();
            Hash.UpdateChain(blocks, 0);
            UpdateChainTextBoxes(0);
            UpdateBackgroundColor(blocks[0], 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hash.Mine(blocks[1]);

            tb_nonce2.Text = blocks[1].nonce.ToString();
            tb_hash2.Text = blocks[1].hash.ToString();
            Hash.UpdateChain(blocks, 1);
            UpdateChainTextBoxes(1);
            UpdateBackgroundColor(blocks[1], 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hash.Mine(blocks[2]);

            tb_nonce3.Text = blocks[2].nonce.ToString();
            tb_hash3.Text = blocks[2].hash.ToString();
            Hash.UpdateChain(blocks, 2);
            UpdateChainTextBoxes(2);
            UpdateBackgroundColor(blocks[2], 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hash.Mine(blocks[3]);

            tb_nonce4.Text = blocks[3].nonce.ToString();
            tb_hash4.Text = blocks[3].hash.ToString();
            Hash.UpdateChain(blocks, 3);
            UpdateChainTextBoxes(3);
            UpdateBackgroundColor(blocks[3], 3);
        }

        private void tb_prev1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
