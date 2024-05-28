using System;
using System.Media;
using System.Windows.Forms;

namespace ver3
{
    public partial class MenuForm : Form
    {
        private SoundPlayer backgroundMusicPlayer;
        private bool isMuted;

        public MenuForm(SoundPlayer backgroundMusicPlayer, bool isMuted)
        {
            InitializeComponent();
            this.backgroundMusicPlayer = backgroundMusicPlayer;
            this.isMuted = isMuted;

            // Add difficulty buttons to menu form if needed
            Button btnEasy = new Button() { Text = "Easy (5x5)" };
            btnEasy.Click += (s, e) => ChangeDifficulty(5);

            Button btnMedium = new Button() { Text = "Medium (4x4)" };
            btnMedium.Click += (s, e) => ChangeDifficulty(4);

            Button btnHard = new Button() { Text = "Hard (3x3)" };
            btnHard.Click += (s, e) => ChangeDifficulty(3);

            this.Controls.Add(btnEasy);
            this.Controls.Add(btnMedium);
            this.Controls.Add(btnHard);
        }

        private void ChangeDifficulty(int gridSize)
        {
            ((Form1)this.Owner).ChangeDifficulty(gridSize);
            this.Close();
        }

        private void UpdateMuteIcon()
        {
            if (isMuted)
            {
                picMuteUnmute.Image = Properties.Resources.unmute; // Set to unmute icon
                lblMuteUnmute.Text = "Unmute Sound";
            }
            else
            {
                picMuteUnmute.Image = Properties.Resources.mute; // Set to mute icon
                lblMuteUnmute.Text = "Mute Sound";
            }
        }

        private void picMuteUnmute_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                backgroundMusicPlayer.PlayLooping();
                isMuted = false;
            }
            else
            {
                backgroundMusicPlayer.Stop();
                isMuted = true;
            }
            UpdateMuteIcon();
        }
    }
}
