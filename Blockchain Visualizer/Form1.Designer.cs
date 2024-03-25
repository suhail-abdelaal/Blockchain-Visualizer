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
            tb_data = new TextBox();
            tb_hash = new TextBox();
            data_label = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // tb_data
            // 
            tb_data.BorderStyle = BorderStyle.FixedSingle;
            tb_data.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data.Location = new Point(78, 103);
            tb_data.Multiline = true;
            tb_data.Name = "tb_data";
            tb_data.Size = new Size(785, 301);
            tb_data.TabIndex = 0;
            tb_data.TextChanged += tb_data_TextChanged;
            // 
            // tb_hash
            // 
            tb_hash.BorderStyle = BorderStyle.FixedSingle;
            tb_hash.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash.Location = new Point(78, 443);
            tb_hash.Multiline = true;
            tb_hash.Name = "tb_hash";
            tb_hash.ReadOnly = true;
            tb_hash.Size = new Size(785, 31);
            tb_hash.TabIndex = 1;
            // 
            // data_label
            // 
            data_label.AutoSize = true;
            data_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            data_label.Location = new Point(22, 103);
            data_label.Name = "data_label";
            data_label.Size = new Size(50, 21);
            data_label.TabIndex = 2;
            data_label.Text = "Data:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 443);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 3;
            label1.Text = "Hash:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(147, 30);
            label2.TabIndex = 4;
            label2.Text = "SHA265 Hash";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 542);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(data_label);
            Controls.Add(tb_hash);
            Controls.Add(tb_data);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blockchain Visualizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_data;
        private TextBox tb_hash;
        private Label data_label;
        private Label label1;
        private Label label2;
    }
}