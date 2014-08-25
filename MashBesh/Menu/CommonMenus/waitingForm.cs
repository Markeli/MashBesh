using System;
using System.Windows.Forms;

namespace MashBesh
{
    public partial class WaitingForm : Form
    {
        public WaitingForm(string newConectionStatus)
        {
            InitializeComponent();
            conectionStatus.Text = newConectionStatus;
        }

        private void waitingTimer_Tick(object sender, EventArgs e)
        {
            if (waitingLabel.Text.Length > 15) { waitingLabel.Text = ""; }
            else { waitingLabel.Text += "•"; }
        }

    }
}
