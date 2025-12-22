namespace NuTeSuparaFrate.Forms
{
    partial class FormStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.btnStartGame = new System.Windows.Forms.Button();
            this.cbCuloare = new System.Windows.Forms.ComboBox();
            this.gbJucatori = new System.Windows.Forms.GroupBox();
            this.cbVerde = new System.Windows.Forms.CheckBox();
            this.cbGalben = new System.Windows.Forms.CheckBox();
            this.cbAlbastru = new System.Windows.Forms.CheckBox();
            this.cbRosu = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbJucatori.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(449, 87);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(137, 36);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // cbCuloare
            // 
            this.cbCuloare.FormattingEnabled = true;
            this.cbCuloare.Location = new System.Drawing.Point(395, 431);
            this.cbCuloare.Name = "cbCuloare";
            this.cbCuloare.Size = new System.Drawing.Size(254, 24);
            this.cbCuloare.TabIndex = 1;
            // 
            // gbJucatori
            // 
            this.gbJucatori.Controls.Add(this.cbVerde);
            this.gbJucatori.Controls.Add(this.cbGalben);
            this.gbJucatori.Controls.Add(this.cbAlbastru);
            this.gbJucatori.Controls.Add(this.cbRosu);
            this.gbJucatori.Location = new System.Drawing.Point(395, 163);
            this.gbJucatori.Name = "gbJucatori";
            this.gbJucatori.Size = new System.Drawing.Size(254, 183);
            this.gbJucatori.TabIndex = 2;
            this.gbJucatori.TabStop = false;
            this.gbJucatori.Text = "Alege Jucatorii (2-4)";
            // 
            // cbVerde
            // 
            this.cbVerde.AutoSize = true;
            this.cbVerde.Location = new System.Drawing.Point(6, 100);
            this.cbVerde.Name = "cbVerde";
            this.cbVerde.Size = new System.Drawing.Size(66, 20);
            this.cbVerde.TabIndex = 3;
            this.cbVerde.Text = "Verde";
            this.cbVerde.UseVisualStyleBackColor = true;
            // 
            // cbGalben
            // 
            this.cbGalben.AutoSize = true;
            this.cbGalben.Location = new System.Drawing.Point(6, 74);
            this.cbGalben.Name = "cbGalben";
            this.cbGalben.Size = new System.Drawing.Size(73, 20);
            this.cbGalben.TabIndex = 2;
            this.cbGalben.Text = "Galben";
            this.cbGalben.UseVisualStyleBackColor = true;
            // 
            // cbAlbastru
            // 
            this.cbAlbastru.AutoSize = true;
            this.cbAlbastru.Checked = true;
            this.cbAlbastru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAlbastru.Location = new System.Drawing.Point(6, 48);
            this.cbAlbastru.Name = "cbAlbastru";
            this.cbAlbastru.Size = new System.Drawing.Size(78, 20);
            this.cbAlbastru.TabIndex = 1;
            this.cbAlbastru.Text = "Albastru";
            this.cbAlbastru.UseVisualStyleBackColor = true;
            // 
            // cbRosu
            // 
            this.cbRosu.AutoSize = true;
            this.cbRosu.Checked = true;
            this.cbRosu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRosu.Location = new System.Drawing.Point(6, 21);
            this.cbRosu.Name = "cbRosu";
            this.cbRosu.Size = new System.Drawing.Size(61, 20);
            this.cbRosu.TabIndex = 0;
            this.cbRosu.Text = "Rosu";
            this.cbRosu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(459, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alege culoarea ta:";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbJucatori);
            this.Controls.Add(this.cbCuloare);
            this.Controls.Add(this.btnStartGame);
            this.Name = "FormStart";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStart_FormClosed);
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.gbJucatori.ResumeLayout(false);
            this.gbJucatori.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.ComboBox cbCuloare;
        private System.Windows.Forms.GroupBox gbJucatori;
        private System.Windows.Forms.CheckBox cbVerde;
        private System.Windows.Forms.CheckBox cbGalben;
        private System.Windows.Forms.CheckBox cbAlbastru;
        private System.Windows.Forms.CheckBox cbRosu;
        private System.Windows.Forms.Label label1;
    }
}