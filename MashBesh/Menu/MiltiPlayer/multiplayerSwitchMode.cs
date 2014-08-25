using System;
using System.Windows.Forms;

namespace MashBesh
{
    public partial class multiplayerSwitchMode : Form
    {
        public EventHandler clientStart, serverStart;
     
        public multiplayerSwitchMode()
        {
            InitializeComponent();
        }

        private void serverStartButton_Click(object sender, EventArgs e)
        {
            if (playersName.Text != "")
            {
                serverStart(this, null);
            }
            else
            {
                MessageBox.Show("Необходимо ввести имя игрока. Максимальная длина 15 символов.");
            }
        }

        private void clientStartButton_Click(object sender, EventArgs e)
        {
            if (playersName.Text != "")
            {
                try
                {
                    clientStart(this, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Сетевая игра.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Необходимо ввести имя игрока. Максимальная длина 15 символов.");
            }
        }

        private void closingButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
