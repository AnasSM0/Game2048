using System;
using System.Media;
using System.Windows.Forms;

namespace ver3
{
    public partial class MenuForm : Form
    {
        private SoundPlayer backgroundMusicPlayer;
        private bool isMuted;
        private int currentDifficultyIndex;
        private readonly int[] gridSizes = { 5, 4, 3 };
        private readonly string[] difficultyLabels = { "Easy", "Medium", "Hard" };

        public MenuForm(SoundPlayer backgroundMusicPlayer, bool isMuted)
        {
            InitializeComponent();
            this.backgroundMusicPlayer = backgroundMusicPlayer;
            this.isMuted = isMuted;
            this.currentDifficultyIndex = 0; // Start with Easy difficulty

            InitializeDifficultyControl();
            InitializeMuteControl();
        }

        private void InitializeDifficultyControl()
        {
            this.Difficulty.Image = Properties.Resources.easy; // Initial image
            this.Difficulty.Click += PicDifficulty_Click;
            this.label1.Text = difficultyLabels[currentDifficultyIndex]; // Initial label
        }

        private void InitializeMuteControl()
        {
            this.picMuteUnmute.Image = isMuted ? Properties.Resources.mute : Properties.Resources.unmute; // Initial image
            this.lblMuteUnmute.Text = isMuted ? "Unmute Sound" : "Mute Sound"; // Initial label
        }

        private void PicDifficulty_Click(object sender, EventArgs e)
        {
            // Cycle through difficulty levels
            currentDifficultyIndex = (currentDifficultyIndex + 1) % gridSizes.Length;

            // Update PictureBox image and label text based on the new difficulty
            switch (currentDifficultyIndex)
            {
                case 0:
                    this.Difficulty.Image = Properties.Resources.easy;
                    break;
                case 1:
                    this.Difficulty.Image = Properties.Resources.medium;
                    break;
                case 2:
                    this.Difficulty.Image = Properties.Resources.hard;
                    break;
            }

            // Update the label text
            this.label1.Text = difficultyLabels[currentDifficultyIndex];

            // Change the difficulty in the main form
            ChangeDifficulty(gridSizes[currentDifficultyIndex]);
        }

        private void ChangeDifficulty(int gridSize)
        {
            if (this.Owner is Form1 mainForm)
            {
                mainForm.ChangeDifficulty(gridSize);
            }
            else
            {
                // Handle the case where the Owner is not set or not of type Form1
                MessageBox.Show("Main form is not set as owner.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMuteIcon()
        {
            if (isMuted)
            {
                this.picMuteUnmute.Image = Properties.Resources.unmute; // Set to unmute icon
                this.lblMuteUnmute.Text = "Unmute Sound";
            }
            else
            {
                this.picMuteUnmute.Image = Properties.Resources.mute; // Set to mute icon
                this.lblMuteUnmute.Text = "Mute Sound";
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

        private void MenuForm_Load(object sender, EventArgs e)
        {
        }
    }
}
