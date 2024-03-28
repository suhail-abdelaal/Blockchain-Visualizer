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
    public partial class UC_Distributed : UserControl
    {
        Block[] Ablocks;
        Block[] Bblocks;
        Block[] Cblocks;

        public UC_Distributed()
        {
            Ablocks = new Block[4];
            Bblocks = new Block[4];
            Cblocks = new Block[4];

            Ablocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block(1, 0, "0000000000000000000000000000000000000000000000000000000000000000");

            Hash.Mine(Ablocks[0]);
            Hash.Mine(Bblocks[0]);
            Hash.Mine(Cblocks[0]);

            for (int i = 1; i < Ablocks.Length; i++)
            {
                string previousHash = Ablocks[i - 1].hash.ToString();

                Ablocks[i] = new Block(i + 1, 0, previousHash);
                Hash.Mine(Ablocks[i]);

                Bblocks[i] = new Block(i + 1, 0, previousHash);
                Bblocks[i].nonce = Ablocks[i].nonce;
                Bblocks[i].hash = Ablocks[i].hash;

                Cblocks[i] = new Block(i + 1, 0, previousHash);
                Cblocks[i].nonce = Ablocks[i].nonce;
                Cblocks[i].hash = Ablocks[i].hash;
            }

            InitializeComponent();

            chain_A_eventHandler();
            chain_B_eventHandler();
            chain_C_onChanging();
        }

        private void UC_Distributed_Load(object sender, EventArgs e)
        {
            UC_Distributed_Load_Chain_A();
            UC_Distributed_Load_Chain_B();
            UC_Distributed_Load_Chain_C();
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
        }
        private void chain_A_eventHandler()
        {
            tb_block_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 0);
            tb_nonce_a1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 0);
            tb_data_a1.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 0);

            tb_block_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 1);
            tb_nonce_a2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 1);
            tb_data_a2.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 1);

            tb_block_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 2);
            tb_nonce_a3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 2);
            tb_data_a3.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 2);

            tb_block_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Ablocks, 3);
            tb_nonce_a4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Ablocks, 3);
            tb_data_a4.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Ablocks, 3);
        }

        private void chain_B_eventHandler()
        {
            tb_block_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 0);
            tb_nonce_b1.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 0);
            tb_data_b1.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 0);

            tb_block_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 1);
            tb_nonce_b2.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 1);
            tb_data_b2.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 1);

            tb_block_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 2);
            tb_nonce_b3.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 2);
            tb_data_b3.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 2);

            tb_block_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number", Bblocks, 3);
            tb_nonce_b4.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce", Bblocks, 3);
            tb_data_b4.TextChanged  += (sender, e) => Chain_TextChanged(sender, e, "data", Bblocks, 3);
        }
        private void chain_C_onChanging()
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

        public void Chain_TextChanged(object sender, EventArgs e, string member, Block[] blocks, int block_idx)
        {
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "number")
            {
                if (changedTextBox.Text != "")
                    blocks[block_idx].number = BigInteger.Parse(changedTextBox.Text);
                else
                    blocks[block_idx].number = 0;
            }
            else if (member == "nonce")
            {
                if (changedTextBox.Text != "")
                    blocks[block_idx].nonce = BigInteger.Parse(changedTextBox.Text);
                else
                    blocks[block_idx].nonce = 0;

            }
            else if (member == "data")
            {
                blocks[block_idx].data.Clear();
                blocks[block_idx].data.Append(changedTextBox.Text);
            }

            Hash.UpdateChain(blocks, block_idx);

            if (blocks == Ablocks)
                UpdateChain_A_TextBoxes();
            else if (blocks == Bblocks)
                UpdateChain_B_TextBoxes();
            else if (blocks == Cblocks)
                UpdateChain_C_TextBoxes();
        }

        private void Mine_Click(object sender, EventArgs e, Block[] blocks, int block_idx)
        {
            Hash.Mine(blocks[block_idx]);
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
            tb_nonce_a1.Text = Ablocks[0].nonce.ToString();
            tb_prev_a1.Text = Ablocks[0].prev_hash.ToString();
            tb_hash_a1.Text = Ablocks[0].hash.ToString();
            UpdateBackgroundColor(Ablocks[0], 0, panel1);

            tb_nonce_a2.Text = Ablocks[1].nonce.ToString();
            tb_prev_a2.Text = Ablocks[1].prev_hash.ToString();
            tb_hash_a2.Text = Ablocks[1].hash.ToString();
            UpdateBackgroundColor(Ablocks[1], 0, panel2);

            tb_nonce_a3.Text = Ablocks[2].nonce.ToString();
            tb_prev_a3.Text = Ablocks[2].prev_hash.ToString();
            tb_hash_a3.Text = Ablocks[2].hash.ToString();
            UpdateBackgroundColor(Ablocks[2], 0, panel3);

            tb_nonce_a4.Text = Ablocks[3].nonce.ToString();
            tb_prev_a4.Text = Ablocks[3].prev_hash.ToString();
            tb_hash_a4.Text = Ablocks[3].hash.ToString();
            UpdateBackgroundColor(Ablocks[3], 0, panel4);
        }

        private void UpdateChain_B_TextBoxes()
        {
            tb_nonce_b1.Text = Bblocks[0].nonce.ToString();
            tb_prev_b1.Text = Bblocks[0].prev_hash.ToString();
            tb_hash_b1.Text = Bblocks[0].hash.ToString();
            UpdateBackgroundColor(Bblocks[0], 0, panel5);

            tb_nonce_b2.Text = Bblocks[1].nonce.ToString();
            tb_prev_b2.Text = Bblocks[1].prev_hash.ToString();
            tb_hash_b2.Text = Bblocks[1].hash.ToString();
            UpdateBackgroundColor(Bblocks[1], 0, panel6);

            tb_nonce_b3.Text = Bblocks[2].nonce.ToString();
            tb_prev_b3.Text = Bblocks[2].prev_hash.ToString();
            tb_hash_b3.Text = Bblocks[2].hash.ToString();
            UpdateBackgroundColor(Bblocks[2], 0, panel7);

            tb_nonce_b4.Text = Bblocks[3].nonce.ToString();
            tb_prev_b4.Text = Bblocks[3].prev_hash.ToString();
            tb_hash_b4.Text = Bblocks[3].hash.ToString();
            UpdateBackgroundColor(Bblocks[3], 0, panel8);
        }

        private void UpdateChain_C_TextBoxes()
        {
            tb_nonce_c1.Text = Cblocks[0].nonce.ToString();
            tb_prev_c1.Text = Cblocks[0].prev_hash.ToString();
            tb_hash_c1.Text = Cblocks[0].hash.ToString();
            UpdateBackgroundColor(Cblocks[0], 0, panel9);

            tb_nonce_c2.Text = Cblocks[1].nonce.ToString();
            tb_prev_c2.Text = Cblocks[1].prev_hash.ToString();
            tb_hash_c2.Text = Cblocks[1].hash.ToString();
            UpdateBackgroundColor(Cblocks[1], 0, panel10);

            tb_nonce_c3.Text = Cblocks[2].nonce.ToString();
            tb_prev_c3.Text = Cblocks[2].prev_hash.ToString();
            tb_hash_c3.Text = Cblocks[2].hash.ToString();
            UpdateBackgroundColor(Cblocks[2], 0, panel11);

            tb_nonce_c4.Text = Cblocks[3].nonce.ToString();
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

        private void lbl_block_Click(object sender, EventArgs e)
        {

        }

        private void tb_block_a1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }
    }
}
