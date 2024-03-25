using Blockchain_Visualizer.UserControls;
using System.Text;

namespace Blockchain_Visualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addUserControl(new UC_SHA256());

        }



        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_SHA256_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_SHA256());
        }

        private void btn_block_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_Block());
        }
    }
}