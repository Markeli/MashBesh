namespace MashBesh
{
    partial class hotSeatMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hotSeatMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.player1Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.TextBox();
            this.player3Name = new System.Windows.Forms.TextBox();
            this.player4Name = new System.Windows.Forms.TextBox();
            this.cancelMultiplayerButton = new System.Windows.Forms.Button();
            this.playMultiplayerButton = new System.Windows.Forms.Button();
            this.player1ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player2ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player4ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player3ModeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(172, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 30);
            this.label1.TabIndex = 82;
            this.label1.Text = "Машбеш";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MashBesh.Properties.Resources.symbol;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(157, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 130);
            this.button1.TabIndex = 81;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::MashBesh.Properties.Resources.player3;
            this.button6.Location = new System.Drawing.Point(66, 350);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 91;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::MashBesh.Properties.Resources.player4;
            this.button5.Location = new System.Drawing.Point(66, 405);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 90;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::MashBesh.Properties.Resources.player1;
            this.button3.Location = new System.Drawing.Point(66, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 88;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::MashBesh.Properties.Resources.player2;
            this.button2.Location = new System.Drawing.Point(66, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 89;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // player1Name
            // 
            this.player1Name.Enabled = false;
            this.player1Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1Name.Location = new System.Drawing.Point(239, 243);
            this.player1Name.MaxLength = 12;
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(141, 32);
            this.player1Name.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(152, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 93;
            this.label2.Text = "Имя игрока";
            // 
            // player2Name
            // 
            this.player2Name.Enabled = false;
            this.player2Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player2Name.Location = new System.Drawing.Point(239, 294);
            this.player2Name.MaxLength = 12;
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(141, 32);
            this.player2Name.TabIndex = 94;
            // 
            // player3Name
            // 
            this.player3Name.Enabled = false;
            this.player3Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player3Name.Location = new System.Drawing.Point(239, 349);
            this.player3Name.MaxLength = 12;
            this.player3Name.Name = "player3Name";
            this.player3Name.Size = new System.Drawing.Size(141, 32);
            this.player3Name.TabIndex = 95;
            // 
            // player4Name
            // 
            this.player4Name.Enabled = false;
            this.player4Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player4Name.Location = new System.Drawing.Point(239, 404);
            this.player4Name.MaxLength = 12;
            this.player4Name.Name = "player4Name";
            this.player4Name.Size = new System.Drawing.Size(141, 32);
            this.player4Name.TabIndex = 96;
            // 
            // cancelMultiplayerButton
            // 
            this.cancelMultiplayerButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelMultiplayerButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelMultiplayerButton.Location = new System.Drawing.Point(245, 469);
            this.cancelMultiplayerButton.Name = "cancelMultiplayerButton";
            this.cancelMultiplayerButton.Size = new System.Drawing.Size(137, 49);
            this.cancelMultiplayerButton.TabIndex = 98;
            this.cancelMultiplayerButton.Text = "Отмена";
            this.cancelMultiplayerButton.UseVisualStyleBackColor = true;
            this.cancelMultiplayerButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // playMultiplayerButton
            // 
            this.playMultiplayerButton.BackColor = System.Drawing.SystemColors.Control;
            this.playMultiplayerButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playMultiplayerButton.Location = new System.Drawing.Point(66, 469);
            this.playMultiplayerButton.Name = "playMultiplayerButton";
            this.playMultiplayerButton.Size = new System.Drawing.Size(137, 49);
            this.playMultiplayerButton.TabIndex = 97;
            this.playMultiplayerButton.Text = "Играть";
            this.playMultiplayerButton.UseVisualStyleBackColor = true;
            this.playMultiplayerButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // player1ModeComboBox
            // 
            this.player1ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1ModeComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1ModeComboBox.FormattingEnabled = true;
            this.player1ModeComboBox.ItemHeight = 25;
            this.player1ModeComboBox.Items.AddRange(new object[] {
            "Играет",
            "Не играет",
            "Компьютер"});
            this.player1ModeComboBox.Location = new System.Drawing.Point(112, 243);
            this.player1ModeComboBox.Name = "player1ModeComboBox";
            this.player1ModeComboBox.Size = new System.Drawing.Size(121, 33);
            this.player1ModeComboBox.TabIndex = 100;
            this.player1ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.SetPlayerMode);
            // 
            // player2ModeComboBox
            // 
            this.player2ModeComboBox.CausesValidation = false;
            this.player2ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player2ModeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.player2ModeComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player2ModeComboBox.FormattingEnabled = true;
            this.player2ModeComboBox.Items.AddRange(new object[] {
            "Играет",
            "Не играет",
            "Компьютер"});
            this.player2ModeComboBox.Location = new System.Drawing.Point(112, 297);
            this.player2ModeComboBox.Name = "player2ModeComboBox";
            this.player2ModeComboBox.Size = new System.Drawing.Size(121, 33);
            this.player2ModeComboBox.TabIndex = 101;
            this.player2ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.SetPlayerMode);
            // 
            // player4ModeComboBox
            // 
            this.player4ModeComboBox.CausesValidation = false;
            this.player4ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player4ModeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.player4ModeComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player4ModeComboBox.FormattingEnabled = true;
            this.player4ModeComboBox.Items.AddRange(new object[] {
            "Играет",
            "Не играет",
            "Кмопьютер"});
            this.player4ModeComboBox.Location = new System.Drawing.Point(112, 404);
            this.player4ModeComboBox.Name = "player4ModeComboBox";
            this.player4ModeComboBox.Size = new System.Drawing.Size(121, 33);
            this.player4ModeComboBox.TabIndex = 102;
            this.player4ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.SetPlayerMode);
            // 
            // player3ModeComboBox
            // 
            this.player3ModeComboBox.CausesValidation = false;
            this.player3ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player3ModeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.player3ModeComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player3ModeComboBox.FormattingEnabled = true;
            this.player3ModeComboBox.Items.AddRange(new object[] {
            "Играет",
            "Не играет",
            "Компьютер"});
            this.player3ModeComboBox.Location = new System.Drawing.Point(112, 348);
            this.player3ModeComboBox.Name = "player3ModeComboBox";
            this.player3ModeComboBox.Size = new System.Drawing.Size(121, 33);
            this.player3ModeComboBox.TabIndex = 102;
            this.player3ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.SetPlayerMode);
            // 
            // hotSeatMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(450, 542);
            this.Controls.Add(this.player3ModeComboBox);
            this.Controls.Add(this.player4ModeComboBox);
            this.Controls.Add(this.player2ModeComboBox);
            this.Controls.Add(this.player1ModeComboBox);
            this.Controls.Add(this.cancelMultiplayerButton);
            this.Controls.Add(this.playMultiplayerButton);
            this.Controls.Add(this.player4Name);
            this.Controls.Add(this.player3Name);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "hotSeatMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hot-Seat игра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox player1Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox player2Name;
        private System.Windows.Forms.TextBox player3Name;
        private System.Windows.Forms.TextBox player4Name;
        private System.Windows.Forms.Button cancelMultiplayerButton;
        private System.Windows.Forms.Button playMultiplayerButton;
        private System.Windows.Forms.ComboBox player1ModeComboBox;
        private System.Windows.Forms.ComboBox player2ModeComboBox;
        private System.Windows.Forms.ComboBox player4ModeComboBox;
        private System.Windows.Forms.ComboBox player3ModeComboBox;
    }
}