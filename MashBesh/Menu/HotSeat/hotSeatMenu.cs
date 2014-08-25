using System;
using System.Windows.Forms;

namespace MashBesh
{
    public partial class hotSeatMenu : Form
    {
        FormClosedEventHandler gameFormClosedEvent;
        EventHandler gameFormShownEvent;
        //public bool isGameBegin;

        public hotSeatMenu(FormClosedEventHandler newGameFormClosedEvent, EventHandler newGameFormShownEvent)
        {
            gameFormClosedEvent = newGameFormClosedEvent;
            gameFormShownEvent = newGameFormShownEvent;
            InitializeComponent();
           // isGameBegin = false;
            player1ModeComboBox.SelectedIndex = 1;
            player2ModeComboBox.SelectedIndex = 1;
            player3ModeComboBox.SelectedIndex = 1;
            player4ModeComboBox.SelectedIndex = 1;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            int premissionToRun = 0;
            if (player1Name.Enabled) { ++premissionToRun; }
            if (player2Name.Enabled) { ++premissionToRun; }
            if (player3Name.Enabled) { ++premissionToRun; }
            if (player4Name.Enabled) { ++premissionToRun; }
            if (premissionToRun>1)
            {
                gameFormShownEvent(this, null);
                Player[] players = new Player[4];
                players[0] = new Player(1, player1Name.Text, player1Name.Enabled); 
                players[1] = new Player(2, player2Name.Text, player2Name.Enabled); 
                players[2] = new Player(3, player3Name.Text, player3Name.Enabled); 
                players[3] = new Player(4, player4Name.Text, player4Name.Enabled); 
                Form game = new hotSeatGame(players);
                game.FormClosed += new FormClosedEventHandler(gameFormClosedEvent);
                Hide();
                game.ShowDialog();
               // isGameBegin = true;
                Close();
            }
            else
            {
                MessageBox.Show("В игре должны принимать минимум два человека.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetPlayerMode(object sender, EventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            if (temp.SelectedIndex == 1)
            {
                switch (temp.Name)
                {
                    case "player1ModeComboBox": player1Name.Enabled = false; break;
                    case "player2ModeComboBox": player2Name.Enabled = false; break;
                    case "player3ModeComboBox": player3Name.Enabled = false; break;
                    case "player4ModeComboBox": player4Name.Enabled = false; break;
                }
            }
            else
            {
                switch (temp.Name)
                {
                    case "player1ModeComboBox": player1Name.Enabled = true; break;
                    case "player2ModeComboBox": player2Name.Enabled = true; break;
                    case "player3ModeComboBox": player3Name.Enabled = true; break;
                    case "player4ModeComboBox": player4Name.Enabled = true; break;
                }
            }
        }
    }
}
