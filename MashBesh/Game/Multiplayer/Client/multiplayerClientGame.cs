using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Media;
using System.IO;

namespace MashBesh
{
    public partial class multiplayerClientGame : Form
    {
        int elapsedTime = 0;
        ClientBoard board;
        AudioPlayer backGroundMusic;
        SoundPlayer rollADieSound;
        SoundPlayer soundMove;
        Settings configuration;
        int myPlayersNumber;
        string myPlayersName;

        Socket clientSocket;
        Data reserveredDataCopy;
        byte[] recievedBytes = new byte[1024];
        StreamWriter log;

        public multiplayerClientGame(Socket newClientSocket, int myNewPlayersNumber, string myNewPlayersName, Player[] newPlayers)
        {
            InitializeComponent();
            configuration = new Settings();
            configuration.Load();
            LoadAudio();
            myPlayersNumber = myNewPlayersNumber;
            Text = myNewPlayersName;
            myPlayersName = myNewPlayersName;
            clientSocket = newClientSocket; 
            board = new ClientBoard(newPlayers);
            InitializeMap();
            InitializePlayersChips();
            board.DeactivateAllPlayersChips();
            currentlyActivePlayerLabel.Text = board.players[0].PlayersName;
            board.OnChipsMoved += new EventHandler(OnChipsMovedSound);
            board.OnChipClickEvent += new EventHandler(OnChipsClick);
            board.OnCellClickEvent += new EventHandler(OnCellClick);
            if ((backGroundMusic.IsOpen()) & (configuration.musicIn)) { backGroundMusic.Play(true);  }
            try
            {
                log = new StreamWriter(@"Error repoting\client.log", true);
            }
            catch { }

        }

        private void InitializeMap()
        {
            for (int i = 0; i < board.map.Count; ++i)
            {
                Controls.Add(board.map[i]);
                board.map[i].BringToFront();
            }
        }

