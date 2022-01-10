namespace CSProject
{
    partial class content1_Form
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
            this.components = new System.ComponentModel.Container();
            this.wordLabel = new System.Windows.Forms.Label();
            this.nextLabel = new System.Windows.Forms.Label();
            this.prevLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.wordLabel.Location = new System.Drawing.Point(205, 59);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(92, 27);
            this.wordLabel.TabIndex = 0;
            this.wordLabel.Text = "label1";
            // 
            // nextLabel
            // 
            this.nextLabel.AutoSize = true;
            this.nextLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nextLabel.Location = new System.Drawing.Point(337, 72);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(58, 21);
            this.nextLabel.TabIndex = 1;
            this.nextLabel.Text = "label1";
            // 
            // prevLabel
            // 
            this.prevLabel.AutoSize = true;
            this.prevLabel.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.prevLabel.Location = new System.Drawing.Point(115, 72);
            this.prevLabel.Name = "prevLabel";
            this.prevLabel.Size = new System.Drawing.Size(58, 21);
            this.prevLabel.TabIndex = 2;
            this.prevLabel.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 222);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(187, 280);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(38, 12);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "뒤로가기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // content1_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(548, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.prevLabel);
            this.Controls.Add(this.nextLabel);
            this.Controls.Add(this.wordLabel);
            this.Name = "content1_Form";
            this.Text = "content1_Frame";
            this.Load += new System.EventHandler(this.Content1_Frame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Label nextLabel;
        private System.Windows.Forms.Label prevLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}