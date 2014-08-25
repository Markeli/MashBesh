using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MashBesh
{
    class HotSeatGameMap
    {

        public List<Button> map;
        Button standartButton;
        public EventHandler cellClickEvent;

        public HotSeatGameMap()
        {
            standartButton = new Button();
            standartButton.Size = new Size(40, 40);
            CreateMap();
        }

        private void CreateMap()
        {
            map = new List<Button>();
            Point currentCellLocation = new Point(275, 701);
            const int delta = 46;
            int i, numberOfCells = 1;
            for (i = 0; i < 6; ++i)
            {
                currentCellLocation.Y -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.X -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.Y -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.X += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.Y -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.X += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.Y += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.X += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.Y += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.X -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 5; ++i)
            {
                currentCellLocation.Y += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            for (i = 0; i < 3; ++i)
            {
                currentCellLocation.X -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            currentCellLocation = new Point(367, 655);
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.Y -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            currentCellLocation = new Point(45, 333);
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.X += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            currentCellLocation = new Point(367, 11);
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.Y += delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
            currentCellLocation = new Point(688, 333);
            for (i = 0; i < 4; ++i)
            {
                currentCellLocation.X -= delta;
                CreateCell(numberOfCells, currentCellLocation);
                numberOfCells++;
            }
        }

        private void CreateCell(int cellNumber, Point cellLocation)
        {
            Button cell = new Button();
            cell.Name = "Cell" + Convert.ToString(cellNumber);
            cell.TabIndex = cellNumber;
            cell.TabStop = false;
            cell.Size = standartButton.Size;
            cell.Location = cellLocation;
            cell.UseVisualStyleBackColor = true;
            cell.Visible = true;
            cell.Click += new EventHandler(OnCellClick);
            if ((cell.TabIndex == 12) || (cell.TabIndex == 26) || (cell.TabIndex == 40) || (cell.TabIndex == 54))
            {
                cell.BackgroundImage = global ::MashBesh.Properties.Resources.arrow;
            }
            if ((cellNumber == 64) || (cellNumber == 60) || (cellNumber == 68) || (cellNumber == 72))
            {
                cell.Visible = false;
            }
            if ((cellNumber >= 57) & (cellNumber <= 60)) { cell.BackColor = Color.OrangeRed; }
            if ((cellNumber >= 61) & (cellNumber <= 64)) { cell.BackColor = Color.LightGreen; }
            if ((cellNumber >= 65) & (cellNumber <= 68)) { cell.BackColor = Color.LightBlue; }
            if ((cellNumber >= 69) & (cellNumber <= 72)) { cell.BackColor = Color.MediumPurple; }
            map.Add(cell);
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            cellClickEvent(sender, e); 
        }
        
        public Button this[int i]
        {
            get { if  ((i >= 0) && (i < map.Count)) { return map[i]; } else { return standartButton; } }
            set { if ((i >= 0) && (i < map.Count) && (value is Button)) { map[i] = value; } }
        }

        public int Count
        {
            get { return map.Count; }
        }

        public void SetDefaultColorToAllCells()
        {
            for (int i = 0; i < map.Count; ++i)
            {
                map[i].BackColor = Button.DefaultBackColor;
                map[i].UseVisualStyleBackColor = true;
                if ((i + 1 >= 57) & (i + 1 <= 60)) { map[i].BackColor = Color.OrangeRed; }
                if ((i + 1 >= 61) & (i + 1 <= 64)) { map[i].BackColor = Color.LightGreen; }
                if ((i + 1 >= 65) & (i + 1 <= 68)) { map[i].BackColor = Color.LightBlue; }
                if ((i + 1 >= 69) & (i + 1 <= 72)) { map[i].BackColor = Color.MediumPurple; }
            }

        }

        public void ReIndexCells()
        {
            int nextStartPosition = 1;
            for (int i = 0; i < map.Count; ++i)
            {
                if (map[i].TabIndex == 15) { nextStartPosition = i; break; }
            }
            int indexOfCell = 1;
            for (int i = nextStartPosition; i < map.Count - 16; ++i)
            {
                map[i].TabIndex = indexOfCell;
                indexOfCell++;
            }
            for (int i = 0; i < nextStartPosition; ++i)
            {
                map[i].TabIndex = indexOfCell;
                indexOfCell++;
            }
        }
    }
}
