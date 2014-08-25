using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;

namespace MashBesh
{
    public partial class serverMultiPlayer : Form
    {
        FormClosedEventHandler gameFormClosedEvent;
        EventHandler gameFormShownEvent;

        string serverName;
        int serverNumber;

        byte[] receivedBytes;
        int countOfConnectedUsers;
        Socket serverSocket;
        ArrayList clientList;
        ServerBoard board;

        Random cubePoint;

        StreamWriter log;

        public serverMultiPlayer(FormClosedEventHandler newGameFormClosedEvent, EventHandler newGameFormShownEvent)
        {
            gameFormClosedEvent = newGameFormClosedEvent;
            gameFormShownEvent = newGameFormShownEvent;
            InitializeComponent();
            LoadGame();
            player1ModeComboBox.SelectedIndex = 1;
            player2ModeComboBox.SelectedIndex = 1;
            player3ModeComboBox.SelectedIndex = 1;
            player4ModeComboBox.SelectedIndex = 1;
            clientList = new ArrayList();
            countOfConnectedUsers = 0;
            serverName = "Server";
            serverNumber = 0;
            receivedBytes = new byte[1024];
            cubePoint = new Random();
            try
            {
                log = new StreamWriter(@"Error repoting\server.log",true);                
            }
            catch {}
        }

        private void LoadGame()
        {
            board = new ServerBoard(GetArrayOfPlayers());
            InitializeMap();
            InitializePlayersChips();
        }

        private Player[] GetArrayOfPlayers()
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

