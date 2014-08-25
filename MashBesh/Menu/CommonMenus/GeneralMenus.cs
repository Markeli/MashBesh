using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MashBesh
{
    public partial class GeneralMenu : Form
    {
        Settings configuration;
        AudioPlayer backGroundMusic;
        bool isPlayingGame;

        serverMultiPlayer serverFrom;
        mainClientMultiPlayerMenu mainClientForm;
        clientMultiPlayerMenu clientForm;
        bool mainClientFormIsOpened;
        bool clientFormIsOpened;
        bool serverIsOpened;
        StreamWriter log;

        public GeneralMenu()
        {
            InitializeComponent();
            isPlayingGame = false;
            serverIsOpened = false;
            clientFormIsOpened = false;
            mainClientFormIsOpened = false;
            configuration = new Settings();
            configuration.Load();
            LoadAudio();
            if ((backGroundMusic.IsOpen()) & (configuration.musicIn)) { backGroundMusic.Play(true); }
            try
            {
                log = new StreamWriter(@"Error repoting\application.log", true);
            }
            catch { }
        }

        private void LoadAudio()
        {
            try
            {
                backGroundMusic = new AudioPlayer();
                backGroundMusic.Open(configuration.mainMenuBackgroundMusicLocation);
                backGroundMusic.LeftVolume = backGroundMusic.LeftVolume / 100 * configuration.MusicVolume;
                backGroundMusic.MasterVolume = backGroundMusic.MasterVolume / 100 * configuration.MusicVolume;
                backGroundMusic.RightVolume = backGroundMusic.RightVolume / 100 * configuration.MusicVolume;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
            }
        }

        private void HotSeatGameButtonClick(object sender, EventArgs e)
        {
            hotSeatMenu hotSeatMenu = new hotSeatMenu(GameFormClosed, GameFormShownEvent);
            hotSeatMenu.FormClosed += new FormClosedEventHandler(MultiplayerFormClosed);
            Hide();
            hotSeatMenu.ShowDialog();
        }

        private void GameFormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            if (isPlayingGame)
            {
                Form temp = (Form)sender;
                temp.Close();
            }
            LoadAudio();
            if ((backGroundMusic.IsOpen()) & (configuration.musicIn))
            {
                backGroundMusic.Play(true);
            }
            isPlayingGame = false;
            if (serverIsOpened)
            {
                serverFrom.Close();
            }
        }

        private void GameFormShownEvent(object sender, EventArgs e)
        {
            isPlayingGame = true;
            if (backGroundMusic.IsOpen())
            {
                backGroundMusic.Close();
            }
            if (mainClientFormIsOpened)
            {
                Form game = new multiplayerClientGame(mainClientForm.clientSocket, mainClientForm.myPlayersNumber, mainClientForm.myPlayersName, mainClientForm.GetArrayOfPlayers());
                game.FormClosed += new FormClosedEventHandler(GameFormClosed);
                mainClientForm.Close();
                mainClientFormIsOpened = false;
                game.ShowDialog();
            }
            if (clientFormIsOpened)
            {
                Form game = new multiplayerClientGame(clientForm.clientSocket, clientForm.myPlayersNumber, clientForm.myPlayersName, clientForm.GetArrayOfPlayers());
                game.FormClosed += new FormClosedEventHandler(GameFormClosed);
                clientForm.premissionToClose = true;
                clientForm.Close();
                clientFormIsOpened = false;
                game.ShowDialog();
            }
        }

        private void MultiplayerFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isPlayingGame)
            {
                if (serverIsOpened) { serverFrom.Close(); }
                Show();
            }
        }

        private void MultiPlayerMenuButtonClick(object sender, EventArgs e)
        {
            multiplayerSwitchMode switchModeMenu = new multiplayerSwitchMode();
            switchModeMenu.FormClosed += new FormClosedEventHandler(MultiplayerFormClosed);
            Hide();
            switchModeMenu.clientStart += MultiPlayerClinetMenu;
            switchModeMenu.serverStart += MultiPlayerServerMenu;
            switchModeMenu.ShowDialog();
        }

        private void MultiPlayerClinetMenu(object sender, EventArgs ar)
        {
            multiplayerSwitchMode temp = (multiplayerSwitchMode)sender;
            string playersName = temp.playersName.Text;
            temp.FormClosed -= MultiplayerFormClosed;
            temp.Close();
            clientForm = new clientMultiPlayerMenu(playersName, GameFormClosed, GameFormShownEvent);
            clientForm.FormClosed += new FormClosedEventHandler(MultiplayerFormClosed);
            clientForm.Show();
            clientFormIsOpened = true;
        }

        private void MultiPlayerServerMenu(object sender, EventArgs ar)
        {
            multiplayerSwitchMode temp = (multiplayerSwitchMode)sender;
            string playersName = temp.playersName.Text;
            temp.FormClosed -= MultiplayerFormClosed;
            temp.Close();
            serverFrom = new serverMultiPlayer(GameFormClosed, GameFormShownEvent);
            //while we check
            //server.WindowState = FormWindowState.Minimized;
            serverIsOpened = true;
            serverFrom.Show();
            //server.Hide();
            mainClientForm = new mainClientMultiPlayerMenu(playersName, GameFormClosed, GameFormShownEvent);
            mainClientForm.FormClosed += new FormClosedEventHandler(MultiplayerFormClosed);
            mainClientForm.Show();
            mainClientForm.Hide();
            mainClientFormIsOpened = true;
        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {
            Form settingForm = new SettingsForm();
            Hide();
            settingForm.FormClosed += new FormClosedEventHandler(SettingFormClosed);
            settingForm.ShowDialog();
        }

        private void SettingFormClosed(object sender, FormClosedEventArgs e)
        {
            Form tempForm = (Form)sender;
            tempForm.Dispose();
            tempForm.Close();
            Show();
            configuration.Load();
            backGroundMusic.LeftVolume = backGroundMusic.LeftVolume / 100 * configuration.MusicVolume;
            backGroundMusic.MasterVolume = backGroundMusic.MasterVolume / 100 * configuration.MusicVolume;
            backGroundMusic.RightVolume = backGroundMusic.RightVolume / 100 * configuration.MusicVolume;
            if ((!configuration.musicIn) && (backGroundMusic.IsPlaying())) { backGroundMusic.Pause(); }
            if ((configuration.musicIn) && (!backGroundMusic.IsPlaying())) { backGroundMusic.Play(true); }

        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CreaterButton_Click(object sender, EventArgs e)
        {
            Creater creater = new Creater();
            creater.ShowDialog();
        }

        private void GeneralMenuFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                log.Close();
            }
            catch { }
        }
    }
}
