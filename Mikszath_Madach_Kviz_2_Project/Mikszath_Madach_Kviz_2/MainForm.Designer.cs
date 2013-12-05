namespace Mikszath_Madach_Kviz_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.footerLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.hintButton = new System.Windows.Forms.Button();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.hintLabel = new System.Windows.Forms.Label();
            this.submitLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(261, 10);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(82, 25);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header";
            // 
            // footerLabel
            // 
            this.footerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.footerLabel.AutoSize = true;
            this.footerLabel.BackColor = System.Drawing.Color.Transparent;
            this.footerLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerLabel.Location = new System.Drawing.Point(359, 9);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(229, 112);
            this.footerLabel.TabIndex = 1;
            this.footerLabel.Text = "A táblázatot tervezte és kivitelezte:\r\nBőhm András\r\n\r\nA szoftvert írta:\r\nDonkó Is" +
    "tván\r\n\r\nAz XYZ megbízásából";
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.footerLabel.DoubleClick += new System.EventHandler(this.footerLabel_DoubleClick);
            // 
            // helpButton
            // 
            this.helpButton.BackgroundImage = global::Mikszath_Madach_Kviz_2.Properties.Resources.help_icon_stretched;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpButton.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.Blue;
            this.helpButton.Location = new System.Drawing.Point(12, 133);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(100, 115);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = global::Mikszath_Madach_Kviz_2.Properties.Resources.helpString;
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // hintButton
            // 
            this.hintButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hintButton.BackgroundImage")));
            this.hintButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hintButton.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.hintButton.Location = new System.Drawing.Point(12, 254);
            this.hintButton.Name = "hintButton";
            this.hintButton.Size = new System.Drawing.Size(100, 115);
            this.hintButton.TabIndex = 3;
            this.hintButton.Text = global::Mikszath_Madach_Kviz_2.Properties.Resources.hintString;
            this.hintButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.hintButton.UseVisualStyleBackColor = true;
            this.hintButton.Click += new System.EventHandler(this.hintButton_Click);
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackgroundImage = global::Mikszath_Madach_Kviz_2.Properties.Resources.refresh_stretched;
            this.shuffleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shuffleButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shuffleButton.ForeColor = System.Drawing.Color.OliveDrab;
            this.shuffleButton.Location = new System.Drawing.Point(12, 12);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(100, 115);
            this.shuffleButton.TabIndex = 1;
            this.shuffleButton.Text = global::Mikszath_Madach_Kviz_2.Properties.Resources.shuffleString;
            this.shuffleButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.BackgroundImage = global::Mikszath_Madach_Kviz_2.Properties.Resources.Evaluate_try_stretched;
            this.submitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submitButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.Red;
            this.submitButton.Location = new System.Drawing.Point(12, 414);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 115);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = global::Mikszath_Madach_Kviz_2.Properties.Resources.submitString;
            this.submitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintLabel.Location = new System.Drawing.Point(9, 372);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(83, 16);
            this.hintLabel.TabIndex = 6;
            this.hintLabel.Text = "Segítségek: ";
            // 
            // submitLabel
            // 
            this.submitLabel.AutoSize = true;
            this.submitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitLabel.Location = new System.Drawing.Point(9, 532);
            this.submitLabel.Name = "submitLabel";
            this.submitLabel.Size = new System.Drawing.Size(105, 16);
            this.submitLabel.TabIndex = 7;
            this.submitLabel.Text = "Próbálkozások: ";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(12, 551);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(80, 36);
            this.timerLabel.TabIndex = 8;
            this.timerLabel.Text = "00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.footerLabel);
            this.Controls.Add(this.submitLabel);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.shuffleButton);
            this.Controls.Add(this.hintButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.headerLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Mikszáth_Madách_Kvíz";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.mainForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label footerLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button hintButton;
        private System.Windows.Forms.Button shuffleButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.Label submitLabel;
        private System.Windows.Forms.Label timerLabel;
    }
}

