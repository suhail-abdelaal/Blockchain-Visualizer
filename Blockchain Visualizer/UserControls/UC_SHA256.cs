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
    public partial class UC_SHA256 : UserControl
    {
        public UC_SHA256()
        {
            InitializeComponent();
            tb_hash.Text = Hash.CalculateSHA256(tb_data.Text);
            tb_data.TextChanged += tb_data_TextChanged;
        }

        private void tb_data_TextChanged(object sender, EventArgs e)
        {
            tb_hash.Text = Hash.CalculateSHA256(tb_data.Text);
        }

        private void UC_SHA256_Load(object sender, EventArgs e)
        {

        }
    }
}
