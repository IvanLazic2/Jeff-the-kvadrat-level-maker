
namespace Jeff_The_Kvadrat_Level_Maker
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Platform1Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CharacterPanel = new System.Windows.Forms.Panel();
            this.Enemy1Panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LargeSpikesPanel = new System.Windows.Forms.Panel();
            this.WeirdSpikesPanel = new System.Windows.Forms.Panel();
            this.MediumSpikesPanel = new System.Windows.Forms.Panel();
            this.SmallSpikesPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.SpikedAreaPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 97);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // Platform1Panel
            // 
            this.Platform1Panel.BackColor = System.Drawing.Color.Black;
            this.Platform1Panel.Location = new System.Drawing.Point(15, 14);
            this.Platform1Panel.Name = "Platform1Panel";
            this.Platform1Panel.Size = new System.Drawing.Size(16, 16);
            this.Platform1Panel.TabIndex = 2;
            this.Platform1Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Platform1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Platform 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Character";
            // 
            // CharacterPanel
            // 
            this.CharacterPanel.BackColor = System.Drawing.Color.Blue;
            this.CharacterPanel.Location = new System.Drawing.Point(15, 36);
            this.CharacterPanel.Name = "CharacterPanel";
            this.CharacterPanel.Size = new System.Drawing.Size(16, 16);
            this.CharacterPanel.TabIndex = 5;
            this.CharacterPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Character_MouseClick);
            // 
            // Enemy1Panel
            // 
            this.Enemy1Panel.BackColor = System.Drawing.Color.Red;
            this.Enemy1Panel.Location = new System.Drawing.Point(15, 58);
            this.Enemy1Panel.Name = "Enemy1Panel";
            this.Enemy1Panel.Size = new System.Drawing.Size(16, 16);
            this.Enemy1Panel.TabIndex = 6;
            this.Enemy1Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Enemy1_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enemy 1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.SpikedAreaPanel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LargeSpikesPanel);
            this.panel1.Controls.Add(this.WeirdSpikesPanel);
            this.panel1.Controls.Add(this.MediumSpikesPanel);
            this.panel1.Controls.Add(this.SmallSpikesPanel);
            this.panel1.Controls.Add(this.Platform1Panel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Enemy1Panel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CharacterPanel);
            this.panel1.Location = new System.Drawing.Point(597, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 256);
            this.panel1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Large spikes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Weird spikes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Medium spikes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Small spikes";
            // 
            // LargeSpikesPanel
            // 
            this.LargeSpikesPanel.BackColor = System.Drawing.Color.SaddleBrown;
            this.LargeSpikesPanel.Location = new System.Drawing.Point(15, 163);
            this.LargeSpikesPanel.Name = "LargeSpikesPanel";
            this.LargeSpikesPanel.Size = new System.Drawing.Size(16, 16);
            this.LargeSpikesPanel.TabIndex = 10;
            this.LargeSpikesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LargeSpikesPanel_MouseClick);
            // 
            // WeirdSpikesPanel
            // 
            this.WeirdSpikesPanel.BackColor = System.Drawing.Color.Chocolate;
            this.WeirdSpikesPanel.Location = new System.Drawing.Point(15, 141);
            this.WeirdSpikesPanel.Name = "WeirdSpikesPanel";
            this.WeirdSpikesPanel.Size = new System.Drawing.Size(16, 16);
            this.WeirdSpikesPanel.TabIndex = 9;
            this.WeirdSpikesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WeirdSpikesPanel_MouseClick);
            // 
            // MediumSpikesPanel
            // 
            this.MediumSpikesPanel.BackColor = System.Drawing.Color.Orange;
            this.MediumSpikesPanel.Location = new System.Drawing.Point(15, 119);
            this.MediumSpikesPanel.Name = "MediumSpikesPanel";
            this.MediumSpikesPanel.Size = new System.Drawing.Size(16, 16);
            this.MediumSpikesPanel.TabIndex = 8;
            this.MediumSpikesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MediumSpikesPanel_MouseClick);
            // 
            // SmallSpikesPanel
            // 
            this.SmallSpikesPanel.BackColor = System.Drawing.Color.Yellow;
            this.SmallSpikesPanel.Location = new System.Drawing.Point(15, 97);
            this.SmallSpikesPanel.Name = "SmallSpikesPanel";
            this.SmallSpikesPanel.Size = new System.Drawing.Size(16, 16);
            this.SmallSpikesPanel.TabIndex = 7;
            this.SmallSpikesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SmallSpikesPanel_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Done";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(512, 279);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "File name";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(592, 417);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(115, 20);
            this.fileNameTextBox.TabIndex = 12;
            // 
            // SpikedAreaPanel
            // 
            this.SpikedAreaPanel.BackColor = System.Drawing.Color.Tan;
            this.SpikedAreaPanel.Location = new System.Drawing.Point(15, 185);
            this.SpikedAreaPanel.Name = "SpikedAreaPanel";
            this.SpikedAreaPanel.Size = new System.Drawing.Size(16, 16);
            this.SpikedAreaPanel.TabIndex = 11;
            this.SpikedAreaPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpikedAreaPanel_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Spiked area";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Platform1Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CharacterPanel;
        private System.Windows.Forms.Panel Enemy1Panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel LargeSpikesPanel;
        private System.Windows.Forms.Panel WeirdSpikesPanel;
        private System.Windows.Forms.Panel MediumSpikesPanel;
        private System.Windows.Forms.Panel SmallSpikesPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel SpikedAreaPanel;
    }
}

