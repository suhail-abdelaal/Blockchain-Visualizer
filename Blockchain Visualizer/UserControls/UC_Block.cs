

namespace Blockchain_Visualizer.UserControls
{
    // UserControl for displaying and interacting with an individual block in the blockchain
    public partial class UC_Block : UserControl
    {
        Block block; // Instance of the Block class representing the block displayed in this control

        // Constructor
        public UC_Block()
        {
            // Initialize the block with default values and mine it
            block = new Block("1", "0", "");
            BlockHashUtility.Mine(block);

            InitializeComponent();

            // Attach event handlers for text changed events of text boxes
            tb_block.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "number");
            tb_nonce.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "nonce");
            tb_data.TextChanged += (sender, e) => Chain_TextChanged(sender, e, "data");
        }

        // Event handler for loading the user control
        private void UC_Block_Load(object sender, EventArgs e)
        {
            // Update text boxes with block data
            tb_block.Text = block.Number.ToString();
            tb_nonce.Text = block.Nonce.ToString();
            tb_hash.Text = block.BlkHash.ToString();
        }

        // Event handler for text changed event in text boxes
        public void Chain_TextChanged(object sender, EventArgs e, string member)
        {
            // Determine which text box triggered the event
            System.Windows.Forms.TextBox changedTextBox = (System.Windows.Forms.TextBox)sender;

            // Update corresponding member of the block based on the text box
            if (member == "number")
                block.Number = changedTextBox.Text;
            else if (member == "nonce")
                block.Nonce = changedTextBox.Text;
            else if (member == "data")
            {
                block.Data.Clear();
                block.Data.Append(changedTextBox.Text);
            }

            // Update block hash and text box with hash value
            block.UpdateHash(BlockHashUtility.CalculateSHA256(BlockHashUtility.CombineData(block)));
            tb_hash.Text = block.BlkHash.ToString();

            // Update background color based on block validity
            UpdateBackgroundColor();
        }

        // Event handler for mining a block
        private void btn_mine_block_Click(object sender, EventArgs e)
        {
            // Mine the block
            BlockHashUtility.Mine(block);

            // Update text boxes with new nonce and hash
            tb_nonce.Text = block.Nonce.ToString();
            tb_hash.Text = block.BlkHash.ToString();
        }

        // Method to update the background color based on block validity
        private void UpdateBackgroundColor()
        {
            if (block.IsValid)
                this.BackColor = Color.MediumAquamarine; // Valid block color
            else
                this.BackColor = Color.Crimson; // Invalid block color
        }

        // Event handler for handling key press events (allows only numbers in text boxes)
        private void UC_Block_KeyPress(object sender, KeyPressEventArgs e)
        {
            BlockHashUtility.OnlyNumbers(sender, e);
        }
    }
}
