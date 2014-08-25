using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MashBesh
{
    public partial class clientMultiPlayerMenu : Form
    {
        FormClosedEventHandler gameFormClosedEvent;
        EventHandler gameFormShownEvent;
        public int myPlayersNumber;
        private string myCurrentPlayersModeComboBox;
        public string myPlayersName;

        public Socket clientSocket;
        private byte[] recievedBytes = new byte[1024];
        private Data reserveredDataCopy;
        
        private Form waitingForm;
        private bool closingWaitingForm = false;
        public  bool premissionToClose = false;
        private bool gameIsStart;

        private delegate void gameStartingDelegate();
        private gameStartingDelegate startTheGame;
        StreamWriter log;
        

        public clientMultiPlayerMenu(string myNewPlayersName, FormClosedEventHandler newGameFormClosedEvent, EventHandler newGameFormShownEvent)
        {
            InitializeComponent();
            myPlayersName = myNewPlayersName;
            Text = myPlayersName;
            gameFormClosedEvent = newGameFormClosedEvent;
            gameFormShownEvent = newGameFormShownEvent;
            player1ModeComboBox.SelectedIndex = 1;
            player2ModeComboBox.SelectedIndex = 1;
            player3ModeComboBox.SelectedIndex = 1;
            player4ModeComboBox.SelectedIndex = 1;
            startTheGame = new gameStartingDelegate(timeCountDown.Start);
            gameIsStart = false;
            try
            {
                log = new StreamWriter(@"Error repoting\client.log", true);
            }
            catch { }
        }

        private void ClientMultiPlayerMenuLoad(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.BeginConnect(endPoint, new AsyncCallback(OnConnect), null);
                waitingForm = new WaitingForm("Поиск созданных игр...");
                waitingForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подклчюиться к игре.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
                premissionToClose = true;
                Close();
            }            
        }

        private void OnConnect(IAsyncResult ar)
        {
            closingWaitingForm = true;
            try
            {
                clientSocket.EndConnect(ar);
                Data sendsData = new Data();
                sendsData.comand = Comand.Login;
                sendsData.sendersName = myPlayersName;
                sendsData.sendersNumber = 0;
                byte[] shipedBytes = sendsData.ToBytes();
                reserveredDataCopy = new Data();
                reserveredDataCopy = sendsData;
                clientSocket.BeginSend(shipedBytes, 0, shipedBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                clientSocket.BeginReceive(recievedBytes, 0, recievedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подклчюиться к игре.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
                premissionToClose = true;
                Close();
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);
                Data receivedData = new Data(recievedBytes);
                switch (receivedData.comand)
                {
                    case Comand.Login:
                        Data sendsData = new Data();
                        sendsData.comand = Comand.PlayersState;
                        byte[] sendsBytes = sendsData.ToBytes();
                        clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        break;
                    case Comand.Logout:
                        Data sendData = new Data();
                        sendData.comand = Comand.PlayersState;
                        byte[] sendBytes = sendData.ToBytes();
                        clientSocket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        break;
                    case Comand.Message:
                        break;
                    case Comand.ServerOff:
                        MessageBox.Show("Сервер прекратил свою работу.", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        premissionToClose = true;
                        Close();
                        break;
                    case Comand.PlayersState:
                        if (UpdatePlayersState(receivedData.message)) { break; }
                        else { receivedData.comand = Comand.Error; return; }
                    case Comand.Play:
                        BeginInvoke(startTheGame);
                        break;
                    case Comand.Error:
                        byte[] reserveredBytes = reserveredDataCopy.ToBytes();
                        clientSocket.BeginSend(reserveredBytes, 0, reserveredBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        break;
                }
                if (receivedData.comand != Comand.Error && receivedData.message != null && receivedData.comand != Comand.PlayersState)
                {
                    if (receivedData.comand == Comand.Login || receivedData.comand == Comand.Logout)
                    {
                        UpdateInputMessageText(0, "Server", receivedData.message);  
                    }
                    else
                    {
                        UpdateInputMessageText(receivedData.sendersNumber, receivedData.sendersName, receivedData.message);  
                    }
                    InputMessageText.ScrollToCaret();
                }
                recievedBytes = new byte[1024];
                clientSocket.BeginReceive(recievedBytes, 0, recievedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
            }

        }

        private bool UpdatePlayersState(string newState)
        {
            try
            {
                string[] state = newState.Split('*');
                player1Name.Text = state[1];
                player2Name.Text = state[3];
                player3Name.Text = state[5];
                player4Name.Text = state[7];
                player1ModeComboBox.SelectedIndex = Convert.ToInt32(state[0]);
                player2ModeComboBox.SelectedIndex = Convert.ToInt32(state[2]);
                player3ModeComboBox.SelectedIndex = Convert.ToInt32(state[4]);
                player4ModeComboBox.SelectedIndex = Convert.ToInt32(state[6]);
                if (myPlayersName == player1Name.Text) { myCurrentPlayersModeComboBox = player1ModeComboBox.Name; myPlayersNumber = 1; }
                if (myPlayersName == player2Name.Text) { myCurrentPlayersModeComboBox = player2ModeComboBox.Name; myPlayersNumber = 2; }
                if (myPlayersName == player3Name.Text) { myCurrentPlayersModeComboBox = player3ModeComboBox.Name; myPlayersNumber = 3; }
                if (myPlayersName == player4Name.Text) { myCurrentPlayersModeComboBox = player4ModeComboBox.Name; myPlayersNumber = 4; }
                if ((myPlayersName == player1Name.Text) || (player1ModeComboBox.SelectedIndex == 1)) { player1ModeComboBox.Enabled = true; } else { player1ModeComboBox.Enabled = false; }
                if ((myPlayersName == player2Name.Text) || (player2ModeComboBox.SelectedIndex == 1)) { player2ModeComboBox.Enabled = true; } else { player2ModeComboBox.Enabled = false; }
                if ((myPlayersName == player3Name.Text) || (player3ModeComboBox.SelectedIndex == 1)) { player3ModeComboBox.Enabled = true; } else { player3ModeComboBox.Enabled = false; }
                if ((myPlayersName == player4Name.Text) || (player4ModeComboBox.SelectedIndex == 1)) { player4ModeComboBox.Enabled = true; } else { player4ModeComboBox.Enabled = false; }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void UpdateInputMessageText(int senderPlayersNumber, string name, string text)
        {
            Color selectionColor = Color.Black;
            switch (senderPlayersNumber)
            {
                case 1: selectionColor = Color.OrangeRed; break;
                case 2: selectionColor = Color.LightGreen; break;
                case 3: selectionColor = Color.LightBlue; break;
                case 4: selectionColor = Color.MediumPurple; break;
            }
            int oldTextLength = InputMessageText.TextLength;
            if (InputMessageText.TextLength != 0)
            {
                if (name != "Server") { InputMessageText.AppendText("\r\n" + name + ": " + text); }
                else { InputMessageText.AppendText("\r\n" + text); }
            }
            else
            {
                InputMessageText.AppendText(text);
            }
            InputMessageText.Select(oldTextLength, name.Length + 2);
            InputMessageText.SelectionColor = selectionColor;
        }
        
        private void SendTextMessageClick(object sender, EventArgs e)
        {
            if (OutputMessageText.TextLength != 0)
            {
                try
                {
                    Data sendsData = new Data();
                    sendsData.comand = Comand.Message;
                    sendsData.message = OutputMessageText.Text;
                    sendsData.sendersName = myPlayersName;
                    sendsData.sendersNumber = myPlayersNumber;
                    byte[] sendsBytes = sendsData.ToBytes();
                    reserveredDataCopy = sendsData;
                    clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                    OutputMessageText.Clear();
                }
                catch (Exception ex)
                {
                    try
                    {
                        log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                    }
                    catch { }
                }
            }
        }

        private void OutputMessageTextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendTextMessageClick(sender, null);
            }
        }  
        
        private void SetPlayerMode(object sender, EventArgs e)
        {
            ComboBox checkedComboBox = (ComboBox)sender;
            if (checkedComboBox.SelectedIndex == 1)
            {
                SetNotActiveModeToCheckedComboBox(checkedComboBox);
            }
            else
            {
                SetActiveModeToCheckedComboBox(checkedComboBox);
            }
        }

        private void SetNotActiveModeToCheckedComboBox(ComboBox checkedCombobox)
        {
            Data sendsData = new Data();
            sendsData.comand = Comand.ChoosePlayer;
            sendsData.sendersName = myPlayersName;
            sendsData.sendersNumber = myPlayersNumber;
            sendsData.message = "0";
            reserveredDataCopy = sendsData;
            byte[] sendsBytes = sendsData.ToBytes();
            try
            {
                clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            {
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
            }
        }

        private void SetActiveModeToCheckedComboBox(ComboBox checkedComboBox)
        {
            Data sendsData = new Data();
            sendsData.comand = Comand.ChoosePlayer;
            sendsData.sendersName = myPlayersName;
            sendsData.sendersNumber = myPlayersNumber;
            switch (checkedComboBox.Name)
            {
                case "player1ModeComboBox":
                    sendsData.message = "1"; 
                    break;
                case "player2ModeComboBox":
                    sendsData.message = "2";
                    break;
                case "player3ModeComboBox":
                    sendsData.message = "3";
                    break;
                case "player4ModeComboBox":
                    sendsData.message = "4";
                    break;
            }
            reserveredDataCopy = sendsData;
            byte[] sendsBytes = sendsData.ToBytes();
            try
            {
                clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch (Exception ex)
            {
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
            }
        }

        private void CancelMultiplayerButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TimeCountDownTick(object sender, EventArgs e)
        {
            cancelMultiplayerButton.Enabled = false;
            player1ModeComboBox.Enabled = false;
            player2ModeComboBox.Enabled = false;
            player3ModeComboBox.Enabled = false;
            player4ModeComboBox.Enabled = false;
            if (Convert.ToString(timeCountDown.Tag) == "5")
            {
                InputMessageText.AppendText("\r\nИгра начнется через " + Convert.ToString(timeCountDown.Tag));
            }
            else
            {
                InputMessageText.AppendText("\r\n..." + Convert.ToString(timeCountDown.Tag));
            }
            if (Convert.ToInt32(timeCountDown.Tag) == 1)
            {
                timeCountDown.Stop();
                gameIsStart = true;
                gameFormShownEvent(this, null);  
             }
            timeCountDown.Tag = (Convert.ToInt32(timeCountDown.Tag) - 1);
        }
        
        public Player[] GetArrayOfPlayers()
        {
            bool player1IsPlaying = false;
            bool player2IsPlaying = false;
            bool player3IsPlaying = false;
            bool player4IsPlaying = false;
            if (player1ModeComboBox.SelectedIndex == 0) { player1IsPlaying = true; }
            if (player2ModeComboBox.SelectedIndex == 0) { player2IsPlaying = true; }
            if (player3ModeComboBox.SelectedIndex == 0) { player3IsPlaying = true; }
            if (player4ModeComboBox.SelectedIndex == 0) { player4IsPlaying = true; }
            Player[] players = new Player[4];
            players[0] = new Player(1, player1Name.Text, player1IsPlaying);
            players[1] = new Player(2, player2Name.Text, player2IsPlaying);
            players[2] = new Player(3, player3Name.Text, player3IsPlaying);
            players[3] = new Player(4, player4Name.Text, player4IsPlaying);
            return players;
        }        
        
        private void ClientMultiPlayerMenuFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!gameIsStart)
            {
                if (!premissionToClose)
                {
                    if (MessageBox.Show("Вы уверены, что хотите покинуть игру?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                try
                {
                    Data sendsData = new Data();
                    sendsData.comand = Comand.Logout;
                    sendsData.message = null;
                    sendsData.sendersName = myPlayersName;
                    sendsData.sendersNumber = myPlayersNumber;
                    byte[] shipedBytes = sendsData.ToBytes();
                    clientSocket.Send(shipedBytes, 0, shipedBytes.Length, SocketFlags.None);
                    clientSocket.Close();
                    log.Close();
                }
                catch (ObjectDisposedException) { }
                catch (Exception ex)
                {
                    try
                    {
                        log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                        log.Close();
                    }
                    catch { }
                }
            }
        }

        private void FirstConnectionWaitingTimerTick(object sender, EventArgs e)
        {
            if (closingWaitingForm)
            {
                closingWaitingForm = false;
                waitingForm.Close();
            }
        }  
    }
}
