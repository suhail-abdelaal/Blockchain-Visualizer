namespace Blockchain_Visualizer.UserControls
{
    partial class UC_Blockchain
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
            btn_mine1 = new Button();
            lbl_block1 = new Label();
            tb_block1 = new TextBox();
            lbl_nonce1 = new Label();
            tb_nonce1 = new TextBox();
            lbl_block = new Label();
            lbl_hash1 = new Label();
            lbl1 = new Label();
            tb_hash1 = new TextBox();
            tb_data1 = new TextBox();
            panel1 = new Panel();
            label13 = new Label();
            tb_prev1 = new TextBox();
            btn_mine2 = new Button();
            label1 = new Label();
            tb_block2 = new TextBox();
            label2 = new Label();
            tb_nonce2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tb_hash2 = new TextBox();
            tb_data2 = new TextBox();
            panel2 = new Panel();
            label14 = new Label();
            tb_prev2 = new TextBox();
            btn_mine3 = new Button();
            label5 = new Label();
            tb_block3 = new TextBox();
            label6 = new Label();
            tb_nonce3 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tb_hash3 = new TextBox();
            tb_data3 = new TextBox();
            panel3 = new Panel();
            label15 = new Label();
            tb_prev3 = new TextBox();
            btn_mine4 = new Button();
            label9 = new Label();
            tb_block4 = new TextBox();
            label10 = new Label();
            tb_nonce4 = new TextBox();
            label11 = new Label();
            label12 = new Label();
            tb_hash4 = new TextBox();
            tb_data4 = new TextBox();
            panel4 = new Panel();
            label16 = new Label();
            tb_prev4 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btn_mine1
            // 
            btn_mine1.BackColor = Color.Transparent;
            btn_mine1.Location = new Point(267, 465);
            btn_mine1.Name = "btn_mine1";
            btn_mine1.Size = new Size(111, 39);
            btn_mine1.TabIndex = 29;
            btn_mine1.Text = "Mine";
            btn_mine1.UseVisualStyleBackColor = false;
            btn_mine1.Click += btn_mine1_Click;
            // 
            // lbl_block1
            // 
            lbl_block1.AutoSize = true;
            lbl_block1.BackColor = Color.White;
            lbl_block1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_block1.Location = new Point(23, 106);
            lbl_block1.Name = "lbl_block1";
            lbl_block1.Size = new Size(55, 19);
            lbl_block1.TabIndex = 28;
            lbl_block1.Text = "Block:";
            // 
            // tb_block1
            // 
            tb_block1.BorderStyle = BorderStyle.FixedSingle;
            tb_block1.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_block1.Location = new Point(84, 103);
            tb_block1.Multiline = true;
            tb_block1.Name = "tb_block1";
            tb_block1.Size = new Size(602, 28);
            tb_block1.TabIndex = 27;
            tb_block1.TextChanged += tb_block1_TextChanged;
            // 
            // lbl_nonce1
            // 
            lbl_nonce1.AutoSize = true;
            lbl_nonce1.BackColor = Color.White;
            lbl_nonce1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nonce1.Location = new Point(13, 149);
            lbl_nonce1.Name = "lbl_nonce1";
            lbl_nonce1.Size = new Size(65, 19);
            lbl_nonce1.TabIndex = 26;
            lbl_nonce1.Text = "Nonce:";
            // 
            // tb_nonce1
            // 
            tb_nonce1.BorderStyle = BorderStyle.FixedSingle;
            tb_nonce1.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nonce1.Location = new Point(84, 146);
            tb_nonce1.Multiline = true;
            tb_nonce1.Name = "tb_nonce1";
            tb_nonce1.Size = new Size(602, 28);
            tb_nonce1.TabIndex = 25;
            tb_nonce1.TextChanged += tb_nonce1_TextChanged;
            // 
            // lbl_block
            // 
            lbl_block.AutoSize = true;
            lbl_block.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_block.Location = new Point(9, 61);
            lbl_block.Name = "lbl_block";
            lbl_block.Size = new Size(125, 25);
            lbl_block.TabIndex = 24;
            lbl_block.Text = "Blockchain";
            // 
            // lbl_hash1
            // 
            lbl_hash1.AutoSize = true;
            lbl_hash1.BackColor = Color.White;
            lbl_hash1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_hash1.Location = new Point(27, 422);
            lbl_hash1.Name = "lbl_hash1";
            lbl_hash1.Size = new Size(51, 19);
            lbl_hash1.TabIndex = 23;
            lbl_hash1.Text = "Hash:";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.BackColor = Color.White;
            lbl1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(28, 192);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(50, 19);
            lbl1.TabIndex = 22;
            lbl1.Text = "Data:";
            // 
            // tb_hash1
            // 
            tb_hash1.BorderStyle = BorderStyle.FixedSingle;
            tb_hash1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash1.Location = new Point(84, 419);
            tb_hash1.Multiline = true;
            tb_hash1.Name = "tb_hash1";
            tb_hash1.ReadOnly = true;
            tb_hash1.Size = new Size(602, 31);
            tb_hash1.TabIndex = 21;
            // 
            // tb_data1
            // 
            tb_data1.BorderStyle = BorderStyle.FixedSingle;
            tb_data1.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data1.Location = new Point(84, 190);
            tb_data1.Multiline = true;
            tb_data1.Name = "tb_data1";
            tb_data1.ScrollBars = ScrollBars.Vertical;
            tb_data1.Size = new Size(602, 176);
            tb_data1.TabIndex = 20;
            tb_data1.TextChanged += tb_data1_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumAquamarine;
            panel1.Controls.Add(label13);
            panel1.Controls.Add(tb_prev1);
            panel1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(9, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(694, 426);
            panel1.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(18, 293);
            label13.Name = "label13";
            label13.Size = new Size(46, 19);
            label13.TabIndex = 62;
            label13.Text = "Prev:";
            label13.Click += label13_Click;
            // 
            // tb_prev1
            // 
            tb_prev1.BorderStyle = BorderStyle.FixedSingle;
            tb_prev1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_prev1.Location = new Point(75, 290);
            tb_prev1.Multiline = true;
            tb_prev1.Name = "tb_prev1";
            tb_prev1.ReadOnly = true;
            tb_prev1.Size = new Size(602, 31);
            tb_prev1.TabIndex = 61;
            tb_prev1.TextChanged += tb_prev1_TextChanged;
            // 
            // btn_mine2
            // 
            btn_mine2.Location = new Point(979, 465);
            btn_mine2.Name = "btn_mine2";
            btn_mine2.Size = new Size(111, 39);
            btn_mine2.TabIndex = 39;
            btn_mine2.Text = "Mine";
            btn_mine2.UseVisualStyleBackColor = true;
            btn_mine2.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(735, 106);
            label1.Name = "label1";
            label1.Size = new Size(55, 19);
            label1.TabIndex = 38;
            label1.Text = "Block:";
            // 
            // tb_block2
            // 
            tb_block2.BorderStyle = BorderStyle.FixedSingle;
            tb_block2.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_block2.Location = new Point(796, 103);
            tb_block2.Multiline = true;
            tb_block2.Name = "tb_block2";
            tb_block2.Size = new Size(594, 28);
            tb_block2.TabIndex = 37;
            tb_block2.TextChanged += tb_block2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(725, 149);
            label2.Name = "label2";
            label2.Size = new Size(65, 19);
            label2.TabIndex = 36;
            label2.Text = "Nonce:";
            // 
            // tb_nonce2
            // 
            tb_nonce2.BorderStyle = BorderStyle.FixedSingle;
            tb_nonce2.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nonce2.Location = new Point(796, 146);
            tb_nonce2.Multiline = true;
            tb_nonce2.Name = "tb_nonce2";
            tb_nonce2.Size = new Size(594, 28);
            tb_nonce2.TabIndex = 35;
            tb_nonce2.TextChanged += tb_nonce2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(739, 422);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 34;
            label3.Text = "Hash:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(740, 193);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 33;
            label4.Text = "Data:";
            // 
            // tb_hash2
            // 
            tb_hash2.BorderStyle = BorderStyle.FixedSingle;
            tb_hash2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash2.Location = new Point(796, 419);
            tb_hash2.Multiline = true;
            tb_hash2.Name = "tb_hash2";
            tb_hash2.ReadOnly = true;
            tb_hash2.Size = new Size(594, 31);
            tb_hash2.TabIndex = 32;
            // 
            // tb_data2
            // 
            tb_data2.BorderStyle = BorderStyle.FixedSingle;
            tb_data2.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data2.Location = new Point(796, 190);
            tb_data2.Multiline = true;
            tb_data2.Name = "tb_data2";
            tb_data2.ScrollBars = ScrollBars.Vertical;
            tb_data2.Size = new Size(594, 176);
            tb_data2.TabIndex = 31;
            tb_data2.TextChanged += tb_data2_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumAquamarine;
            panel2.Controls.Add(label14);
            panel2.Controls.Add(tb_prev2);
            panel2.Location = new Point(721, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(690, 426);
            panel2.TabIndex = 40;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(18, 293);
            label14.Name = "label14";
            label14.Size = new Size(46, 19);
            label14.TabIndex = 64;
            label14.Text = "Prev:";
            // 
            // tb_prev2
            // 
            tb_prev2.BorderStyle = BorderStyle.FixedSingle;
            tb_prev2.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_prev2.Location = new Point(75, 290);
            tb_prev2.Multiline = true;
            tb_prev2.Name = "tb_prev2";
            tb_prev2.ReadOnly = true;
            tb_prev2.Size = new Size(594, 31);
            tb_prev2.TabIndex = 63;
            // 
            // btn_mine3
            // 
            btn_mine3.Location = new Point(1687, 465);
            btn_mine3.Name = "btn_mine3";
            btn_mine3.Size = new Size(111, 39);
            btn_mine3.TabIndex = 49;
            btn_mine3.Text = "Mine";
            btn_mine3.UseVisualStyleBackColor = true;
            btn_mine3.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(1443, 106);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 48;
            label5.Text = "Block:";
            // 
            // tb_block3
            // 
            tb_block3.BorderStyle = BorderStyle.FixedSingle;
            tb_block3.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_block3.Location = new Point(1504, 103);
            tb_block3.Multiline = true;
            tb_block3.Name = "tb_block3";
            tb_block3.Size = new Size(618, 28);
            tb_block3.TabIndex = 47;
            tb_block3.TextChanged += tb_block3_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1433, 149);
            label6.Name = "label6";
            label6.Size = new Size(65, 19);
            label6.TabIndex = 46;
            label6.Text = "Nonce:";
            // 
            // tb_nonce3
            // 
            tb_nonce3.BorderStyle = BorderStyle.FixedSingle;
            tb_nonce3.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nonce3.Location = new Point(1504, 146);
            tb_nonce3.Multiline = true;
            tb_nonce3.Name = "tb_nonce3";
            tb_nonce3.Size = new Size(618, 28);
            tb_nonce3.TabIndex = 45;
            tb_nonce3.TextChanged += tb_nonce3_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1447, 422);
            label7.Name = "label7";
            label7.Size = new Size(51, 19);
            label7.TabIndex = 44;
            label7.Text = "Hash:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(1448, 193);
            label8.Name = "label8";
            label8.Size = new Size(50, 19);
            label8.TabIndex = 43;
            label8.Text = "Data:";
            // 
            // tb_hash3
            // 
            tb_hash3.BorderStyle = BorderStyle.FixedSingle;
            tb_hash3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash3.Location = new Point(1504, 419);
            tb_hash3.Multiline = true;
            tb_hash3.Name = "tb_hash3";
            tb_hash3.ReadOnly = true;
            tb_hash3.Size = new Size(618, 31);
            tb_hash3.TabIndex = 42;
            // 
            // tb_data3
            // 
            tb_data3.BorderStyle = BorderStyle.FixedSingle;
            tb_data3.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data3.Location = new Point(1504, 190);
            tb_data3.Multiline = true;
            tb_data3.Name = "tb_data3";
            tb_data3.ScrollBars = ScrollBars.Vertical;
            tb_data3.Size = new Size(618, 176);
            tb_data3.TabIndex = 41;
            tb_data3.TextChanged += tb_data3_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MediumAquamarine;
            panel3.Controls.Add(label15);
            panel3.Controls.Add(tb_prev3);
            panel3.Location = new Point(1429, 90);
            panel3.Name = "panel3";
            panel3.Size = new Size(707, 426);
            panel3.TabIndex = 50;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.White;
            label15.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(18, 293);
            label15.Name = "label15";
            label15.Size = new Size(46, 19);
            label15.TabIndex = 64;
            label15.Text = "Prev:";
            // 
            // tb_prev3
            // 
            tb_prev3.BorderStyle = BorderStyle.FixedSingle;
            tb_prev3.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_prev3.Location = new Point(75, 290);
            tb_prev3.Multiline = true;
            tb_prev3.Name = "tb_prev3";
            tb_prev3.ReadOnly = true;
            tb_prev3.Size = new Size(618, 31);
            tb_prev3.TabIndex = 63;
            // 
            // btn_mine4
            // 
            btn_mine4.Location = new Point(2409, 465);
            btn_mine4.Name = "btn_mine4";
            btn_mine4.Size = new Size(111, 39);
            btn_mine4.TabIndex = 59;
            btn_mine4.Text = "Mine";
            btn_mine4.UseVisualStyleBackColor = true;
            btn_mine4.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(2165, 106);
            label9.Name = "label9";
            label9.Size = new Size(55, 19);
            label9.TabIndex = 58;
            label9.Text = "Block:";
            // 
            // tb_block4
            // 
            tb_block4.BorderStyle = BorderStyle.FixedSingle;
            tb_block4.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_block4.Location = new Point(2226, 103);
            tb_block4.Multiline = true;
            tb_block4.Name = "tb_block4";
            tb_block4.Size = new Size(653, 28);
            tb_block4.TabIndex = 57;
            tb_block4.TextChanged += tb_block4_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(2155, 149);
            label10.Name = "label10";
            label10.Size = new Size(65, 19);
            label10.TabIndex = 56;
            label10.Text = "Nonce:";
            label10.Click += label10_Click;
            // 
            // tb_nonce4
            // 
            tb_nonce4.BorderStyle = BorderStyle.FixedSingle;
            tb_nonce4.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nonce4.Location = new Point(2226, 146);
            tb_nonce4.Multiline = true;
            tb_nonce4.Name = "tb_nonce4";
            tb_nonce4.Size = new Size(653, 28);
            tb_nonce4.TabIndex = 55;
            tb_nonce4.TextChanged += tb_nonce4_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(2169, 422);
            label11.Name = "label11";
            label11.Size = new Size(51, 19);
            label11.TabIndex = 54;
            label11.Text = "Hash:";
            label11.Click += label11_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(2170, 193);
            label12.Name = "label12";
            label12.Size = new Size(50, 19);
            label12.TabIndex = 53;
            label12.Text = "Data:";
            label12.Click += label12_Click;
            // 
            // tb_hash4
            // 
            tb_hash4.BorderStyle = BorderStyle.FixedSingle;
            tb_hash4.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_hash4.Location = new Point(2226, 419);
            tb_hash4.Multiline = true;
            tb_hash4.Name = "tb_hash4";
            tb_hash4.ReadOnly = true;
            tb_hash4.Size = new Size(653, 31);
            tb_hash4.TabIndex = 52;
            tb_hash4.TextChanged += tb_hash4_TextChanged;
            // 
            // tb_data4
            // 
            tb_data4.BorderStyle = BorderStyle.FixedSingle;
            tb_data4.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_data4.Location = new Point(2226, 190);
            tb_data4.Multiline = true;
            tb_data4.Name = "tb_data4";
            tb_data4.ScrollBars = ScrollBars.Vertical;
            tb_data4.Size = new Size(653, 176);
            tb_data4.TabIndex = 51;
            tb_data4.TextChanged += tb_data4_TextChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MediumAquamarine;
            panel4.Controls.Add(label16);
            panel4.Controls.Add(tb_prev4);
            panel4.Location = new Point(2151, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(743, 426);
            panel4.TabIndex = 60;
            panel4.Paint += panel4_Paint;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.White;
            label16.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(18, 293);
            label16.Name = "label16";
            label16.Size = new Size(46, 19);
            label16.TabIndex = 64;
            label16.Text = "Prev:";
            label16.Click += label16_Click;
            // 
            // tb_prev4
            // 
            tb_prev4.BorderStyle = BorderStyle.FixedSingle;
            tb_prev4.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_prev4.Location = new Point(75, 290);
            tb_prev4.Multiline = true;
            tb_prev4.Name = "tb_prev4";
            tb_prev4.ReadOnly = true;
            tb_prev4.Size = new Size(653, 31);
            tb_prev4.TabIndex = 63;
            // 
            // UC_Blockchain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.MediumAquamarine;
            Controls.Add(btn_mine4);
            Controls.Add(label9);
            Controls.Add(tb_block4);
            Controls.Add(label10);
            Controls.Add(tb_nonce4);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(tb_hash4);
            Controls.Add(tb_data4);
            Controls.Add(panel4);
            Controls.Add(btn_mine3);
            Controls.Add(label5);
            Controls.Add(tb_block3);
            Controls.Add(label6);
            Controls.Add(tb_nonce3);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(tb_hash3);
            Controls.Add(tb_data3);
            Controls.Add(panel3);
            Controls.Add(btn_mine2);
            Controls.Add(label1);
            Controls.Add(tb_block2);
            Controls.Add(label2);
            Controls.Add(tb_nonce2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(tb_hash2);
            Controls.Add(tb_data2);
            Controls.Add(panel2);
            Controls.Add(btn_mine1);
            Controls.Add(lbl_block1);
            Controls.Add(tb_block1);
            Controls.Add(lbl_nonce1);
            Controls.Add(tb_nonce1);
            Controls.Add(lbl_block);
            Controls.Add(lbl_hash1);
            Controls.Add(lbl1);
            Controls.Add(tb_hash1);
            Controls.Add(tb_data1);
            Controls.Add(panel1);
            Name = "UC_Blockchain";
            Size = new Size(2909, 525);
            Load += UC_Blockchain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_mine1;
        private Label lbl_block1;
        private TextBox tb_block1;
        private Label lbl_nonce1;
        private TextBox tb_nonce1;
        private Label lbl_block;
        private Label lbl_hash1;
        private Label lbl1;
        private TextBox tb_hash1;
        private TextBox tb_data1;
        private Panel panel1;
        private Button btn_mine2;
        private Label label1;
        private TextBox tb_block2;
        private Label label2;
        private TextBox tb_nonce2;
        private Label label3;
        private Label label4;
        private TextBox tb_hash2;
        private TextBox tb_data2;
        private Panel panel2;
        private Button btn_mine3;
        private Label label5;
        private TextBox tb_block3;
        private Label label6;
        private TextBox tb_nonce3;
        private Label label7;
        private Label label8;
        private TextBox tb_hash3;
        private TextBox tb_data3;
        private Panel panel3;
        private Button btn_mine4;
        private Label label9;
        private TextBox tb_block4;
        private Label label10;
        private TextBox tb_nonce4;
        private Label label11;
        private Label label12;
        private TextBox tb_hash4;
        private TextBox tb_data4;
        private Panel panel4;
        private Label label13;
        private TextBox tb_prev1;
        private Label label14;
        private TextBox tb_prev2;
        private Label label15;
        private TextBox tb_prev3;
        private Label label16;
        private TextBox tb_prev4;
    }
}
