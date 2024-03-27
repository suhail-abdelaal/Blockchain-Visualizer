namespace Blockchain_Visualizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btn_block = new Button();
            btn_blockChain = new Button();
            btn_distributed = new Button();
            btn_SHA256 = new Button();
            btn_tokens = new Button();
            btn_coinBase = new Button();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(btn_block);
            panel1.Controls.Add(btn_blockChain);
            panel1.Controls.Add(btn_distributed);
            panel1.Controls.Add(btn_SHA256);
            panel1.Controls.Add(btn_tokens);
            panel1.Controls.Add(btn_coinBase);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 58);
            panel1.TabIndex = 5;
            // 
            // btn_block
            // 
            btn_block.Anchor = AnchorStyles.Top;
            btn_block.FlatStyle = FlatStyle.Flat;
            btn_block.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_block.ForeColor = Color.Black;
            btn_block.Location = new Point(181, 0);
            btn_block.Name = "btn_block";
            btn_block.Size = new Size(126, 50);
            btn_block.TabIndex = 6;
            btn_block.Text = "Block";
            btn_block.UseVisualStyleBackColor = true;
            btn_block.Click += btn_block_Click;
            // 
            // btn_blockChain
            // 
            btn_blockChain.Anchor = AnchorStyles.Top;
            btn_blockChain.FlatStyle = FlatStyle.Flat;
            btn_blockChain.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_blockChain.ForeColor = Color.Black;
            btn_blockChain.Location = new Point(313, 0);
            btn_blockChain.Name = "btn_blockChain";
            btn_blockChain.Size = new Size(126, 50);
            btn_blockChain.TabIndex = 7;
            btn_blockChain.Text = "Blockchain";
            btn_blockChain.UseVisualStyleBackColor = true;
            btn_blockChain.Click += btn_blockChain_Click;
            // 
            // btn_distributed
            // 
            btn_distributed.Anchor = AnchorStyles.Top;
            btn_distributed.FlatStyle = FlatStyle.Flat;
            btn_distributed.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_distributed.ForeColor = Color.Black;
            btn_distributed.Location = new Point(445, 0);
            btn_distributed.Name = "btn_distributed";
            btn_distributed.Size = new Size(126, 50);
            btn_distributed.TabIndex = 8;
            btn_distributed.Text = "Distributed";
            btn_distributed.UseVisualStyleBackColor = true;
            btn_distributed.Click += btn_distributed_Click;
            // 
            // btn_SHA256
            // 
            btn_SHA256.Anchor = AnchorStyles.Top;
            btn_SHA256.FlatStyle = FlatStyle.Flat;
            btn_SHA256.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_SHA256.ForeColor = Color.Black;
            btn_SHA256.Location = new Point(49, 0);
            btn_SHA256.Name = "btn_SHA256";
            btn_SHA256.Size = new Size(126, 50);
            btn_SHA256.TabIndex = 0;
            btn_SHA256.Text = "Hash";
            btn_SHA256.UseVisualStyleBackColor = true;
            btn_SHA256.Click += btn_SHA256_Click;
            // 
            // btn_tokens
            // 
            btn_tokens.Anchor = AnchorStyles.Top;
            btn_tokens.FlatStyle = FlatStyle.Flat;
            btn_tokens.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_tokens.ForeColor = Color.Black;
            btn_tokens.Location = new Point(577, 0);
            btn_tokens.Name = "btn_tokens";
            btn_tokens.Size = new Size(126, 50);
            btn_tokens.TabIndex = 9;
            btn_tokens.Text = "Tokens";
            btn_tokens.UseVisualStyleBackColor = true;
            btn_tokens.Click += btn_tokens_Click;
            // 
            // btn_coinBase
            // 
            btn_coinBase.Anchor = AnchorStyles.Top;
            btn_coinBase.FlatStyle = FlatStyle.Flat;
            btn_coinBase.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_coinBase.ForeColor = Color.Black;
            btn_coinBase.Location = new Point(709, 0);
            btn_coinBase.Name = "btn_coinBase";
            btn_coinBase.Size = new Size(126, 50);
            btn_coinBase.TabIndex = 10;
            btn_coinBase.Text = "Coinbase";
            btn_coinBase.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.AutoSize = true;
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.MinimumSize = new Size(884, 542);
            panel2.Name = "panel2";
            panel2.Size = new Size(884, 542);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(146, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(8, 8);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 542);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimumSize = new Size(884, 542);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blockchain Visualizer";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btn_block;
        private Button btn_blockChain;
        private Button btn_distributed;
        private Button btn_SHA256;
        private Button btn_tokens;
        private Button btn_coinBase;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}