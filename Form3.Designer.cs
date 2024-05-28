using System.Windows.Forms;

namespace ver3
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picMuteUnmute;
        private Label lblMuteUnmute;

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
            ((System.ComponentModel.ISupportInitialize)(this.picMuteUnmute)).BeginInit();
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
            this.picMuteUnmute.Image = global::ver3.Properties.Resources.mute;
            this.picMuteUnmute.Location = new System.Drawing.Point(116, 24);
            this.picMuteUnmute.Name = "picMuteUnmute";
            this.picMuteUnmute.Size = new System.Drawing.Size(64, 64);
            this.picMuteUnmute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMuteUnmute.TabIndex = 0;
            this.picMuteUnmute.TabStop = false;
            this.picMuteUnmute.Click += new System.EventHandler(this.picMuteUnmute_Click);
            // 
            // MenuForm
            // 
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(300, 398);
            this.Controls.Add(this.picMuteUnmute);
            this.Controls.Add(this.lblMuteUnmute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.picMuteUnmute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