        private void InitializePlayersChips()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < Player.amountOfChips; ++j)
                {
                    Controls.Add(board.players[i].chip[j].chip);
                    board.players[i].chip[j].chip.BringToFront();
                }
            }
        }

        private void LoadAudio()
        {
            try
            {
                soundMove = new System.Media.SoundPlayer();
                soundMove.SoundLocation = configuration.soundMoveLocation;
                soundMove.Load();
                rollADieSound = new System.Media.SoundPlayer();
                rollADieSound.SoundLocation = configuration.rollADieSoundLocation;
                rollADieSound.Load();
                backGroundMusic = new AudioPlayer();
                backGroundMusic.Open(configuration.backGroundMusicLocation);
                backGroundMusic.LeftVolume = backGroundMusic.LeftVolume / 100 * configuration.MusicVolume;
                backGroundMusic.MasterVolume = backGroundMusic.MasterVolume / 100 * configuration.MusicVolume;
                backGroundMusic.RightVolume = backGroundMusic.RightVolume / 100 * configuration.MusicVolume;
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

        private void OnChipsMovedSound(object sendedr, EventArgs e)
        {
            if ((soundMove.IsLoadCompleted) & (configuration.soundIn)) { soundMove.Play(); }
        }

        private void OnChipsClick(object sender, EventArgs e)
        {
            Chip clickedChip = (Chip)sender;
            if ((clickedChip.enabled) & (board.CurrentlyActivePlayer == myPlayersNumber - 1))
            {
                board.players[board.CurrentlyActivePlayer].ChoosenChipNumber = clickedChip.ChipNumber;
                try
                {
                    Data sendsData = new Data();
                    sendsData.comand = Comand.ShowPath;
                    sendsData.sendersNumber = myPlayersNumber;
                    sendsData.sendersName = myPlayersName;
                    sendsData.message = Convert.ToString(clickedChip.ChipNumber);
                    reserveredDataCopy = sendsData;
                    byte[] sendsBytes = sendsData.ToBytes();
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
            else
            {
                for (int i = 0; i < board.map.Count; ++i)
                {
                    if ((board.map[i].Location == clickedChip.chip.Location) & (board.map[i].BackColor == Color.DarkGray) & (board.CurrentlyActivePlayer == myPlayersNumber - 1))
                    {
                        try
                        {
                            Data sendsData = new Data();
                            sendsData.comand = Comand.Move;
                            sendsData.sendersNumber = myPlayersNumber;
                            sendsData.sendersName = myPlayersName;
                            sendsData.message = Convert.ToString(board.map[i].TabIndex);
                            reserveredDataCopy = sendsData;
                            byte[] sendsBytes = sendsData.ToBytes();
                            clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                            break;
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
            }
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            Button clickedCell = (Button)sender;
            if ((clickedCell.BackColor == Color.DarkGray) & (board.CurrentlyActivePlayer == myPlayersNumber - 1))
            {
                try
                {
                    Data sendsData = new Data();
                    sendsData.comand = Comand.Move;
                    sendsData.sendersNumber = myPlayersNumber;
                    sendsData.sendersName = myPlayersName;
                    sendsData.message = Convert.ToString(clickedCell.TabIndex);
                    reserveredDataCopy = sendsData;
                    byte[] sendsBytes = sendsData.ToBytes();
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
        }

        private void multiplayerClientGameLoad(object sender, EventArgs e)
        {
            try
            {
                Data sendsData = new Data();
                sendsData.comand = Comand.Ready;
                sendsData.message = null;
                sendsData.sendersName = myPlayersName;
                sendsData.sendersNumber = myPlayersNumber;
                byte[] sendsBytes = sendsData.ToBytes();
                clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                clientSocket.BeginReceive(recievedBytes, 0, recievedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                passAMoveButton.Enabled = false;
                rollADieButton.Enabled = false;
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
                recievedBytes = new byte[1024];
                clientSocket.BeginReceive(recievedBytes, 0, recievedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                switch (receivedData.comand)
                {
                    case Comand.Login:
                        Data sendsData = new Data();
                        sendsData.comand = Comand.PlayersState;
                        byte[] sendsBytes = sendsData.ToBytes();
                        clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        break;
                    case Comand.Logout:
                        break;
                    case Comand.Message:
                        break;
                    case Comand.NextPlayersStep:
                        board.CurrentlyActivePlayer = receivedData.sendersNumber;
                        OnChangeCurrentlyActivePlayer();
                        break;
                    case Comand.RollADice:
                        UpdateRollADie(receivedData.message);
                        break;
                    case Comand.ServerOff:
                        MessageBox.Show("Сервер прекратил свою работу.", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //premissionToClose = true;
                        Close();
                        break;
                    case Comand.ShowPath:
                        board.ShowChipsRoute(receivedData.message);
                        break;
                    case Comand.Move:
                        MoveChip(receivedData.message);
                        break;
                    case Comand.MoveAndNext:
                        MoveChip(receivedData.message);
                        board.CurrentlyActivePlayer = receivedData.sendersNumber;
                        OnChangeCurrentlyActivePlayer();
                        break;
                    case Comand.MoveAndKill:
                        MoveChip(receivedData.message);
                        KillEnemyChip();
                        break;
                    case Comand.MoveAndKillAndNext:
                        MoveChip(receivedData.message);
                        KillEnemyChip();       
                        board.CurrentlyActivePlayer = receivedData.sendersNumber;
                        OnChangeCurrentlyActivePlayer();
                        break;
                    case Comand.Error:
                        byte[] reserveredBytes = reserveredDataCopy.ToBytes();
                        clientSocket.BeginSend(reserveredBytes, 0, reserveredBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                        break;
                }
                if (receivedData.comand != Comand.Error && receivedData.message != null && receivedData.comand != Comand.PlayersState && receivedData.comand != Comand.RollADice
                    && receivedData.comand != Comand.ShowPath &&  receivedData.comand != Comand.Move)
                {
                    if (receivedData.comand == Comand.Login || receivedData.comand == Comand.Logout || receivedData.comand == Comand.NextPlayersStep )
                    {
                        UpdateInputMessageText(0, "Server", receivedData.message);
                    }
                    else
                        if ( (receivedData.comand == Comand.MoveAndNext) || (receivedData.comand == Comand.MoveAndKillAndNext))
                        {
                            UpdateInputMessageText(0, "Server", "Ход игрока "+receivedData.sendersName); 
                        }
                        else
                        {
                            UpdateInputMessageText(receivedData.sendersNumber, receivedData.sendersName, receivedData.message);
                        }
                    InputMessageText.ScrollToCaret();
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                try
                {
                    try
                    {
                        log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                    }
                    catch { }
                    clientSocket.BeginReceive(recievedBytes, 0, recievedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                }
                catch { }
            }
        }

        private void OnChangeCurrentlyActivePlayer()
        {
            board.DeactivateAllPlayersChips();
            if (board.CurrentlyActivePlayer == myPlayersNumber - 1)
            {
                passAMoveButton.Enabled = true;
                rollADieButton.Enabled = true;
                board.ActivateCurrentPlayersChips();
            }
            else
            {
                passAMoveButton.Enabled = false;
                rollADieButton.Enabled = false;
            }
            board.map.SetDefaultColorToAllCells();
            currentlyActivePlayerLabel.Text = board.players[board.CurrentlyActivePlayer].PlayersName;
            button2.Image = board.players[board.CurrentlyActivePlayer].chip[1].chip.Image;
            fisrtDicePointsLabel.Text = "X";
            secondDicePointsLabel.Text = "X";
        }

        private void KillEnemyChip()
        {
            int choosenChipNumber = board.players[board.CurrentlyActivePlayer].ChoosenChipNumber;
            Chip choosenChip = board.players[board.CurrentlyActivePlayer].chip[choosenChipNumber];
            for (int i = 0; i < board.NumberOfPlayers; ++i)
            {
                for (int j = 0; j < Player.amountOfChips; ++j)
                {
                    if ((choosenChip.chip.Location == board.players[i].chip[j].chip.Location) & (choosenChip.chip.Name != board.players[i].chip[j].chip.Name))
                    {
                        board.players[i].chip[j].SetToDefaultLocation();
                        break;
                    }
                }
            }
        }

        private void UpdateRollADie(string points)
        {
            string[] temp = points.Split('*');
            board.FirstDicePoints = Convert.ToInt32(temp[0]);
            board.SecondDicePoints = Convert.ToInt32(temp[1]);
            if (temp[3] == "canMoveChips")
            {
                if (temp[2] == "firstDice")
                {
                    if ((rollADieSound.IsLoadCompleted) & (configuration.soundIn)) { rollADieSound.PlaySync(); }
                    fisrtDicePointsLabel.Text = "";
                    secondDicePointsLabel.Text = "";
                    SetImageToDice(board.FirstDicePoints, board.SecondDicePoints);
                }
                else
                {
                    if (board.CurrentlyActivePlayer == myPlayersNumber - 1)
                    {
                        UpdateInputMessageText(0,"server","Вы уже бросили кубик.");
                    }
                }
            }
            else
            {
                if (temp[2] == "firstDice")
                {
                    if ((rollADieSound.IsLoadCompleted) & (configuration.soundIn)) { rollADieSound.PlaySync(); }
                    fisrtDicePointsLabel.Text = "";
                    secondDicePointsLabel.Text = "";
                    SetImageToDice(board.FirstDicePoints, board.SecondDicePoints);
                }
                if (board.CurrentlyActivePlayer == myPlayersNumber - 1)
                {
                    UpdateInputMessageText(0, "server", "Вы не можете сделать ход. Ходит следующий игрок.");
                    PassAMoveButtonClick(this, null);
                }
            }
        }

        private void MoveChip(string newMovingParametrs)
        {
            string[] movingParametrs = newMovingParametrs.Split('*');
            int choosenChipNumber = board.players[board.CurrentlyActivePlayer].ChoosenChipNumber;
            Chip choosenChip = board.players[board.CurrentlyActivePlayer].chip[choosenChipNumber];
            int destinationCell = Convert.ToInt32(movingParametrs[0]);
            for (int i = 0; i < board.map.Count; ++i)
            {
                if (destinationCell == board.map[i].TabIndex)
                {
                    choosenChip.ChangeLocation(destinationCell, board.map[i].Location);
                    break;
                }
            }
            if (movingParametrs[1] == "0") 
            { 
                fisrtDicePointsLabel.Text = "X";
                board.FirstDicePoints = 0;
            }
            if (movingParametrs[2] == "0")
            {
                secondDicePointsLabel.Text = "X";
                board.SecondDicePoints = 0;
            }
            if (destinationCell > 40)
            {
                passAMoveButton.Enabled = true;
            }
            else
            {
                passAMoveButton.Enabled = false;
            }
            OnChipsMovedSound(this, null);
            board.map.SetDefaultColorToAllCells();
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
      
        private void RollADieButtonClick(object sender, EventArgs e)
        {
            try
            {
                Data sendsData = new Data();
                sendsData.comand = Comand.RollADice;
                sendsData.sendersName = myPlayersName;
                sendsData.sendersNumber = myPlayersNumber;
                byte[] sendsBytes = sendsData.ToBytes();
                reserveredDataCopy = sendsData;
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

        private void SetImageToDice(int firstDicePoint, int secondDicePoints)
        {
            switch (firstDicePoint)
            {
                case 1: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._1Points; break;
                case 2: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._2Points; break;
                case 3: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._3Points; break;
                case 4: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._4Points; break;
                case 5: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._5Points; break;
                case 6: fisrtDicePointsLabel.Image = global::MashBesh.Properties.Resources._6Points; break;
            }
            switch (secondDicePoints)
            {
                case 1: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._1Points; break;
                case 2: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._2Points; break;
                case 3: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._3Points; break;
                case 4: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._4Points; break;
                case 5: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._5Points; break;
                case 6: secondDicePointsLabel.Image = global::MashBesh.Properties.Resources._6Points; break;
            }
        }

        private void PassAMoveButtonClick(object sender, EventArgs e)
        {
            try
            {
                Data sendsData = new Data();
                sendsData.comand = Comand.NextPlayersStep;
                sendsData.message = null;
                sendsData.sendersName = myPlayersName;
                sendsData.sendersNumber = myPlayersNumber;
                byte[] sendsBytes = sendsData.ToBytes();
                reserveredDataCopy = sendsData;
                clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch { }
        }

        private void CheckEventsTimerTick(object sender, EventArgs e)
        {
            if ((board.players[board.CurrentlyActivePlayer].isPlaying) && board.IsAllCurrentPlayerChipsOnFinish())
            {
                board.AddCurrentPlayerToWinnersList();
                if (board.CurrentWinnersPlace == 3)
                {
                    board.canSwitchPlayers = false;
                    eventTimer.Enabled = false;
                    elapsedTimeTimer.Enabled = false;
                    rollADieButton.Enabled = false;
                    passAMoveButton.Enabled = false;
                    string message = "Игрок " + board.players[board.CurrentlyActivePlayer + 1].PlayersName + " проиграл.";
                    MessageBox.Show(message);

                }
                else
                {
                    string message = Convert.ToString(board.CurrentWinnersPlace) + " место занимает игрок " + board.players[board.CurrentlyActivePlayer].PlayersName;
                    MessageBox.Show(message);
                    board.canSwitchPlayers = true;
                }
            }
            if (board.canSwitchPlayers)
            {
                board.CurrentlyActivePlayer++;

                if (!board.players[board.CurrentlyActivePlayer].isPlaying) { board.canSwitchPlayers = true; }
            }
            if (board.FirstDicePoints == 0) { fisrtDicePointsLabel.Text = "X"; }
            if (board.SecondDicePoints == 0) { secondDicePointsLabel.Text = "X"; }
            if (board.canPassAMove) { passAMoveButton.Enabled = true; }
            else
                if (board.players[board.CurrentlyActivePlayer].chip[board.players[board.CurrentlyActivePlayer].ChoosenChipNumber].CurrentCellIndex < 40) { passAMoveButton.Enabled = false; }
        }

        private void ElapsedTimeTimerTick(object sender, EventArgs e)
        {
            ++elapsedTime;
            if (elapsedTime / 60 == 0) { elapsedTimeLabel.Text = Convert.ToString(elapsedTime) + " сек"; }
            else { elapsedTimeLabel.Text = Convert.ToString(elapsedTime / 60) + " мин " + Convert.ToString(elapsedTime % 60) + " сек"; }
        }

        private void MashbeshFormClosing(object sender, FormClosingEventArgs e)
        {
            if (backGroundMusic.IsOpen()) { backGroundMusic.Close(); }
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
}
