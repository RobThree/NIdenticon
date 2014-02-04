namespace TestApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.PictureBox();
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.HorizontalBox = new System.Windows.Forms.NumericUpDown();
            this.VerticalBox = new System.Windows.Forms.NumericUpDown();
            this.HeightBox = new System.Windows.Forms.NumericUpDown();
            this.WidthBox = new System.Windows.Forms.NumericUpDown();
            this.BackgroundColorBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AlgorithmBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorGenBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(216, 219);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 9;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultBox.Location = new System.Drawing.Point(318, 12);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(400, 400);
            this.ResultBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ResultBox.TabIndex = 1;
            this.ResultBox.TabStop = false;
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(101, 73);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(185, 20);
            this.ValueBox.TabIndex = 5;
            this.ValueBox.Text = "Identicon demo";
            // 
            // HorizontalBox
            // 
            this.HorizontalBox.Location = new System.Drawing.Point(81, 19);
            this.HorizontalBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HorizontalBox.Name = "HorizontalBox";
            this.HorizontalBox.Size = new System.Drawing.Size(50, 20);
            this.HorizontalBox.TabIndex = 1;
            this.HorizontalBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // VerticalBox
            // 
            this.VerticalBox.Location = new System.Drawing.Point(81, 45);
            this.VerticalBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VerticalBox.Name = "VerticalBox";
            this.VerticalBox.Size = new System.Drawing.Size(50, 20);
            this.VerticalBox.TabIndex = 3;
            this.VerticalBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(81, 45);
            this.HeightBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(50, 20);
            this.HeightBox.TabIndex = 3;
            this.HeightBox.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(81, 19);
            this.WidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(50, 20);
            this.WidthBox.TabIndex = 1;
            this.WidthBox.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // BackgroundColorBox
            // 
            this.BackgroundColorBox.BackColor = System.Drawing.Color.White;
            this.BackgroundColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackgroundColorBox.Location = new System.Drawing.Point(101, 99);
            this.BackgroundColorBox.Name = "BackgroundColorBox";
            this.BackgroundColorBox.Size = new System.Drawing.Size(25, 20);
            this.BackgroundColorBox.TabIndex = 401;
            this.BackgroundColorBox.TabStop = false;
            this.BackgroundColorBox.Click += new System.EventHandler(this.BackgroundColorBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ColorGenBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.AlgorithmBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BackgroundColorBox);
            this.groupBox1.Controls.Add(this.CreateButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ValueBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identicon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Algorithm";
            // 
            // AlgorithmBox
            // 
            this.AlgorithmBox.DisplayMember = "SHA256";
            this.AlgorithmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmBox.FormattingEnabled = true;
            this.AlgorithmBox.Items.AddRange(new object[] {
            "HMACMD5",
            "HMACRIPEMD160",
            "HMACSHA1",
            "HMACSHA256",
            "HMACSHA384",
            "HMACSHA512",
            "MACTripleDES",
            "MD5",
            "RIPEMD160",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.AlgorithmBox.Location = new System.Drawing.Point(101, 19);
            this.AlgorithmBox.Name = "AlgorithmBox";
            this.AlgorithmBox.Size = new System.Drawing.Size(184, 21);
            this.AlgorithmBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Background";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.VerticalBox);
            this.groupBox3.Controls.Add(this.HorizontalBox);
            this.groupBox3.Location = new System.Drawing.Point(152, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 74);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blocks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vertical";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Horizontal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.WidthBox);
            this.groupBox2.Controls.Add(this.HeightBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 74);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image dimensions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Value";
            // 
            // ColorGenBox
            // 
            this.ColorGenBox.DisplayMember = "SHA256";
            this.ColorGenBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorGenBox.FormattingEnabled = true;
            this.ColorGenBox.Items.AddRange(new object[] {
            "Random",
            "Static"});
            this.ColorGenBox.Location = new System.Drawing.Point(101, 46);
            this.ColorGenBox.Name = "ColorGenBox";
            this.ColorGenBox.Size = new System.Drawing.Size(184, 21);
            this.ColorGenBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Color generator";
            // 
            // MainForm
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(740, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ResultBox);
            this.Name = "MainForm";
            this.Text = "TestApp";
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.PictureBox ResultBox;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.NumericUpDown HorizontalBox;
        private System.Windows.Forms.NumericUpDown VerticalBox;
        private System.Windows.Forms.NumericUpDown HeightBox;
        private System.Windows.Forms.NumericUpDown WidthBox;
        private System.Windows.Forms.PictureBox BackgroundColorBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlgorithmBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ColorGenBox;
    }
}

