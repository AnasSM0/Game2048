using System.Windows.Forms;

namespace ver3
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picMuteUnmute;
        private Label lblMuteUnmute;
        private PictureBox Difficulty;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.lblMuteUnmute = new System.Windows.Forms.Label();
            this.picMuteUnmute = new System.Windows.Forms.PictureBox();
            this.Difficulty = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMuteUnmute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Difficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMuteUnmute
            // 
            this.lblMuteUnmute.AutoSize = true;
            this.lblMuteUnmute.Location = new System.Drawing.Point(115, 101);
            this.lblMuteUnmute.Name = "lblMuteUnmute";
            this.lblMuteUnmute.Size = new System.Drawing.Size(65, 13);
            this.lblMuteUnmute.TabIndex = 1;
            this.lblMuteUnmute.Text = "Mute Sound";
            // 
            // picMuteUnmute
            // 
            this.picMuteUnmute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMuteUnmute.Image = global::ver3.Properties.Resources.mute;
            this.picMuteUnmute.Location = new System.Drawing.Point(116, 24);
            this.picMuteUnmute.Name = "picMuteUnmute";
            this.picMuteUnmute.Size = new System.Drawing.Size(64, 64);
            this.picMuteUnmute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMuteUnmute.TabIndex = 0;
            this.picMuteUnmute.TabStop = false;
            this.picMuteUnmute.Click += new System.EventHandler(this.picMuteUnmute_Click);
            // 
            // Difficulty
            // 
            this.Difficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Difficulty.Image = global::ver3.Properties.Resources.medium;
            this.Difficulty.Location = new System.Drawing.Point(75, 152);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(154, 66);
            this.Difficulty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Difficulty.TabIndex = 2;
            this.Difficulty.TabStop = false;
            this.Difficulty.Click += new System.EventHandler(this.PicDifficulty_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Change Difficulty";
            // 
            // MenuForm
            // 
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(300, 398);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.picMuteUnmute);
            this.Controls.Add(this.lblMuteUnmute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMuteUnmute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Difficulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
