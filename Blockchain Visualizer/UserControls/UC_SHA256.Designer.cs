namespace Blockchain_Visualizer.UserControls
{
    partial class UC_SHA256
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
            lbl_sha256 = new Label();
            lbl_hash = new Label();
            lbl_data = new Label();
            tb_hash = new TextBox();
            tb_data = new TextBox();
            SuspendLayout();
            // 
            // lbl_sha256
            // 
            lbl_sha256.AutoSize = true;
            lbl_sha256.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_sha256.Location = new Point(370, 95);
            lbl_sha256.Name = "lbl_sha256";
            lbl_sha256.Size = new Size(145, 25);
            lbl_sha256.TabIndex = 9;
            lbl_sha256.Text = "SHA265 Hash";
            // 
            // lbl_hash
            // 
            lbl_hash.AutoSize = true;
            lbl_hash.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_hash.Location = new Point(21, 463);
            lbl_hash.Name = "lbl_hash";
            lbl_hash.Size = new Size(51, 19);
            lbl_hash.TabIndex = 8;
            lbl_hash.Text = "Hash:";
            // 
            // lbl_data
            // 
            lbl_data.AutoSize = true;
            lbl_data.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_data.Location = new Point(23, 141);
            lbl_data.Name = "lbl_data";
            lbl_data.Size = new Size(50, 19);
            lbl_data.TabIndex = 7;
            lbl_data.Text = "Data:";
            // 
            // tb_hash
            // 
            tb_hash.BorderStyle = BorderStyle.FixedSingle;
            tb_hash.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash.Location = new Point(79, 463);
            tb_hash.Multiline = true;
            tb_hash.Name = "tb_hash";
            tb_hash.ReadOnly = true;
            tb_hash.Size = new Size(785, 31);
            tb_hash.TabIndex = 6;
            // 
            // tb_data
            // 
            tb_data.BorderStyle = BorderStyle.FixedSingle;
            tb_data.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data.Location = new Point(79, 141);
            tb_data.Multiline = true;
            tb_data.Name = "tb_data";
            tb_data.Size = new Size(785, 301);
            tb_data.TabIndex = 5;
            tb_data.TextChanged += tb_data_TextChanged;
            // 
            // UC_SHA256
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_sha256);
            Controls.Add(lbl_hash);
            Controls.Add(lbl_data);
            Controls.Add(tb_hash);
            Controls.Add(tb_data);
            Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UC_SHA256";
            Size = new Size(884, 542);
            Load += UC_SHA256_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_sha256;
        private Label lbl_hash;
        private Label lbl_data;
        private TextBox tb_hash;
        private TextBox tb_data;
    }
}
