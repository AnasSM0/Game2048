﻿namespace ver3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlControl = new System.Windows.Forms.Panel();
            this.picReplay = new System.Windows.Forms.PictureBox();
            this.picUndo = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.PictureBox();
            this.pnlEndGame = new System.Windows.Forms.Panel();
            this.btnTryAgain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMenu)).BeginInit();
            this.pnlEndGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlControl.Controls.Add(this.picReplay);
            this.pnlControl.Controls.Add(this.picUndo);
            this.pnlControl.Controls.Add(this.lblScore);
            this.pnlControl.Controls.Add(this.lblBest);
            this.pnlControl.Controls.Add(this.lblMenu);
            this.pnlControl.Location = new System.Drawing.Point(1, 2);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(567, 100);
            this.pnlControl.TabIndex = 0;
            // 
            // picReplay
            // 
            this.picReplay.BackgroundImage = global::ver3.Properties.Resources.replay;
            this.picReplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picReplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReplay.Location = new System.Drawing.Point(87, 58);
            this.picReplay.Name = "picReplay";
            this.picReplay.Size = new System.Drawing.Size(30, 28);
            this.picReplay.TabIndex = 4;
            this.picReplay.TabStop = false;
            this.picReplay.Click += new System.EventHandler(this.picReplay_Click);
            // 
            // picUndo
            // 
            this.picUndo.BackgroundImage = global::ver3.Properties.Resources.undo;
            this.picUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUndo.Location = new System.Drawing.Point(34, 58);
            this.picUndo.Name = "picUndo";
            this.picUndo.Size = new System.Drawing.Size(30, 28);
            this.picUndo.TabIndex = 4;
            this.picUndo.TabStop = false;
            this.picUndo.Click += new System.EventHandler(this.picUndo_Click);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.SystemColors.Control;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(166, 12);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(200, 74);
            this.lblScore.TabIndex = 0;
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScore.Click += new System.EventHandler(this.lblScore_Click);
            // 
            // lblBest
            // 
            this.lblBest.BackColor = System.Drawing.SystemColors.Control;
            this.lblBest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBest.ForeColor = System.Drawing.Color.White;
            this.lblBest.Location = new System.Drawing.Point(383, 12);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(158, 74);
            this.lblBest.TabIndex = 0;
            this.lblBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBest.Click += new System.EventHandler(this.lblBest_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenu.Image = global::ver3.Properties.Resources.menu_icon;
            this.lblMenu.Location = new System.Drawing.Point(11, 10);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(139, 42);
            this.lblMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.lblMenu.TabIndex = 2;
            this.lblMenu.TabStop = false;
            this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // pnlEndGame
            // 
            this.pnlEndGame.Controls.Add(this.btnTryAgain);
            this.pnlEndGame.Controls.Add(this.label1);
            this.pnlEndGame.Location = new System.Drawing.Point(160, 283);
            this.pnlEndGame.Name = "pnlEndGame";
            this.pnlEndGame.Size = new System.Drawing.Size(200, 100);
            this.pnlEndGame.TabIndex = 1;
            this.pnlEndGame.Visible = false;
            this.pnlEndGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEndGame_Paint);
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnTryAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTryAgain.Location = new System.Drawing.Point(39, 60);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(123, 37);
            this.btnTryAgain.TabIndex = 1;
            this.btnTryAgain.Text = "Try again";
            this.btnTryAgain.UseVisualStyleBackColor = false;
            this.btnTryAgain.Click += new System.EventHandler(this.btnTryAgain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "GAME OVER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 646);
            this.Controls.Add(this.pnlEndGame);
            this.Controls.Add(this.pnlControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMenu)).EndInit();
            this.pnlEndGame.ResumeLayout(false);
            this.pnlEndGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.PictureBox picReplay;
        private System.Windows.Forms.PictureBox picUndo;
        public System.Windows.Forms.Label lblBest;
        public System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel pnlEndGame;
        private System.Windows.Forms.Button btnTryAgain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox lblMenu;
    }
}

