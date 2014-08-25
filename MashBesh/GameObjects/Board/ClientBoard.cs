using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MashBesh
{
    class ClientBoard
    {
        public bool isStepDone = true;
        public bool canSwitchPlayers = true;
        public bool canPassAMove;
        int firstDicePoints, secondDicePoints;
        public int FirstDicePoints
        {
            get { return firstDicePoints; }
            set
            {
                if ((value >= 0) & (value < 7))
                { firstDicePoints = value; }
                else { firstDicePoints = 4; }
            }
        }
        public int SecondDicePoints
        {
            get { return secondDicePoints; }
            set
            {
                if ((value >= 0) & (value < 7))
                { secondDicePoints = value; }
                else { secondDicePoints = 4; }
            }
        }
        int numberOfPlayers = defaultPlayersCount;
        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set
            {
                if (value > 0)
                { numberOfPlayers = value; }
                else
                {
                    numberOfPlayers = defaultPlayersCount;
                }
            }
        }
        int currentlyActivePlayer = 0;
        public int CurrentlyActivePlayer
        {
            get { return currentlyActivePlayer; }
            set
            {
                if (value >= numberOfPlayers)
                {
                    currentlyActivePlayer = 0;
                    countOfLead = 0;
                }
                else
                {
                    currentlyActivePlayer = value;
                    countOfLead = 0;
                }
                if (!players[currentlyActivePlayer].isPlaying)
                {
                    CurrentlyActivePlayer++;
                }
                map.ReIndexCells(CurrentlyActivePlayer);
            }
        }
        public Player[] players;
        byte countOfLead = 0;
        public byte CountOfLead
        {
            get { return countOfLead; }
            set
            {
                countOfLead = value;
            }
        }
        const int defaultPlayersCount = 4;
        public string[] winners = new string[3];
        int currentWinnersPlace = 0;
        public int CurrentWinnersPlace
        {
            get { return currentWinnersPlace; }
            set
            {
                if (value > 0) { currentWinnersPlace = value; }
                else { currentWinnersPlace = 1; }
            }
        }
        public event EventHandler OnChipsMoved;
        public event EventHandler OnChipClickEvent;
        public EventHandler OnCellClickEvent;
        public MultiplayerGameMap map;
        

        public ClientBoard(Player[] newPlayers)
        {
            players = newPlayers;
            NumberOfPlayers = players.Length;
            for (int i = 0; i < NumberOfPlayers; ++i)
            {
                for (int j = 0; j < Player.amountOfChips; ++j)
                {
                    players[i].chip[j].chipClickEvent += new EventHandler(OnChipClick);
                }
            }
            map = new MultiplayerGameMap();
            map.cellClickEvent += OnCellClick;
        }
        
        public void OnCellClick(object sender, EventArgs e)
        {
            OnCellClickEvent(sender, e);
        }

        public void ActivateCurrentPlayersChips()
        {
            for (int i = 0; i < 3; ++i)
            {
                players[CurrentlyActivePlayer].chip[i].enabled = true;
            }
        }

        public void DeactivateAllPlayersChips()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    players[i].chip[j].enabled = false;
                }
            }
        }

        public void OnChipClick(object sender, EventArgs e)
        {
            OnChipClickEvent(sender, e);
        }

        private int FindChipsStartCellIndex()
        {
            int startCellIndex = 1;
            for (int i = 0; i < map.Count; ++i)
            {
                if (map[i].TabIndex == 1) { startCellIndex = i; }
            }
            return startCellIndex;
        }

        public void ShowChipsRoute(string newRoute)
        {
            map.SetDefaultColorToAllCells();
            string[] route = newRoute.Split('*');
            players[currentlyActivePlayer].ChoosenChipNumber = Convert.ToInt32(route[0]);
            for (int i = 1; i < route.Length; ++i)
            {
                if (route[i] != "noRoute")
                {
                    MarkOutDestinationCell(Convert.ToInt32(route[i]));
                }
            }
        }
        
        private void MarkOutDestinationCell(int destinationCellNumber)
        {
            for (int i = 0; i < map.Count; ++i)
            {
                if (map[i].TabIndex == destinationCellNumber)
                {
                    map[i].BackColor = Color.DarkGray;
                    break;
                }
            }
        }

        public void AddCurrentPlayerToWinnersList()
        {
            winners[currentWinnersPlace] = players[CurrentlyActivePlayer].PlayersName;
            currentWinnersPlace++;
            players[CurrentlyActivePlayer].isPlaying = false;
        }

        public bool IsAllCurrentPlayerChipsOnFinish()
        {
            return players[currentlyActivePlayer].IsAllChipsOnFinish();
        }
    }
}
