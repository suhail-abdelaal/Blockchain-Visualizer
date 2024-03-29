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
    public partial class UC_Block : UserControl
    {
        Block block;
        public UC_Block()
        {
            block = new Block("1", "0", "");
            Hash.Mine(block);

            InitializeComponent();
            tb_block.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number");
            tb_nonce.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce");
            tb_data.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data");

        }

        private void UC_Block_Load(object sender, EventArgs e)
        {
            tb_block.Text = block.number.ToString();
            tb_nonce.Text = block.nonce.ToString();
            tb_hash.Text = block.hash.ToString();
        }

        public void Chain_TextChanged(object sender, EventArgs e, string member)
        {
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;
            if (member == "number")
                block.number = changedTextBox.Text;

            else if (member == "nonce")
                block.nonce = changedTextBox.Text;

            else if (member == "data")
            {
                block.data.Clear();
                block.data.Append(changedTextBox.Text);
            }

            block.UpdateHash(Hash.CalculateSHA256(Hash.CombineData(block)));
            tb_hash.Text = block.hash.ToString();
            UpdateBackgroundColor();
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

        private void UC_Block_KeyPress(object sender, KeyPressEventArgs e)
        {
            Hash.onlyNumbers(sender, e);
        }


    }
}
