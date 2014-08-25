using System;
using System.Windows.Forms;

namespace MashBesh
{
    public partial class hotSeatGame : Form
    {
        int elapsedTime = 0;
        Board board;
        Random cubePoint;
        AudioPlayer backGroundMusic;
        System.Media.SoundPlayer rollADieSound;
        System.Media.SoundPlayer soundMove;
        Settings configuration;

        public hotSeatGame(Player[] newPlayers)
        {
            InitializeComponent();
            board = new Board(newPlayers);
            InitializeMap();
            InitializePlayersChips();
            board.DeactivateAllPlayersChips();
            currentlyActivePlayerLabel.Text = board.players[0].PlayersName;
            cubePoint = new Random();
            board.CurrentlyActivePlayer = -1;
            configuration = new Settings();
            configuration.Load();
            LoadAudio();
            board.chipIsMoved += new EventHandler(OnChipsMovedSound);
            if ((backGroundMusic.IsOpen()) & (configuration.musicIn)) { backGroundMusic.Play(true);  }

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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RollADieButtonClick(object sender, EventArgs e)
        {
            if (board.isStepDone)
            {
                board.isStepDone = false;
                RollADie();
                board.DeactivateAllPlayersChips();
                board.ActivateCurrentPlayersChips();
                currentlyActivePlayerLabel.Text = board.players[board.CurrentlyActivePlayer].PlayersName;
                button2.Image = board.players[board.CurrentlyActivePlayer].chip[0].chip.Image;
                if ((!board.players[board.CurrentlyActivePlayer].IsChipsOnABoard()) & (board.SecondDicePoints != board.FirstDicePoints))
                {
                    MessageBox.Show("Вы не можете сделать ход. Ходит следующий игрок.");
                    board.isStepDone = true;
                    board.canSwitchPlayers = true;
                }
            }
            else
            {
                MessageBox.Show("Вы уже бросили кубик.");
            }

        }

        private void RollADie()
        {
            board.FirstDicePoints = cubePoint.Next(1, cubePoint.Next(1, 9));
            board.SecondDicePoints = cubePoint.Next(1, cubePoint.Next(1, 9));
            fisrtDicePointsLabel.Text = "";
            secondDicePointsLabel.Text = "";
            SetImageToDice(board.FirstDicePoints, board.SecondDicePoints);
            if ((rollADieSound.IsLoadCompleted) & (configuration.soundIn)) { rollADieSound.PlaySync(); }
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
            board.canSwitchPlayers = true;
            board.isStepDone = true;
        }

        private void CheckEventsTimerTick(object sender, EventArgs e)
        {
            if ((!board.isFirstStep) && (board.players[board.CurrentlyActivePlayer].isPlaying) && board.IsAllCurrentPlayerChipsOnFinish())
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
                board.canPassAMove = true;
                board.canSwitchPlayers = false;
                board.map.SetDefaultColorToAllCells();
                if (board.isFirstStep)
                {
                    board.isFirstStep = false;
                }
                currentlyActivePlayerLabel.Text = board.players[board.CurrentlyActivePlayer].PlayersName;
                button2.Image = board.players[board.CurrentlyActivePlayer].chip[1].chip.Image;
                fisrtDicePointsLabel.Text = "X";
                secondDicePointsLabel.Text = "X";
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

        private void OnChipsMovedSound(object sendedr, EventArgs e)
        {
            if ((soundMove.IsLoadCompleted) & (configuration.soundIn)) { soundMove.Play(); }
        }

        private void MashbeshFormClosing(object sender, FormClosingEventArgs e)
        {
            if (backGroundMusic.IsOpen()) { backGroundMusic.Close(); }
        }

    }
}
