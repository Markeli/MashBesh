namespace MashBesh
{
    partial class hotSeatGame
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hotSeatGame));
            this.rollADieButton = new System.Windows.Forms.Button();
            this.passAMoveButton = new System.Windows.Forms.Button();
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.currentlyActivePlayerLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.elapsedTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.secondDicePointsLabel = new System.Windows.Forms.Label();
            this.fisrtDicePointsLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.boardBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // rollADieButton
            // 
            this.rollADieButton.BackColor = System.Drawing.SystemColors.Control;
            this.rollADieButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rollADieButton.Location = new System.Drawing.Point(793, 549);
            this.rollADieButton.Name = "rollADieButton";
            this.rollADieButton.Size = new System.Drawing.Size(213, 49);
            this.rollADieButton.TabIndex = 76;
            this.rollADieButton.Text = "Бросить кубик";
            this.rollADieButton.UseVisualStyleBackColor = true;
            this.rollADieButton.Click += new System.EventHandler(this.RollADieButtonClick);
            // 
            // passAMoveButton
            // 
            this.passAMoveButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passAMoveButton.Location = new System.Drawing.Point(793, 626);
            this.passAMoveButton.Name = "passAMoveButton";
            this.passAMoveButton.Size = new System.Drawing.Size(213, 49);
            this.passAMoveButton.TabIndex = 82;
            this.passAMoveButton.Text = "Пропустить ход";
            this.passAMoveButton.UseVisualStyleBackColor = true;
            this.passAMoveButton.Click += new System.EventHandler(this.PassAMoveButtonClick);
            // 
            // eventTimer
            // 
            this.eventTimer.Enabled = true;
            this.eventTimer.Tick += new System.EventHandler(this.CheckEventsTimerTick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(323, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 130);
            this.button3.TabIndex = 84;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // currentlyActivePlayerLabel
            // 
            this.currentlyActivePlayerLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentlyActivePlayerLabel.Location = new System.Drawing.Point(325, 390);
            this.currentlyActivePlayerLabel.Name = "currentlyActivePlayerLabel";
            this.currentlyActivePlayerLabel.Size = new System.Drawing.Size(126, 27);
            this.currentlyActivePlayerLabel.TabIndex = 81;
            this.currentlyActivePlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(325, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 27);
            this.label4.TabIndex = 80;
            this.label4.Text = "Ход игрока:";
            // 
            // elapsedTimeTimer
            // 
            this.elapsedTimeTimer.Enabled = true;
            this.elapsedTimeTimer.Interval = 1000;
            this.elapsedTimeTimer.Tick += new System.EventHandler(this.ElapsedTimeTimerTick);
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elapsedTimeLabel.Image = ((System.Drawing.Image)(resources.GetObject("elapsedTimeLabel.Image")));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(826, 83);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(141, 27);
            this.elapsedTimeLabel.TabIndex = 86;
            this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(836, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 27);
            this.label6.TabIndex = 85;
            this.label6.Text = "Время игры:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::MashBesh.Properties.Resources.player1;
            this.button2.Location = new System.Drawing.Point(368, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 83;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(858, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 27);
            this.label3.TabIndex = 79;
            this.label3.Text = "Кубики";
            // 
            // secondDicePointsLabel
            // 
            this.secondDicePointsLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.secondDicePointsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.secondDicePointsLabel.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondDicePointsLabel.Image = ((System.Drawing.Image)(resources.GetObject("secondDicePointsLabel.Image")));
            this.secondDicePointsLabel.Location = new System.Drawing.Point(939, 475);
            this.secondDicePointsLabel.Name = "secondDicePointsLabel";
            this.secondDicePointsLabel.Size = new System.Drawing.Size(29, 29);
            this.secondDicePointsLabel.TabIndex = 78;
            this.secondDicePointsLabel.Text = "X";
            // 
            // fisrtDicePointsLabel
            // 
            this.fisrtDicePointsLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.fisrtDicePointsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fisrtDicePointsLabel.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fisrtDicePointsLabel.Image = ((System.Drawing.Image)(resources.GetObject("fisrtDicePointsLabel.Image")));
            this.fisrtDicePointsLabel.Location = new System.Drawing.Point(832, 475);
            this.fisrtDicePointsLabel.Name = "fisrtDicePointsLabel";
            this.fisrtDicePointsLabel.Size = new System.Drawing.Size(29, 29);
            this.fisrtDicePointsLabel.TabIndex = 77;
            this.fisrtDicePointsLabel.Text = "X";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(778, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 720);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // boardBackground
            // 
            this.boardBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardBackground.BackColor = System.Drawing.Color.White;
            this.boardBackground.Image = ((System.Drawing.Image)(resources.GetObject("boardBackground.Image")));
            this.boardBackground.Location = new System.Drawing.Point(23, 2);
            this.boardBackground.Name = "boardBackground";
            this.boardBackground.Size = new System.Drawing.Size(727, 702);
            this.boardBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boardBackground.TabIndex = 1;
            this.boardBackground.TabStop = false;
            // 
            // hotSeatGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 702);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.passAMoveButton);
            this.Controls.Add(this.currentlyActivePlayerLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secondDicePointsLabel);
            this.Controls.Add(this.fisrtDicePointsLabel);
            this.Controls.Add(this.rollADieButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.boardBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 728);
            this.MinimumSize = new System.Drawing.Size(1024, 728);
            this.Name = "hotSeatGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hot-Seat игра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MashbeshFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boardBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boardBackground;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rollADieButton;
        private System.Windows.Forms.Label fisrtDicePointsLabel;
        private System.Windows.Forms.Label secondDicePointsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentlyActivePlayerLabel;
        private System.Windows.Forms.Button passAMoveButton;
        private System.Windows.Forms.Timer eventTimer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Timer elapsedTimeTimer;
    }
}

