namespace NuTeSuparaFrate.Forms
{
    partial class FormGame
    {

        private System.ComponentModel.IContainer components = null;
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
            this.btnRollDice = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.lblJucatorCurent = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRollDice
            // 
            this.btnRollDice.AutoSize = true;
            this.btnRollDice.Location = new System.Drawing.Point(780, 97);
            this.btnRollDice.Name = "btnRollDice";
            this.btnRollDice.Size = new System.Drawing.Size(151, 87);
            this.btnRollDice.TabIndex = 0;
            this.btnRollDice.Text = "Roll Dice";
            this.btnRollDice.UseVisualStyleBackColor = true;
            this.btnRollDice.Click += new System.EventHandler(this.btnRollDice_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(827, 341);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Ready";
            // 
            // pbBoard
            // 
            this.pbBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBoard.Image = global::NuTeSuparaFrate.Properties.Resources.LudoBoard;
            this.pbBoard.Location = new System.Drawing.Point(12, 3);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(660, 660);
            this.pbBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBoard.TabIndex = 2;
            this.pbBoard.TabStop = false;
            // 
            // lblJucatorCurent
            // 
            this.lblJucatorCurent.AutoSize = true;
            this.lblJucatorCurent.Location = new System.Drawing.Point(808, 386);
            this.lblJucatorCurent.Name = "lblJucatorCurent";
            this.lblJucatorCurent.Size = new System.Drawing.Size(92, 16);
            this.lblJucatorCurent.TabIndex = 3;
            this.lblJucatorCurent.Text = "Jucator Curent";
            this.lblJucatorCurent.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(801, 476);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 653);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblJucatorCurent);
            this.Controls.Add(this.pbBoard);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRollDice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGame";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGame_FormClosed_1);
            this.Load += new System.EventHandler(this.FormGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRollDice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.Label lblJucatorCurent;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}