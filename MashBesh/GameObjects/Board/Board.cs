using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MashBesh
{
    class Board
    {
        public bool isStepDone = true;
        public bool isFirstStep = true;
        public bool canSwitchPlayers = true;
        public bool canPassAMove;
        int firstDicePoints = 5, secondDicePoint = 6;
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
            get { return secondDicePoint; }
            set
            {
                if ((value >= 0) & (value < 7))
                { secondDicePoint = value; }
                else { secondDicePoint = 4; }
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
                if (!isFirstStep)
                {
                    if (!players[currentlyActivePlayer].isPlaying)
                    {
                        CurrentlyActivePlayer++;
                    }
                    map.ReIndexCells();
                }
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
        public event EventHandler chipIsMoved;
        public HotSeatGameMap map;

        public Board(Player[] newPlayers)
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
            map = new HotSeatGameMap();
            map.cellClickEvent += OnCellClick;

        }
        
        public void OnCellClick(object sender, EventArgs e)
        {
            Button clickedCell = (Button)sender;
            if (clickedCell.BackColor == Color.DarkGray)
            {
                isStepDone = false;
                int choosenChipNumber = players[CurrentlyActivePlayer].ChoosenChipNumber;
                Chip choosenChip = players[CurrentlyActivePlayer].chip[choosenChipNumber];
                int delta = clickedCell.TabIndex - choosenChip.CurrentCellIndex;
                if (delta == (SecondDicePoints + FirstDicePoints)) 
                { 
                    CountOfLead = 2;
                }
                else
                {
                    if (clickedCell.TabIndex == Player.chipsStartCellIndex) 
                    { 
                        CountOfLead = 2; 
                    }
                    else
                        if (delta == FirstDicePoints) 
                        { 
                            CountOfLead++; 
                            FirstDicePoints = 0; 
                        }
                        else
                            if (delta == SecondDicePoints) 
                            { 
                                CountOfLead++; 
                                SecondDicePoints = 0;
                            }
                            else
                                if ((clickedCell.TabIndex == 6) || (clickedCell.TabIndex == 20) || (clickedCell.TabIndex == 34) || (clickedCell.TabIndex == 48))
                                {
                                    CountOfLead++;
                                    if (FirstDicePoints == 1) { FirstDicePoints = 0; }
                                    else { SecondDicePoints = 0; }
                                }
                                else
                                    if (clickedCell.TabIndex > 55)
                                    { 
                                        CountOfLead = 2; 
                                        FirstDicePoints = 0; 
                                        SecondDicePoints = 0; 
                                    }
                }
                choosenChip.ChangeLocation(clickedCell.TabIndex, clickedCell.Location);
                if ((clickedCell.TabIndex == 12) || (clickedCell.TabIndex == 26) || (clickedCell.TabIndex == 40) || (clickedCell.TabIndex == 54))
                {
                    System.Threading.Thread.Sleep(100);
                    for (int i = 0; i < map.Count; ++i)
                    {
                        if (map[i].TabIndex == (clickedCell.TabIndex - 6))
                        {
                            choosenChip.ChangeLocation(map[i].TabIndex, map[i].Location);
                            break;
                        }
                    }
                    for (int i = 0; i < NumberOfPlayers; ++i)
                    {
                        for (int j = 0; j < Player.amountOfChips; ++j)
                        {
                            if ((choosenChip.chip.Location == players[i].chip[j].chip.Location) & (choosenChip.chip.Name != players[i].chip[j].chip.Name))
                            {
                                players[i].chip[j].SetToDefaultLocation();
                                break;
                            }
                        }
                    }
                }
                if (CountOfLead > 1)
                {
                    DeactivateAllPlayersChips();
                    isStepDone = true;
                    canSwitchPlayers = true;
                }
                chipIsMoved(this, null);
                canPassAMove = false;
                map.SetDefaultColorToAllCells();
            }
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

        public void OnChipClick(object sender, EventArgs e)
        {
            Chip clickedChip = (Chip)sender;
            if (clickedChip.enabled)
            {
                players[CurrentlyActivePlayer].ChoosenChipNumber = clickedChip.ChipNumber;
                map.SetDefaultColorToAllCells();
                if ((clickedChip.chip.Location != clickedChip.DefaultLocation) & (clickedChip.onAGame))
                {
                    ShowChipsRoute(clickedChip);
                }
                else
                    if (FirstDicePoints == SecondDicePoints)
                    {
                        int startCell = FindChipsStartCellIndex();
                        map[startCell].BackColor = Color.DarkGray;
                    }
            }
            else
            {
                for (int i = 0; i < map.Count; ++i)
                {
                    if ((map[i].Location == clickedChip.chip.Location) & (map[i].BackColor == Color.DarkGray))
                    {
                        clickedChip.chip.BackColor = Color.DarkGray;
                        OnCellClick(map[i], e);
                        clickedChip.chip.BackColor = Button.DefaultBackColor;
                        clickedChip.SetToDefaultLocation();
                        break;
                    }
                }
            }
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

        public void ShowChipsRoute(Chip clickedChip)
        {
            int currentCellIndex = clickedChip.CurrentCellIndex;
            int destinationCellIndex = FirstDicePoints + currentCellIndex;
            destinationCellIndex = CheckIfDistanceCellIsHomeAndRecalculateDestination(destinationCellIndex);
            MarkOutDestinationCell(destinationCellIndex);
            destinationCellIndex = SecondDicePoints + currentCellIndex;
            destinationCellIndex = CheckIfDistanceCellIsHomeAndRecalculateDestination(destinationCellIndex);
            MarkOutDestinationCell(destinationCellIndex);
            destinationCellIndex = FirstDicePoints + SecondDicePoints + currentCellIndex;
            destinationCellIndex = CheckIfDistanceCellIsHomeAndRecalculateDestination(destinationCellIndex);
            MarkOutDestinationCell(destinationCellIndex);
            if ((FirstDicePoints == 1) || (SecondDicePoints == 1))
            {
                if (currentCellIndex == 6) { MarkOutDestinationCell(20); }
                if (currentCellIndex == 20) { MarkOutDestinationCell(34); }
                if (currentCellIndex == 34) { MarkOutDestinationCell(48); }
                if (currentCellIndex == 48) { MarkOutDestinationCell(6); }
            }
        }

        private int CheckIfDistanceCellIsHomeAndRecalculateDestination(int destinationCell)
        {
            if (destinationCell > 55)
            {
                destinationCell -= 55;
                if (CurrentlyActivePlayer == 0)
                {
                    destinationCell += 57 - 1;
                    if (destinationCell > 59) { destinationCell = 0; }
                }
                if (CurrentlyActivePlayer == 1)
                {
                    destinationCell += 61 - 1;
                    if (destinationCell > 63) { destinationCell = 0; }
                }
                if (CurrentlyActivePlayer == 2)
                {
                    destinationCell += 65 - 1;
                    if (destinationCell > 67) { destinationCell = 0; }
                }
                if (CurrentlyActivePlayer == 3)
                {
                    destinationCell += 69 - 1;
                    if (destinationCell > 71) { destinationCell = 0; }
                }
            }
            return destinationCell;
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

    }
}
