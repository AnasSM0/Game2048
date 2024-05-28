using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ver3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Save.Click += new EventHandler(savebtn_Click_1); // Attach event handler
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Fname.Text = "Enter your Name";
            Fname.ForeColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fname_Click(object sender, EventArgs e)
        {
            Fname.BackColor = Color.White;
            panel3.BackColor = Color.White;
            Fname.SelectAll();
        }

        private void Fname_Enter(object sender, EventArgs e)
        {
            if (Fname.Text == "Enter your Name")
            {
                Fname.Text = "";
                Fname.ForeColor = Color.Black;
            }
        }

        private void Fname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Fname.Text))
            {
                Fname.Text = "Enter your Name";
                Fname.ForeColor = Color.LightGray;
            }
        }

        private void savebtn_Click_1(object sender, EventArgs e)
        {
            string playerName = Fname.Text.Trim();

            // Basic input validation
            if (string.IsNullOrWhiteSpace(playerName) || playerName == "Enter your Name")
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            // More specific validation (add checks as needed)
            if (playerName.Length > 50)
            {
                MessageBox.Show("Name cannot exceed 50 characters.");
                return;
            }

            try
            {
                bool savedSuccessfully = SavePlayerName(playerName);
                if (savedSuccessfully)
                {
                    MessageBox.Show("Player name saved successfully.");
                    OpenForm1(playerName);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Player name already exists.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error saving player name: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving player name: " + ex.Message);
            }
        }

        private bool SavePlayerName(string playerName)
        {
            string connectionString = @"Data Source=(localdb)\project;Initial Catalog=GameScore;Integrated Security=True"; // Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the player name already exists in the database
                string checkQuery = "SELECT COUNT(*) FROM BestScore WHERE PlayerName = @playerName";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@playerName", playerName);
                    connection.Open();
                    int existingCount = (int)checkCommand.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        // Player name already exists, return false
                        return false;
                    }
                }

                // Player name does not exist, proceed with insertion
                string insertQuery = "INSERT INTO BestScore (PlayerName, Score) VALUES (@playerName, 0)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@playerName", playerName);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        private void OpenForm1(string playerName)
        {
            if (Application.OpenForms["Form1"] == null)
            {
                Form1 form1 = new Form1(playerName); // Pass the player's name to Form1
                form1.Show(); // Show Form1
            }
        }

        // Empty definitions for missing event handlers
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void Save_MouseClick(object sender, MouseEventArgs e) { }
    }
}
