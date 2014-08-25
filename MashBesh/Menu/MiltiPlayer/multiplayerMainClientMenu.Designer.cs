namespace MashBesh
{
    partial class mainClientMultiPlayerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainClientMultiPlayerMenu));
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
            this.player1ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player2ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player4ModeComboBox = new System.Windows.Forms.ComboBox();
            this.player3ModeComboBox = new System.Windows.Forms.ComboBox();
            this.OutputMessageText = new System.Windows.Forms.TextBox();
            this.SendTextMessage = new System.Windows.Forms.Button();
            this.InputMessageText = new System.Windows.Forms.RichTextBox();
            this.timeCounDown = new System.Windows.Forms.Timer(this.components);
            this.playMultiplayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::MashBesh.Properties.Resources.player3;
            this.button6.Location = new System.Drawing.Point(71, 185);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 91;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::MashBesh.Properties.Resources.player4;
            this.button5.Location = new System.Drawing.Point(71, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 90;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::MashBesh.Properties.Resources.player1;
            this.button3.Location = new System.Drawing.Point(71, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 88;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::MashBesh.Properties.Resources.player2;
            this.button2.Location = new System.Drawing.Point(71, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 89;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // player1Name
            // 
            this.player1Name.Enabled = false;
            this.player1Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1Name.Location = new System.Drawing.Point(244, 78);
            this.player1Name.MaxLength = 12;
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(141, 32);
            this.player1Name.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(190, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 93;
            this.label2.Text = "Игроки";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2Name
            // 
            this.player2Name.Enabled = false;
            this.player2Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player2Name.Location = new System.Drawing.Point(244, 129);
            this.player2Name.MaxLength = 12;
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(141, 32);
            this.player2Name.TabIndex = 94;
            // 
            // player3Name
            // 
            this.player3Name.Enabled = false;
            this.player3Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player3Name.Location = new System.Drawing.Point(244, 184);
            this.player3Name.MaxLength = 12;
            this.player3Name.Name = "player3Name";
            this.player3Name.Size = new System.Drawing.Size(141, 32);
            this.player3Name.TabIndex = 95;
            // 
            // player4Name
            // 
            this.player4Name.Enabled = false;
            this.player4Name.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player4Name.Location = new System.Drawing.Point(244, 239);
            this.player4Name.MaxLength = 12;
            this.player4Name.Name = "player4Name";
            this.player4Name.Size = new System.Drawing.Size(141, 32);
            this.player4Name.TabIndex = 96;
            // 
            // cancelMultiplayerButton
            // 
            this.cancelMultiplayerButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelMultiplayerButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelMultiplayerButton.Location = new System.Drawing.Point(248, 470);
            this.cancelMultiplayerButton.Name = "cancelMultiplayerButton";
            this.cancelMultiplayerButton.Size = new System.Drawing.Size(137, 49);
            this.cancelMultiplayerButton.TabIndex = 98;
            this.cancelMultiplayerButton.Text = "Отмена";
            this.cancelMultiplayerButton.UseVisualStyleBackColor = true;
            this.cancelMultiplayerButton.Click += new System.EventHandler(this.CancelMultiplayerButtonClick);
            // 
            // player1ModeComboBox
            // 
            this.player1ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1ModeComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1ModeComboBox.FormattingEnabled = true;
            this.player1ModeComboBox.ItemHeight = 25;
            this.player1ModeComboBox.Items.AddRange(new object[] {
            "Играет",
            "Не играет"});
            this.player1ModeComboBox.Location = new System.Drawing.Point(117, 78);
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
            "Не играет"});
            this.player2ModeComboBox.Location = new System.Drawing.Point(117, 132);
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
            "Не играет"});
            this.player4ModeComboBox.Location = new System.Drawing.Point(117, 239);
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
            "Не играет"});
            this.player3ModeComboBox.Location = new System.Drawing.Point(117, 183);
            this.player3ModeComboBox.Name = "player3ModeComboBox";
            this.player3ModeComboBox.Size = new System.Drawing.Size(121, 33);
            this.player3ModeComboBox.TabIndex = 102;
            this.player3ModeComboBox.SelectionChangeCommitted += new System.EventHandler(this.SetPlayerMode);
            // 
            // OutputMessageText
            // 
            this.OutputMessageText.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputMessageText.Location = new System.Drawing.Point(50, 422);
            this.OutputMessageText.Name = "OutputMessageText";
            this.OutputMessageText.Size = new System.Drawing.Size(263, 26);
            this.OutputMessageText.TabIndex = 104;
            this.OutputMessageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutputMessageTextKeyDown);
            // 
            // SendTextMessage
            // 
            this.SendTextMessage.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendTextMessage.Location = new System.Drawing.Point(319, 416);
            this.SendTextMessage.Name = "SendTextMessage";
            this.SendTextMessage.Size = new System.Drawing.Size(98, 34);
            this.SendTextMessage.TabIndex = 105;
            this.SendTextMessage.Text = "Отправить";
            this.SendTextMessage.UseVisualStyleBackColor = true;
            this.SendTextMessage.Click += new System.EventHandler(this.SendTextMessageClick);
            // 
            // InputMessageText
            // 
            this.InputMessageText.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputMessageText.Location = new System.Drawing.Point(50, 294);
            this.InputMessageText.Name = "InputMessageText";
            this.InputMessageText.ReadOnly = true;
            this.InputMessageText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.InputMessageText.Size = new System.Drawing.Size(367, 116);
            this.InputMessageText.TabIndex = 106;
            this.InputMessageText.Text = "";
            // 
            // timeCounDown
            // 
            this.timeCounDown.Interval = 1000;
            this.timeCounDown.Tag = "5";
            this.timeCounDown.Tick += new System.EventHandler(this.TimeCountDownTick);
            // 
            // playMultiplayerButton
            // 
            this.playMultiplayerButton.BackColor = System.Drawing.SystemColors.Control;
            this.playMultiplayerButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playMultiplayerButton.Location = new System.Drawing.Point(80, 470);
            this.playMultiplayerButton.Name = "playMultiplayerButton";
            this.playMultiplayerButton.Size = new System.Drawing.Size(137, 49);
            this.playMultiplayerButton.TabIndex = 108;
            this.playMultiplayerButton.Text = "Играть";
            this.playMultiplayerButton.UseVisualStyleBackColor = true;
            this.playMultiplayerButton.Click += new System.EventHandler(this.PlayMultiplayerButtonClick);
            // 
            // mainClientMultiPlayerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(450, 542);
            this.Controls.Add(this.playMultiplayerButton);
            this.Controls.Add(this.InputMessageText);
            this.Controls.Add(this.SendTextMessage);
            this.Controls.Add(this.OutputMessageText);
            this.Controls.Add(this.player3ModeComboBox);
            this.Controls.Add(this.player4ModeComboBox);
            this.Controls.Add(this.player2ModeComboBox);
            this.Controls.Add(this.player1ModeComboBox);
            this.Controls.Add(this.cancelMultiplayerButton);
            this.Controls.Add(this.player4Name);
            this.Controls.Add(this.player3Name);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainClientMultiPlayerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerMultiPlayerMenuFormClosing);
            this.Load += new System.EventHandler(this.ServerMultiPlayerMenuLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ComboBox player1ModeComboBox;
        private System.Windows.Forms.ComboBox player2ModeComboBox;
        private System.Windows.Forms.ComboBox player4ModeComboBox;
        private System.Windows.Forms.ComboBox player3ModeComboBox;
        private System.Windows.Forms.TextBox OutputMessageText;
        private System.Windows.Forms.Button SendTextMessage;
        private System.Windows.Forms.RichTextBox InputMessageText;
        private System.Windows.Forms.Timer timeCounDown;
        private System.Windows.Forms.Button playMultiplayerButton;
    }
}