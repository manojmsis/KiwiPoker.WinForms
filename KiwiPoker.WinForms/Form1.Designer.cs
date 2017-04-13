namespace KiwiPoker.WinForms
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtNoOfPlayers = new System.Windows.Forms.TextBox();
            this.txtNoOfRounds = new System.Windows.Forms.TextBox();
            this.txtNoOfShuffles = new System.Windows.Forms.TextBox();
            this.lblNoOfPlayers = new System.Windows.Forms.Label();
            this.lblNoOfRounds = new System.Windows.Forms.Label();
            this.lblNoOfShuffles = new System.Windows.Forms.Label();
            this.txtScoreBoard = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Play Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtNoOfPlayers
            // 
            this.txtNoOfPlayers.Location = new System.Drawing.Point(178, 12);
            this.txtNoOfPlayers.Name = "txtNoOfPlayers";
            this.txtNoOfPlayers.Size = new System.Drawing.Size(100, 22);
            this.txtNoOfPlayers.TabIndex = 2;
            // 
            // txtNoOfRounds
            // 
            this.txtNoOfRounds.Location = new System.Drawing.Point(178, 53);
            this.txtNoOfRounds.Name = "txtNoOfRounds";
            this.txtNoOfRounds.Size = new System.Drawing.Size(100, 22);
            this.txtNoOfRounds.TabIndex = 3;
            // 
            // txtNoOfShuffles
            // 
            this.txtNoOfShuffles.Location = new System.Drawing.Point(483, 12);
            this.txtNoOfShuffles.Name = "txtNoOfShuffles";
            this.txtNoOfShuffles.Size = new System.Drawing.Size(100, 22);
            this.txtNoOfShuffles.TabIndex = 4;
            // 
            // lblNoOfPlayers
            // 
            this.lblNoOfPlayers.Location = new System.Drawing.Point(61, 15);
            this.lblNoOfPlayers.Name = "lblNoOfPlayers";
            this.lblNoOfPlayers.Size = new System.Drawing.Size(100, 23);
            this.lblNoOfPlayers.TabIndex = 5;
            this.lblNoOfPlayers.Text = "No Of Players";
            // 
            // lblNoOfRounds
            // 
            this.lblNoOfRounds.Location = new System.Drawing.Point(61, 56);
            this.lblNoOfRounds.Name = "lblNoOfRounds";
            this.lblNoOfRounds.Size = new System.Drawing.Size(100, 23);
            this.lblNoOfRounds.TabIndex = 6;
            this.lblNoOfRounds.Text = "No Of Rounds";
            // 
            // lblNoOfShuffles
            // 
            this.lblNoOfShuffles.Location = new System.Drawing.Point(355, 12);
            this.lblNoOfShuffles.Name = "lblNoOfShuffles";
            this.lblNoOfShuffles.Size = new System.Drawing.Size(122, 23);
            this.lblNoOfShuffles.TabIndex = 7;
            this.lblNoOfShuffles.Text = "No Of Shuffles";
            // 
            // txtScoreBoard
            // 
            this.txtScoreBoard.Location = new System.Drawing.Point(28, 123);
            this.txtScoreBoard.Name = "txtScoreBoard";
            this.txtScoreBoard.Size = new System.Drawing.Size(1000, 648);
            this.txtScoreBoard.TabIndex = 8;
            this.txtScoreBoard.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 803);
            this.Controls.Add(this.txtScoreBoard);
            this.Controls.Add(this.lblNoOfShuffles);
            this.Controls.Add(this.lblNoOfRounds);
            this.Controls.Add(this.lblNoOfPlayers);
            this.Controls.Add(this.txtNoOfShuffles);
            this.Controls.Add(this.txtNoOfRounds);
            this.Controls.Add(this.txtNoOfPlayers);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNoOfPlayers;
        private System.Windows.Forms.TextBox txtNoOfRounds;
        private System.Windows.Forms.TextBox txtNoOfShuffles;
        private System.Windows.Forms.Label lblNoOfPlayers;
        private System.Windows.Forms.Label lblNoOfRounds;
        private System.Windows.Forms.Label lblNoOfShuffles;
        private System.Windows.Forms.RichTextBox txtScoreBoard;
    }
}

