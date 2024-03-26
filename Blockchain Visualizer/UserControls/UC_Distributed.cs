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

            Ablocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");
            Bblocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");
            Cblocks[0] = new Block(1, 123663, "0000000000000000000000000000000000000000000000000000000000000000");

            Hash.Mine(Ablocks[0]);
            Hash.Mine(Bblocks[0]);
            Hash.Mine(Cblocks[0]);

            for (int i = 1; i < Ablocks.Length; i++)
            {
                Ablocks[i] = new Block(i + 1, i, Ablocks[i - 1].hash.ToString());
                Hash.Mine(Ablocks[i]);

                Bblocks[i] = new Block(i + 1, i, Bblocks[i - 1].hash.ToString());
                Bblocks[i].hash = Ablocks[i].hash;
                Bblocks[i].nonce = Ablocks[i].nonce;

                Cblocks[i] = new Block(i + 1, i, Cblocks[i - 1].hash.ToString());
                Cblocks[i].hash = Ablocks[i].hash;
                Cblocks[i].nonce = Ablocks[i].nonce;
            }

            InitializeComponent();

            chain_A_onChanging();
            chain_B_onChanging();
            chain_C_onChanging();
        }

        private void chain_A_onChanging()
        {
            tb_block_a1.TextChanged += tb_block_a1_TextChanged;
            tb_nonce_a1.TextChanged += tb_nonce_a1_TextChanged;
            tb_data_a1.TextChanged += tb_data_a1_TextChanged;

            tb_block_a2.TextChanged += tb_block_a2_TextChanged;
            tb_nonce_a2.TextChanged += tb_nonce_a2_TextChanged;
            tb_data_a2.TextChanged += tb_data_a2_TextChanged;

            tb_block_a3.TextChanged += tb_block_a3_TextChanged;
            tb_nonce_a3.TextChanged += tb_nonce_a3_TextChanged;
            tb_data_a3.TextChanged += tb_data_a3_TextChanged;

            tb_block_a4.TextChanged += tb_block_a4_TextChanged;
            tb_nonce_a4.TextChanged += tb_nonce_a4_TextChanged;
            tb_data_a4.TextChanged += tb_data_a4_TextChanged;
        }

        private void chain_B_onChanging()
        {
            tb_block_b1.TextChanged += tb_block_b1_TextChanged;
            tb_nonce_b1.TextChanged += tb_nonce_b1_TextChanged;
            tb_data_b1.TextChanged += tb_data_b1_TextChanged;

            tb_block_b2.TextChanged += tb_block_b2_TextChanged;
            tb_nonce_b2.TextChanged += tb_nonce_b2_TextChanged;
            tb_data_b2.TextChanged += tb_data_b2_TextChanged;

            tb_block_b3.TextChanged += tb_block_b3_TextChanged;
            tb_nonce_b3.TextChanged += tb_nonce_b3_TextChanged;
            tb_data_b3.TextChanged += tb_data_b3_TextChanged;

            tb_block_b4.TextChanged += tb_block_b4_TextChanged;
            tb_nonce_b4.TextChanged += tb_nonce_b4_TextChanged;
            tb_data_b4.TextChanged += tb_data_b4_TextChanged;
        }

        private void chain_C_onChanging()
        {
            tb_block_c1.TextChanged += tb_block_c1_TextChanged;
            tb_nonce_c1.TextChanged += tb_nonce_c1_TextChanged;
            tb_data_c1.TextChanged += tb_data_c1_TextChanged;

            tb_block_c2.TextChanged += tb_block_c2_TextChanged;
            tb_nonce_c2.TextChanged += tb_nonce_c2_TextChanged;
            tb_data_c2.TextChanged += tb_data_c2_TextChanged;

            tb_block_c3.TextChanged += tb_block_c3_TextChanged;
            tb_nonce_c3.TextChanged += tb_nonce_c3_TextChanged;
            tb_data_c3.TextChanged += tb_data_c3_TextChanged;

            tb_block_c4.TextChanged += tb_block_c4_TextChanged;
            tb_nonce_c4.TextChanged += tb_nonce_c4_TextChanged;
            tb_data_c4.TextChanged += tb_data_c4_TextChanged;
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
        private void lbl_block_Click(object sender, EventArgs e)
        {

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

        private void tb_block_a1_TextChanged(object sender, EventArgs e)
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

        }

        private void tb_data_a1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_a1_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_a2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_a2_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_a3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_a3_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_a4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_a4_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_b1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_b1_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_b2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_b2_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_b3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_b3_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_b4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_b4_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_c1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_c1_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_c2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_c2_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_c3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_c3_Click(object sender, EventArgs e)
        {

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

        }

        private void tb_data_c4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_mine_c4_Click(object sender, EventArgs e)
        {

        }
    }
}
