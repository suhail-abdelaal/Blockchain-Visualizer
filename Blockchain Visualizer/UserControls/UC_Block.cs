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
    public partial class UC_Block : UserControl
    {
        Block block;
        public UC_Block()
        {
            block = new Block(1, 605748, "");
            Hash.Mine(block);

            InitializeComponent();
            tb_block.TextChanged += tb_block_block_TextChanged;
            tb_nonce.TextChanged += tb_nonce_block_TextChanged;
            tb_data.TextChanged += tb_data_TextChanged;

        }

        private void UC_Block_Load(object sender, EventArgs e)
        {
            tb_block.Text = block.number.ToString();
            tb_nonce.Text = block.nonce.ToString();
            tb_hash.Text = block.hash.ToString();
        }

        private void btn_mine_block_Click(object sender, EventArgs e)
        {
            Hash.Mine(block);

            tb_nonce.Text = block.nonce.ToString();
            tb_hash.Text = block.hash.ToString();
        }

        private void UpdateBackgroundColor()
        {
            if (block.isValid)
                this.BackColor = Color.MediumAquamarine;
            else
                this.BackColor = Color.Crimson;
        }
        private void tb_block_block_TextChanged(object sender, EventArgs e)
        {
            if (tb_block.Text == "")
                block.number = 0;
            else
                block.number = BigInteger.Parse(tb_block.Text);

            tb_hash.Text = Hash.CalculateSHA256(Hash.CombineData(block));

            block.UpdateHash(tb_hash.Text);
            UpdateBackgroundColor();
        }

        private void tb_nonce_block_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce.Text == "")
                block.nonce = 0;
            else
                block.nonce = BigInteger.Parse(tb_nonce.Text);

            tb_hash.Text = Hash.CalculateSHA256(Hash.CombineData(block));
            block.UpdateHash(tb_hash.Text);
            UpdateBackgroundColor();
        }

        private void tb_data_TextChanged(object sender, EventArgs e)
        {
            block.data.Clear();
            block.data.Append(tb_data.Text);

            tb_hash.Text = Hash.CalculateSHA256(Hash.CombineData(block));
            block.UpdateHash(tb_hash.Text);
            UpdateBackgroundColor();
        }


        private void UC_Block_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }
    }
}
