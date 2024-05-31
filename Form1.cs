using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace ver3
{
    public partial class Form1 : Form
    {
        private Game2048 game;
        private string playerName;
        private SoundPlayer backgroundMusicPlayer;
        private bool isMuted = false;
        private ContextMenuStrip contextMenu;
        private const int BackgroundSize = 550;
        public Form1(string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;

            InitializeGame(5); // Default to 4x4 grid

            // Initialize and play background music
            InitializeBackgroundMusic();

            // Initialize context menu
            InitializeContextMenu();
        }

        private void InitializeGame(int gridSize)
        {
            if (game != null)
            {
                this.Controls.Remove(game);
                game.Dispose();
            }

            try
            {
                GameInfo gameInfo = Loger.LoadData<GameInfo>(@"Game2048-Data\DATA.xml");
                if (!gameInfo.isEndGame)
                    game = gameInfo.ToGame2048();
                else
                    game = new Game2048(new Point(0, 100), true, gridSize);
            }
            catch (Exception)
            {
                game = new Game2048(new Point(0, 100), true, gridSize);
            }

            game.EndGameEvent += Game_EndGameEvent;
            game.TangDiemEvent += Game_TangDiemEvent;
            Setting.SetDoubleBuffered(game);

            // Adjust game size and location based on grid size
            //AdjustGameSize(gridSize);

            this.Controls.Add(game);
            game.Show();
        }

        private void InitializeContextMenu()
        {
            contextMenu = new ContextMenuStrip();

            ToolStripMenuItem muteMenuItem = new ToolStripMenuItem("Mute", null, MuteMenuItem_Click);
            contextMenu.Items.Add(muteMenuItem);

            ToolStripMenuItem easyMenuItem = new ToolStripMenuItem("Easy (5x5)", null, (s, e) => ChangeDifficulty(5));
            contextMenu.Items.Add(easyMenuItem);

            ToolStripMenuItem mediumMenuItem = new ToolStripMenuItem("Medium (4x4)", null, (s, e) => ChangeDifficulty(4));
            contextMenu.Items.Add(mediumMenuItem);

            ToolStripMenuItem hardMenuItem = new ToolStripMenuItem("Hard (3x3)", null, (s, e) => ChangeDifficulty(3));
            contextMenu.Items.Add(hardMenuItem);

            lblMenu.ContextMenuStrip = contextMenu;
        }

        private void OpenMenuForm()
        {
            using (var menuForm = new MenuForm(backgroundMusicPlayer, isMuted))
            {
                menuForm.Owner = this; // Set the Owner property
                menuForm.ShowDialog();
            }
        }

        private void AdjustGameSize(int gridSize)
        {
            int cellSize = (BackgroundSize - (gridSize + 1) * 10) / gridSize; // calculate cell size based on grid size
            //game.SetGridSize(gridSize, cellSize, 10); // assuming you have a method to set grid size, cell size, and margin in Game2048
            game.Size = new Size(BackgroundSize, BackgroundSize);
            game.Location = new Point(
                (this.ClientSize.Width - game.Width) / 2,
                (this.ClientSize.Height - game.Height) / 2 + 50 // Adjust Y to account for other UI elements
            );
        }


        public void ChangeDifficulty(int gridSize)
        {
            InitializeGame(gridSize);
        }

        private void InitializeBackgroundMusic()
        {
            string musicFilePath = @"C:\Users\Veeeeenum\Desktop\2048-main\Game 2048\Resources\music.wav";
            backgroundMusicPlayer = new SoundPlayer(musicFilePath);
            backgroundMusicPlayer.PlayLooping();
        }

        private void MuteMenuItem_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                backgroundMusicPlayer.PlayLooping();
                ((ToolStripMenuItem)contextMenu.Items[0]).Text = "Mute";
            }
            else
            {
                backgroundMusicPlayer.Stop();
                ((ToolStripMenuItem)contextMenu.Items[0]).Text = "Unmute";
            }
            isMuted = !isMuted;
        }

        private void Game_EndGameEvent(object sender, EventArgs e)
        {
            pnlEndGame.Visible = true;
            SavePlayerScore(); // Save the player's score when the game ends
        }

        private void Game_TangDiemEvent(object sender, EventArgs e)
        {
            int score = (sender as Game2048).score;
            lblScore.Text = $"{playerName}\r\n" + score.ToString();

            int bestScore = (sender as Game2048).bestScore;
            lblBest.Text = $"BEST\r\n{bestScore}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.Game2048_KeyDown(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMenu.ForeColor = Color.FromArgb(119, 110, 101);
            pnlControl.BackColor = Color.FromArgb(250, 248, 239);
            lblBest.BackColor = lblScore.BackColor = Color.FromArgb(187, 173, 160);

            int score = game.score;
            lblScore.Text = $"{playerName}\r\n{score}";
            int bestScore = game.bestScore;
            lblBest.Text = $"BEST\r\n{bestScore}";
        }

        private void picUndo_Click(object sender, EventArgs e)
        {
            game.Undo();
        }

        private void picReplay_Click(object sender, EventArgs e)
        {
            game.Replay();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Loger.SaveData(@"Game2048-Data\DATA.xml", game.Get_GameInfo());
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            pnlEndGame.Visible = false;
            game.isEndGame = false;
            game.Replay();
        }

        private void lblScore_Click(object sender, EventArgs e) { }

        private void lblBest_Click(object sender, EventArgs e)
        {
            ShowLeaderboard();
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            using (MenuForm menuForm = new MenuForm(backgroundMusicPlayer, isMuted))
            {
                menuForm.Owner = this; // Set the Owner property to the current instance of Form1
                menuForm.ShowDialog();
            }
        }

        // Method to save the player's score when the game ends
        private void SavePlayerScore()
        {
            string connectionString = "Data Source=(localdb)\\project;Initial Catalog=GameScore;Integrated Security=True"; // Update this with your actual connection string
            int playerScore = game.score;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the player's new score is higher than their existing score
                string checkQuery = "SELECT Score FROM BestScore WHERE PlayerName = @playerName";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@playerName", playerName);

                connection.Open();
                object result = checkCommand.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int existingScore = Convert.ToInt32(result);
                    if (playerScore > existingScore)
                    {
                        // Update the score if the new score is higher
                        string updateQuery = "UPDATE BestScore SET Score = @score WHERE PlayerName = @playerName";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@score", playerScore);
                        updateCommand.Parameters.AddWithValue("@playerName", playerName);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Insert the new player score if no existing score is found
                    string insertQuery = "INSERT INTO BestScore (PlayerName, Score) VALUES (@playerName, @score)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@score", playerScore);
                    insertCommand.Parameters.AddWithValue("@playerName", playerName);
                    insertCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // Method to show the leaderboard
        private void ShowLeaderboard()
        {
            string connectionString = "Data Source=(localdb)\\project;Initial Catalog=GameScore;Integrated Security=True"; // Update this with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PlayerName, Score FROM BestScore ORDER BY Score DESC";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                // Create a new form to display the leaderboard
                Form leaderboardForm = new Form
                {
                    Text = "Leaderboard",
                    Size = new Size(400, 400), // Set the size
                    FormBorderStyle = FormBorderStyle.FixedDialog, // Make the form non-resizable
                    StartPosition = FormStartPosition.CenterScreen // Center the form on the screen
                };

                DataGridView dataGridView = new DataGridView
                {
                    DataSource = dataTable,
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Adjust columns to fill the width of the form
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                };

                leaderboardForm.Controls.Add(dataGridView);
                leaderboardForm.ShowDialog();
            }
        }

        private void lbl2048_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void pnlEndGame_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
