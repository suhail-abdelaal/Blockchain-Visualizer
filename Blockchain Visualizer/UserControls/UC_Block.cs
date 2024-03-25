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
    public partial class UC_Block : UserControl
    {
        Block block;
        public UC_Block()
        {
            block = new Block(1, 123663, "null");
            Hash.Mine(block);
            InitializeComponent();
            tb_block_block.TextChanged += tb_block_block_TextChanged;
            tb_nonce_block.TextChanged += tb_nonce_block_TextChanged;
            tb_data_block.TextChanged += tb_data_TextChanged;

        }

        private void UC_Block_Load(object sender, EventArgs e)
        {
            tb_block_block.Text = block.number.ToString();
            tb_nonce_block.Text = block.nonce.ToString();
            tb_hash_block.Text = block.hash.ToString();
        }

        private void btn_mine_block_Click(object sender, EventArgs e)
        {
            Hash.Mine(block);

            tb_nonce_block.Text = block.nonce.ToString();
            tb_hash_block.Text = block.hash.ToString();
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
            if (tb_block_block.Text == "")
                block.number = 0;
            else
                block.number = int.Parse(tb_block_block.Text);

            tb_hash_block.Text = Hash.CalculateSHA256(Hash.CombineData(block));

            block.UpdateHash(tb_hash_block.Text);
            UpdateBackgroundColor();
        }

        private void tb_nonce_block_TextChanged(object sender, EventArgs e)
        {
            if (tb_nonce_block.Text == "")
                block.nonce = 0;
            else
                block.nonce = int.Parse(tb_nonce_block.Text);

            tb_hash_block.Text = Hash.CalculateSHA256(Hash.CombineData(block));
            block.UpdateHash(tb_hash_block.Text);
            UpdateBackgroundColor();
        }

        private void tb_data_TextChanged(object sender, EventArgs e)
        {
            block.data.Clear();
            block.data.Append(tb_data_block.Text);

            tb_hash_block.Text = Hash.CalculateSHA256(Hash.CombineData(block));
            block.UpdateHash(tb_hash_block.Text);
            UpdateBackgroundColor();
        }

        private void tb_block_block_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_nonce_block_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void UC_Block_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
