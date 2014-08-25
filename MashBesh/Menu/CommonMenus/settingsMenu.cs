using System;
using System.Windows.Forms;

namespace MashBesh
{
    public partial class SettingsForm : Form
    {
        Settings configarution;
        public SettingsForm()
        {
            configarution = new Settings();
            InitializeComponent();
            configarution.Load();
            musicCheckBox.Checked = configarution.musicIn;
            soundCheckBox.Checked = configarution.soundIn;
            musicVolumeTrackBar.Value = configarution.MusicVolume;
            saveSettingsButton_Click(this, null);
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (musicCheckBox.Checked) { configarution.musicIn = true; } else { configarution.musicIn = false; }
            if (soundCheckBox.Checked) { configarution.soundIn = true; } else { configarution.soundIn = false; }
            configarution.MusicVolume = musicVolumeTrackBar.Value;
            configarution.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            musicCheckBox.Checked = configarution.musicIn;
            soundCheckBox.Checked = configarution.soundIn;
            musicVolumeTrackBar.Value = configarution.MusicVolume;
        }

    }
}
