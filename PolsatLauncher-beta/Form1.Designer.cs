
namespace PolsatLauncher_beta
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            comboBox1 = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            trackBar1 = new System.Windows.Forms.TrackBar();
            label3 = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            label4 = new System.Windows.Forms.Label();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            checkBox2 = new System.Windows.Forms.CheckBox();
            button2 = new System.Windows.Forms.Button();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            checkBox3 = new System.Windows.Forms.CheckBox();
            button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Location = new System.Drawing.Point(59, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(346, 16);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.Control;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(12, 136);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(393, 47);
            button1.TabIndex = 1;
            button1.Text = "Uruchom minecraft";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = System.Drawing.Color.White;
            comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(59, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(346, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox1.Location = new System.Drawing.Point(165, 189);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(85, 21);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "FullScreen";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox2.Location = new System.Drawing.Point(197, 44);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(65, 15);
            textBox2.TabIndex = 4;
            textBox2.Text = "854";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox3.Location = new System.Drawing.Point(290, 44);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(65, 15);
            textBox3.TabIndex = 5;
            textBox3.Text = "480";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(174, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 17);
            label1.TabIndex = 6;
            label1.Text = "X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(268, 44);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 17);
            label2.TabIndex = 7;
            label2.Text = "Y:";
            // 
            // trackBar1
            // 
            trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            trackBar1.LargeChange = 1024;
            trackBar1.Location = new System.Drawing.Point(12, 214);
            trackBar1.Maximum = 16384;
            trackBar1.Minimum = 1024;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(393, 45);
            trackBar1.SmallChange = 1024;
            trackBar1.TabIndex = 1024;
            trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            trackBar1.Value = 5120;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(113, 242);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(185, 17);
            label3.TabIndex = 9;
            label3.Text = "Wybrana pamięć: 5120/16384";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = System.Drawing.SystemColors.Control;
            progressBar1.Location = new System.Drawing.Point(12, 290);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(393, 23);
            progressBar1.TabIndex = 1025;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(48, 272);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(48, 17);
            label4.TabIndex = 1026;
            label4.Text = "Status:";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            richTextBox1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            richTextBox1.Location = new System.Drawing.Point(413, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(434, 313);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(4, 14);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 17);
            label5.TabIndex = 1029;
            label5.Text = "Wersja:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(4, 73);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 17);
            label6.TabIndex = 1030;
            label6.Text = "Nick:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(4, 272);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(0, 15);
            label7.TabIndex = 1031;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox2.Location = new System.Drawing.Point(6, 104);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(138, 21);
            checkBox2.TabIndex = 1032;
            checkBox2.Text = "Użyj konta premium";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.Control;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(148, 99);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(257, 31);
            button2.TabIndex = 1033;
            button2.Text = "Microsoft login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Polsat Launcher [BETA]";
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox3.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            checkBox3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox3.Location = new System.Drawing.Point(6, 42);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(162, 21);
            checkBox3.TabIndex = 1034;
            checkBox3.Text = "Pokaż status na Discord";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(387, 267);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(20, 20);
            button3.TabIndex = 1035;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoSize = true;
            BackColor = System.Drawing.SystemColors.ControlLight;
            ClientSize = new System.Drawing.Size(849, 321);
            Controls.Add(button3);
            Controls.Add(checkBox3);
            Controls.Add(button2);
            Controls.Add(checkBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(label4);
            Controls.Add(progressBar1);
            Controls.Add(label3);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(checkBox1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Polsat Launcher [BETA]";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button button3;
    }
}

