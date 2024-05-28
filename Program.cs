using System;
using System.Windows.Forms;

namespace ver3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open Form2 to get the player name
            Form2 form2 = new Form2();
            Application.Run(form2); // Use Application.Run() to keep Form2 open until closed by the user

            // Once Form2 is closed, get the player name entered by the user
            //string playerName = form2.PlayerName;

            // Open Form1 (2048 game) with the player name
            //Application.Run(new Form1(playerName));
        }
    }
}
