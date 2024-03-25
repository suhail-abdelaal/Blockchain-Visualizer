﻿namespace Blockchain_Visualizer.UserControls
{
    partial class UC_Block
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_block = new Label();
            lbl_hash_block = new Label();
            lbl_data_block = new Label();
            tb_hash_block = new TextBox();
            tb_data_block = new TextBox();
            lbl_nonce_block = new Label();
            tb_nonce_block = new TextBox();
            lbl_block_block = new Label();
            tb_block_block = new TextBox();
            btn_mine_block = new Button();
            SuspendLayout();
            // 
            // lbl_block
            // 
            lbl_block.AutoSize = true;
            lbl_block.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_block.Location = new Point(409, 84);
            lbl_block.Name = "lbl_block";
            lbl_block.Size = new Size(67, 25);
            lbl_block.TabIndex = 14;
            lbl_block.Text = "Block";
            // 
            // lbl_hash_block
            // 
            lbl_hash_block.AutoSize = true;
            lbl_hash_block.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_hash_block.Location = new Point(20, 440);
            lbl_hash_block.Name = "lbl_hash_block";
            lbl_hash_block.Size = new Size(51, 19);
            lbl_hash_block.TabIndex = 13;
            lbl_hash_block.Text = "Hash:";
            // 
            // lbl_data_block
            // 
            lbl_data_block.AutoSize = true;
            lbl_data_block.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_data_block.Location = new Point(21, 214);
            lbl_data_block.Name = "lbl_data_block";
            lbl_data_block.Size = new Size(50, 19);
            lbl_data_block.TabIndex = 12;
            lbl_data_block.Text = "Data:";
            // 
            // tb_hash_block
            // 
            tb_hash_block.BorderStyle = BorderStyle.FixedSingle;
            tb_hash_block.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash_block.Location = new Point(79, 440);
            tb_hash_block.Multiline = true;
            tb_hash_block.Name = "tb_hash_block";
            tb_hash_block.ReadOnly = true;
            tb_hash_block.Size = new Size(785, 31);
            tb_hash_block.TabIndex = 11;
            // 
            // tb_data_block
            // 
            tb_data_block.BorderStyle = BorderStyle.FixedSingle;
            tb_data_block.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data_block.Location = new Point(79, 214);
            tb_data_block.Multiline = true;
            tb_data_block.Name = "tb_data_block";
            tb_data_block.Size = new Size(785, 209);
            tb_data_block.TabIndex = 10;
            tb_data_block.TextChanged += tb_data_TextChanged;
            // 
            // lbl_nonce_block
            // 
            lbl_nonce_block.AutoSize = true;
            lbl_nonce_block.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nonce_block.Location = new Point(6, 167);
            lbl_nonce_block.Name = "lbl_nonce_block";
            lbl_nonce_block.Size = new Size(65, 19);
            lbl_nonce_block.TabIndex = 16;
            lbl_nonce_block.Text = "Nonce:";
            // 
            // tb_nonce_block
            // 
            tb_nonce_block.BorderStyle = BorderStyle.FixedSingle;
            tb_nonce_block.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nonce_block.Location = new Point(79, 167);
            tb_nonce_block.Multiline = true;
            tb_nonce_block.Name = "tb_nonce_block";
            tb_nonce_block.Size = new Size(785, 28);
            tb_nonce_block.TabIndex = 15;
            tb_nonce_block.TextChanged += tb_nonce_block_TextChanged;
            tb_nonce_block.KeyPress += tb_nonce_block_KeyPress;
            // 
            // lbl_block_block
            // 
            lbl_block_block.AutoSize = true;
            lbl_block_block.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_block_block.Location = new Point(16, 124);
            lbl_block_block.Name = "lbl_block_block";
            lbl_block_block.Size = new Size(55, 19);
            lbl_block_block.TabIndex = 18;
            lbl_block_block.Text = "Block:";
            // 
            // tb_block_block
            // 
            tb_block_block.BorderStyle = BorderStyle.FixedSingle;
            tb_block_block.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_block_block.Location = new Point(79, 124);
            tb_block_block.Multiline = true;
            tb_block_block.Name = "tb_block_block";
            tb_block_block.Size = new Size(785, 28);
            tb_block_block.TabIndex = 17;
            tb_block_block.TextChanged += tb_block_block_TextChanged;
            tb_block_block.KeyPress += tb_block_block_KeyPress;
            // 
            // btn_mine_block
            // 
            btn_mine_block.Location = new Point(398, 486);
            btn_mine_block.Name = "btn_mine_block";
            btn_mine_block.Size = new Size(89, 39);
            btn_mine_block.TabIndex = 19;
            btn_mine_block.Text = "Mine";
            btn_mine_block.UseVisualStyleBackColor = true;
            btn_mine_block.Click += btn_mine_block_Click;
            // 
            // UC_Block
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            Controls.Add(btn_mine_block);
            Controls.Add(lbl_block_block);
            Controls.Add(tb_block_block);
            Controls.Add(lbl_nonce_block);
            Controls.Add(tb_nonce_block);
            Controls.Add(lbl_block);
            Controls.Add(lbl_hash_block);
            Controls.Add(lbl_data_block);
            Controls.Add(tb_hash_block);
            Controls.Add(tb_data_block);
            Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UC_Block";
            Size = new Size(884, 542);
            Load += UC_Block_Load;
            Paint += UC_Block_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_block;
        private Label lbl_hash_block;
        private Label lbl_data_block;
        private TextBox tb_hash_block;
        private TextBox tb_data_block;
        private Label lbl_nonce_block;
        private TextBox tb_nonce_block;
        private Label lbl_block_block;
        private TextBox tb_block_block;
        private Button btn_mine_block;
    }
}