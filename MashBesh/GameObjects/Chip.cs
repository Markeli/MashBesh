using System;
using System.Windows.Forms;
using System.Drawing;

namespace MashBesh
{
    public class Chip 
    {
        public bool onAGame = false;
        public bool onFinish = false;
        int chipNumber;
        public int ChipNumber
        {
            get { return chipNumber; }
            set { if (value >= 0) { chipNumber = value; } else { chipNumber = 1; } }
        }
        int currentCellIndex;
        public int CurrentCellIndex
        {
            get { return currentCellIndex; }
            set { if (value > 0) { currentCellIndex = value; } else { currentCellIndex = 0; } }
        }
        Point defaultLocation;
        public Point DefaultLocation
        {
            get { return defaultLocation; }
            set { if (value != null) { defaultLocation = value; } else { defaultLocation = new Point(0, 0); } }
        }
        static Size defaultChipSize = new Size(40, 40);
        public Button chip;
        public bool enabled = true;
        public EventHandler chipClickEvent;

        public Chip(int playerNumber, int chipNumber)
        {
            ChipNumber = chipNumber;
            chip = new Button();
            chip.Visible = true;
            chip.Name = "Player" + Convert.ToString(playerNumber) + " chip" + Convert.ToString(chipNumber);
            chip.Size = defaultChipSize;
            chip.TabStop = false;
            chip.UseVisualStyleBackColor = true;
            if (playerNumber == 1) 
            { 
                chip.Image = global ::MashBesh.Properties.Resources.player1;
                chip.Location = CalculateDefaultLocation(playerNumber,chipNumber);
            }
            if (playerNumber == 2) 
            { 
                chip.Image = global ::MashBesh.Properties.Resources.player2;
                chip.Location = CalculateDefaultLocation(playerNumber, chipNumber);
            }
            if (playerNumber == 3) 
            { 
                chip.Image = global ::MashBesh.Properties.Resources.player3;
                chip.Location = CalculateDefaultLocation(playerNumber, chipNumber);
            }
            if (playerNumber == 4) 
            { 
                chip.Image = global ::MashBesh.Properties.Resources.player4;
                chip.Location = CalculateDefaultLocation(playerNumber, chipNumber);
            }
            DefaultLocation = chip.Location;
            chip.Click += new EventHandler(OnChipClick);
        }

        private Point CalculateDefaultLocation(int playerNumber, int chipNumber)
        {
            Point location = new Point(0, 0); ;
            if (playerNumber == 1)
            {
                location = new Point(113 + 45 * (chipNumber), 489 + 45 * (chipNumber));
            }
            if (playerNumber == 2)
            {
                location = new Point(113 + 45 * (chipNumber), 177 - 45 * (chipNumber));
            }
            if (playerNumber == 3)
            {
                location = new Point(621 - 45 * (chipNumber), 177 - 45 * (chipNumber));
            }
            if (playerNumber == 4)
            {
                location = new Point(621 - 45 * (chipNumber), 489 + 45 * (chipNumber));
            }
            return location;
        }

        private void OnChipClick(object sender, EventArgs e)
        {
            chipClickEvent(this, null);   
        }

        public void SetToDefaultLocation()
        {
            chip.Location = defaultLocation;
            onAGame = false;
        }

        public void ChangeLocation(int newCurrentCellIndex, Point newDestinationLocation)
        {
            chip.Location = newDestinationLocation;
            currentCellIndex = newCurrentCellIndex;
            if (newCurrentCellIndex > 56) 
            { 
                onAGame = false;
                onFinish = true;
            } 
            else 
            { 
                onAGame = true;
                onFinish = false;
            }
        }
   }
}