        private void InitializeMap()
        {
            for (int i = 0; i < board.map.Count; ++i)
            {
                Controls.Add(board.map[i]);
                board.map[i].BringToFront();
                board.map[i].Visible = false;
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

        private void ServerMultiPlayerMenuLoad(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 11000);
                serverSocket.ExclusiveAddressUse = false;
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(4);
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании сервера. Повторите попытку.\r\n", "Сервер", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                }
                catch { }
                gameFormClosedEvent(this, null);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);
                ++countOfConnectedUsers;
                if (countOfConnectedUsers < 4)
                {
                    serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
                }
                clientSocket.BeginReceive(receivedBytes, 0, receivedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
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

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);
                Data receivedData = new Data(receivedBytes);
                Data sendsData = new Data();
                byte[] sendsBytes;
                sendsData = receivedData;
                switch (receivedData.comand)
                {
                    case Comand.Login:
                        clientInfo clientInfo = new clientInfo();
                        clientInfo.socket = clientSocket;
                        clientInfo.name = receivedData.sendersName;
                        if (!clientList.Contains(clientInfo))
                        {
                            clientList.Add(clientInfo);
                            UpdatePlayersState(sendsData.sendersName, "0");
                            sendsData.message = sendsData.sendersName + " присоединился к игре";
                        }
                        break;
                    case Comand.Logout:
                        clientList.Remove(clientSocket);
                        countOfConnectedUsers--;
                        try
                        {
                            clientSocket.Shutdown(SocketShutdown.Both);
                            clientSocket.Close();
                        }
                        catch { }
                        sendsData.message = sendsData.sendersName + " покинул игру";
                        ClearOldPlayersMode(sendsData.sendersName);
                        board.players[sendsData.sendersNumber-1].isPlaying = false;
                        break;
                    case Comand.Message:
                        break;
                    case Comand.NextPlayersStep:
                        board.canSwitchPlayers = true;
                        board.isStepDone = true;
                        board.CurrentlyActivePlayer++;
                        sendsData.sendersName = board.players[board.CurrentlyActivePlayer].PlayersName;
                        sendsData.message = "Ход игрока " + sendsData.sendersName;
                        sendsData.sendersNumber = board.CurrentlyActivePlayer;
                        break;
                    case Comand.ChoosePlayer:
                        UpdatePlayersState(sendsData.sendersName, sendsData.message);
                        sendsData.comand = Comand.PlayersState;
                        sendsData.message = GetPlayersState();
                        break;
                    case Comand.PlayersState:
                        sendsData.message = GetPlayersState();
                        break;
                    case Comand.Play:
                        sendsData.comand = Comand.Play;
                        sendsData.sendersName = serverName;
                        sendsData.message = "Let's play!";
                        UpdatePlayersPropertis();
                        break;
                    case Comand.Ready:
                        sendsData.comand = Comand.NextPlayersStep;
                        sendsData.message = "Приятной игры!";
                        sendsData.sendersName = board.players[board.CurrentlyActivePlayer].PlayersName;
                        sendsData.sendersNumber = board.CurrentlyActivePlayer;
                        break;
                    case Comand.RollADice:
                        sendsData.message = GetDicePoints();
                        sendsData.sendersName = serverName;
                        sendsData.sendersNumber = serverNumber;
                        break;
                    case Comand.ShowPath:
                        sendsData.message = receivedData.message + "*" + GetRoute(Convert.ToInt32(receivedData.message));
                        break;
                    case Comand.Move:
                        sendsData.message = GetMoving(ref sendsData.comand, Convert.ToInt32(receivedData.message));
                        if ( (sendsData.comand == Comand.MoveAndNext) || (sendsData.comand == Comand.MoveAndKillAndNext))
                        {
                            sendsData.sendersNumber = board.CurrentlyActivePlayer;
                            sendsData.sendersName = board.players[board.CurrentlyActivePlayer].PlayersName;
                        }
                        break;
                    case Comand.Error:
                        sendsData.comand = Comand.Error;
                        sendsBytes = sendsData.ToBytes();
                        clientSocket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);
                        break;
                }
                if (sendsData.comand != Comand.Error)
                {
                    if (sendsData.comand == Comand.Login || sendsData.comand == Comand.Logout)
                    {
                        InputMessageText.AppendText("\r\n" + sendsData.message);
                    }
                    else
                    {
                        UpdateInputMessageText(sendsData.sendersNumber, sendsData.sendersName, sendsData.message);
                    }
                    sendsBytes = sendsData.ToBytes();
                    foreach (clientInfo client in clientList)
                    {
                        client.socket.BeginSend(sendsBytes, 0, sendsBytes.Length, SocketFlags.None, new AsyncCallback(OnSend), client.socket);
                    }
                    InputMessageText.ScrollToCaret();
                }
                else
                {
                    InputMessageText.AppendText("\r\nERROR: " + Convert.ToString((int)receivedData.comand) + " " + receivedData.sendersName + ": " + receivedData.message);
                }
                if (receivedData.comand != Comand.Logout)
                {
                    clientSocket.BeginReceive(receivedBytes, 0, receivedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                try
                {
                    try
                    {
                        log.WriteLine(DateTime.Now.ToString() + ": " + ex.ToString());
                    }
                    catch { }
                    Socket clientSocket = (Socket)ar.AsyncState;
                    clientSocket.BeginReceive(receivedBytes, 0, receivedBytes.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
                catch { }
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndSend(ar);
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

        private void UpdatePlayersState(string playersName, string choosenPosition)
        {
            ClearOldPlayersMode(playersName);
            int position = Convert.ToInt32(choosenPosition);
            switch (position)
            {
                case 0:
                    SetPlayerToChoosenCombobox(GetFreePlayersCombobox(), playersName);
                    break;
                case 1:
                    if (player1ModeComboBox.SelectedIndex == 1) { SetPlayerToChoosenCombobox(1, playersName); }
                    break;
                case 2:
                    if (player2ModeComboBox.SelectedIndex == 1) { SetPlayerToChoosenCombobox(2, playersName); }
                    break;
                case 3:
                    if (player3ModeComboBox.SelectedIndex == 1) { SetPlayerToChoosenCombobox(3, playersName); }
                    break;
                case 4:
                    if (player4ModeComboBox.SelectedIndex == 1) { SetPlayerToChoosenCombobox(4, playersName); }
                    break;
            }
        }

        private void ClearOldPlayersMode(string playersName)
        {
            if (playersName == player1Name.Text) { player1Name.Text = ""; player1ModeComboBox.SelectedIndex = 1; }
            if (playersName == player2Name.Text) { player2Name.Text = ""; player2ModeComboBox.SelectedIndex = 1; }
            if (playersName == player3Name.Text) { player3Name.Text = ""; player3ModeComboBox.SelectedIndex = 1; }
            if (playersName == player4Name.Text) { player4Name.Text = ""; player4ModeComboBox.SelectedIndex = 1; }

        }

        private int GetFreePlayersCombobox()
        {
            if (player1ModeComboBox.SelectedIndex == 1) { return 1; }
            if (player2ModeComboBox.SelectedIndex == 1) { return 2; }
            if (player3ModeComboBox.SelectedIndex == 1) { return 3; }
            if (player4ModeComboBox.SelectedIndex == 1) { return 4; }
            return 0;
        }

        private void SetPlayerToChoosenCombobox(int numberOfBox, string playersName)
        {
            switch (numberOfBox)
            {
                case 1:
                    player1ModeComboBox.SelectedIndex = 0;
                    player1Name.Text = playersName;
                    break;
                case 2:
                    player2ModeComboBox.SelectedIndex = 0;
                    player2Name.Text = playersName;
                    break;
                case 3:
                    player3ModeComboBox.SelectedIndex = 0;
                    player3Name.Text = playersName;
                    break;
                case 4:
                    player4ModeComboBox.SelectedIndex = 0;
                    player4Name.Text = playersName;
                    break;
            }
        }

        private string GetPlayersState()
        {
            return Convert.ToString(player1ModeComboBox.SelectedIndex) + "*" + player1Name.Text + "*" + Convert.ToString(player2ModeComboBox.SelectedIndex) + "*" + player2Name.Text + "*"
                + Convert.ToString(player3ModeComboBox.SelectedIndex) + "*" + player3Name.Text + "*" + Convert.ToString(player4ModeComboBox.SelectedIndex) + "*" + player4Name.Text + "*";
        }

        private void UpdatePlayersPropertis()
        {
            board.players = GetArrayOfPlayers();
            for (int i = 0; i < board.players.Length; ++i)
            {
                board.CurrentlyActivePlayer = i;
                if (board.players[i].isPlaying)
                {
                    break;
                }
            }
        }

        private string GetDicePoints()
        {
            if (board.isStepDone)
            {
                board.isStepDone = false;
                board.FirstDicePoints = cubePoint.Next(1, cubePoint.Next(1, 9));
                board.SecondDicePoints = cubePoint.Next(1, cubePoint.Next(1, 9));
                if ((!board.players[board.CurrentlyActivePlayer].IsChipsOnABoard()) & (board.SecondDicePoints != board.FirstDicePoints))
                {
                    return Convert.ToString(board.FirstDicePoints) + "*" + Convert.ToString(board.SecondDicePoints) + "*firstDice*can'tMoveChips";
                }
                else
                {
                    return Convert.ToString(board.FirstDicePoints) + "*" + Convert.ToString(board.SecondDicePoints) + "*firstDice*canMoveChips";
                }
            }
            else
            {
                return Convert.ToString(board.FirstDicePoints) + "*" + Convert.ToString(board.SecondDicePoints) + "*secondDice*canMoveChips";
            }
        }

        private string GetRoute(int chipsNumber)
        {
            int playersNumber = board.CurrentlyActivePlayer;
            board.players[playersNumber].ChoosenChipNumber = chipsNumber;
            board.map.SetDefaultColorToAllCells();
            string route = "noRoute";
            if (board.players[playersNumber].chip[chipsNumber].chip.Location != board.players[playersNumber].chip[chipsNumber].DefaultLocation)
            {
                route = board.GetChipsRoute(chipsNumber);
            }
            else
            {
                if (board.FirstDicePoints == board.SecondDicePoints)
                {
                    board.map[0].BackColor = Color.DarkGray;
                    route = "1";
                }
            }
            return route;
        }

        private string GetMoving(ref Comand sendsComand, int destinationCell)
        {
            board.isStepDone = false;
            int choosenChipNumber = board.players[board.CurrentlyActivePlayer].ChoosenChipNumber;
            Chip choosenChip = board.players[board.CurrentlyActivePlayer].chip[choosenChipNumber];
            int delta = destinationCell - choosenChip.CurrentCellIndex;
            if (delta == (board.SecondDicePoints + board.FirstDicePoints)) { board.CountOfLead = 2; }
            else
            {
                if (destinationCell == Player.chipsStartCellIndex)
                {
                    board.CountOfLead = 2;
                    board.SecondDicePoints = 0;
                    board.FirstDicePoints = 0;
                }
                else
                    if (delta == board.FirstDicePoints)
                    {
                        board.CountOfLead++;
                        board.FirstDicePoints = 0;
                    }
                    else
                        if (delta == board.SecondDicePoints)
                        {
                            board.CountOfLead++;
                            board.SecondDicePoints = 0;
                        }
                        else
                            if ((destinationCell == 6) || (destinationCell == 20) || (destinationCell == 34) || (destinationCell == 48))
                            {
                                board.CountOfLead++;
                                if (board.FirstDicePoints == 1) { board.FirstDicePoints = 0; }
                                else { board.SecondDicePoints = 0; }
                            }
                            else
                                if (destinationCell > 55)
                                {
                                    board.CountOfLead = 2;
                                    board.FirstDicePoints = 0;
                                    board.SecondDicePoints = 0;
                                }
            }
            for (int i = 0; i < board.map.Count; ++i)
            {
                if (destinationCell == board.map[i].TabIndex)
                {
                    choosenChip.ChangeLocation(destinationCell, board.map[i].Location);
                    break;
                }
            }
            if ((destinationCell == 12) || (destinationCell== 26) || (destinationCell == 40) || (destinationCell == 54))
            {
                for (int i = 0; i < board.map.Count; ++i)
                {
                    if (board.map[i].TabIndex == (destinationCell- 6))
                    {
                        destinationCell -= 6;
                        choosenChip.ChangeLocation(destinationCell, board.map[i].Location);
                        break;
                    }
                }
            }
            for (int i = 0; i < board.NumberOfPlayers; ++i)
            {
                for (int j = 0; j < Player.amountOfChips; ++j)
                {
                    if ((choosenChip.chip.Location == board.players[i].chip[j].chip.Location) & (choosenChip.chip.Name != board.players[i].chip[j].chip.Name))
                    {
                        board.players[i].chip[j].SetToDefaultLocation();
                        sendsComand = Comand.MoveAndKill;
                        break;
                    }
                }
            }
            if (board.CountOfLead > 1)
            {
                if (sendsComand == Comand.Move)
                {
                    sendsComand = Comand.MoveAndNext;
                }
                else
                {
                    sendsComand = Comand.MoveAndKillAndNext;
                }
                board.isStepDone = true;
                board.CurrentlyActivePlayer++;
            }
            return Convert.ToString(destinationCell) + "*" + Convert.ToString(board.FirstDicePoints) + "*" + Convert.ToString(board.SecondDicePoints);
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
                InputMessageText.AppendText("\r\n" + name + ": " + text);
            }
            else
            {
                InputMessageText.AppendText(name + ": " + text);
            }
            InputMessageText.Select(oldTextLength, name.Length + 2);
            InputMessageText.SelectionColor = selectionColor;
        }

        private void ServerMultiPlayerMenuFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Data sendsData = new Data();
                sendsData.comand = Comand.ServerOff;
                sendsData.sendersName = "Server";
                sendsData.message = "bb";
                byte[] sendsBytes = sendsData.ToBytes();
                foreach (clientInfo client in clientList)
                {
                    if (clientList.IndexOf(client) != 0) { client.socket.Send(sendsBytes, 0, sendsBytes.Length, SocketFlags.None); }
                }
                foreach (clientInfo client in clientList)
                {
                    client.socket.Close();
                }
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
                log.Close();
                gameFormClosedEvent(this, null);
            }
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

        private void CancelMultiplayerButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
