using System;

namespace MashBesh
{
    public class Player
    {
        int choosenChipNumber = 0;
        public int ChoosenChipNumber
        {
            get { return choosenChipNumber; }
            set
            {
                if ((value >= 0) & (value < 4)) { choosenChipNumber = value; } else { choosenChipNumber = 0; }
            }
        }
        string playersName;
        public string PlayersName
        {
            get { return playersName; }
            set { if (value.Length > 15) { playersName = value.Remove(15); } }
        }
        int playersNumber;
        public int PlayersNumber
        {
            get { return playersNumber; }
            set
            {
                if (value > 0) { playersNumber = value; }
                else { playersNumber = 1; }
            }
        }
        public Chip[] chip;
        public bool isPlaying;
        public bool controlByComputer;
        public const int amountOfChips = 3;
        public const int chipsStartCellIndex = 1;
        public EventHandler ExerciseControl;
        
        public Player(int number)
        {
            PlayersNumber = number;
            playersName = "Player" + Convert.ToString(number);
            isPlaying = true;
            chip = new Chip[amountOfChips];
            for (int i = 0; i < amountOfChips; ++i)
            {
                chip[i] = new Chip(PlayersNumber, i);
            }
        }

        public Player(int number, string name)
        {
            PlayersNumber = number;
            isPlaying = true;
            if (name.Length > 0) 
            { 
                playersName = name; 
            }
            else
            {
                playersName = "Player" + Convert.ToString(number);
            }
            chip = new Chip[amountOfChips];
            for (int i = 0; i < amountOfChips; ++i)
            {
                chip[i] = new Chip(PlayersNumber, i);
            }
        }

        public Player(int number, string name, bool premissionToPlay)
        {

                PlayersNumber = number;
                isPlaying = false;
                if (name.Length > 0) { playersName = name; }
                else
                {
                    playersName = "Player" + Convert.ToString(number);
                }
                chip = new Chip[amountOfChips];
                for (int i = 0; i < amountOfChips; ++i)
                {
                    chip[i] = new Chip(PlayersNumber, i);
                }
                if (premissionToPlay) { isPlaying = true; }
                else
                {
                    isPlaying = false;
                    for (int i = 0; i < amountOfChips; ++i)
                    {
                        chip[i].chip.Visible = false; ;
                    }
                }
        }

        public Player(int number, string name, bool premissionToPlay, bool controlByHuman)
        {

            PlayersNumber = number;
            if (name.Length > 0)
            { 
                playersName = name; 
            }
            else
            {
                playersName = "Player" + Convert.ToString(number);
            }
            chip = new Chip[amountOfChips];
            for (int i = 0; i < amountOfChips; ++i)
            {
                chip[i] = new Chip(PlayersNumber, i);
            }
            if (premissionToPlay) { isPlaying = true; }
            else
            {
                isPlaying = false;
                for (int i = 0; i < amountOfChips; ++i)
                {
                    chip[i].chip.Visible = false; ;
                }
            }
            if (controlByHuman) { controlByComputer = false; }
            else { controlByComputer = true; }
        }

        public bool IsChipsOnABoard()
        {
            return (chip[0].onAGame || chip[1].onAGame || chip[2].onAGame);
        }

        public bool IsAllChipsOnFinish()
        {
            return chip[0].onFinish & chip[1].onFinish & chip[2].onFinish;
        }
    }
}
