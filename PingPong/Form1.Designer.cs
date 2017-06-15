namespace PingPong
{
    partial class PONG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PONG));
            this.Field = new System.Windows.Forms.Panel();
            this.ScoreTable = new System.Windows.Forms.Label();
            this.Stick = new System.Windows.Forms.TextBox();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.PausedLabel = new System.Windows.Forms.Label();
            this.Field.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Field.Controls.Add(this.PausedLabel);
            this.Field.Controls.Add(this.ScoreTable);
            this.Field.Controls.Add(this.Stick);
            this.Field.Controls.Add(this.Ball);
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(1484, 562);
            this.Field.TabIndex = 2;
            // 
            // ScoreTable
            // 
            this.ScoreTable.AutoSize = true;
            this.ScoreTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ScoreTable.Font = new System.Drawing.Font("LilyUPC", 30F);
            this.ScoreTable.ForeColor = System.Drawing.Color.Lime;
            this.ScoreTable.Location = new System.Drawing.Point(12, 3);
            this.ScoreTable.Name = "ScoreTable";
            this.ScoreTable.Size = new System.Drawing.Size(121, 38);
            this.ScoreTable.TabIndex = 3;
            this.ScoreTable.Text = "SCORE : ";
            // 
            // Stick
            // 
            this.Stick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Stick.BackColor = System.Drawing.Color.Lime;
            this.Stick.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Stick.Location = new System.Drawing.Point(650, 508);
            this.Stick.Multiline = true;
            this.Stick.Name = "Stick";
            this.Stick.ReadOnly = true;
            this.Stick.Size = new System.Drawing.Size(204, 20);
            this.Stick.TabIndex = 2;
            this.Stick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stick_KeyDown);
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Lime;
            this.Ball.Location = new System.Drawing.Point(750, 10);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(20, 20);
            this.Ball.TabIndex = 1;
            this.Ball.TabStop = false;
            // 
            // Time
            // 
            this.Time.Enabled = true;
            this.Time.Interval = 1;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // PausedLabel
            // 
            this.PausedLabel.AutoSize = true;
            this.PausedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PausedLabel.ForeColor = System.Drawing.Color.Lime;
            this.PausedLabel.Location = new System.Drawing.Point(584, 225);
            this.PausedLabel.Name = "PausedLabel";
            this.PausedLabel.Size = new System.Drawing.Size(186, 46);
            this.PausedLabel.TabIndex = 4;
            this.PausedLabel.Text = "PAUSED";
            // 
            // PONG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 562);
            this.Controls.Add(this.Field);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PONG";
            this.Text = "PONG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Field.ResumeLayout(false);
            this.Field.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Field;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Stick;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Label ScoreTable;
        private System.Windows.Forms.Label PausedLabel;
    }
}

