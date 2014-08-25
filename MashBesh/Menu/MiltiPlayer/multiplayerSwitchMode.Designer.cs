namespace MashBesh
{
    partial class multiplayerSwitchMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(multiplayerSwitchMode));
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serverStartButton = new System.Windows.Forms.Button();
            this.clientStartButton = new System.Windows.Forms.Button();
            this.playersName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(126, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 49);
            this.button2.TabIndex = 93;
            this.button2.Text = "В главное меню";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.closingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(140, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 92;
            this.label1.Text = "Сетевая игра";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(152, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 130);
            this.button1.TabIndex = 91;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // serverStartButton
            // 
            this.serverStartButton.BackColor = System.Drawing.SystemColors.Control;
            this.serverStartButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverStartButton.Location = new System.Drawing.Point(25, 345);
            this.serverStartButton.Name = "serverStartButton";
            this.serverStartButton.Size = new System.Drawing.Size(173, 49);
            this.serverStartButton.TabIndex = 94;
            this.serverStartButton.Text = "Я - сервер";
            this.serverStartButton.UseVisualStyleBackColor = true;
            this.serverStartButton.Click += new System.EventHandler(this.serverStartButton_Click);
            // 
            // clientStartButton
            // 
            this.clientStartButton.BackColor = System.Drawing.SystemColors.Control;
            this.clientStartButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientStartButton.Location = new System.Drawing.Point(229, 345);
            this.clientStartButton.Name = "clientStartButton";
            this.clientStartButton.Size = new System.Drawing.Size(173, 49);
            this.clientStartButton.TabIndex = 95;
            this.clientStartButton.Text = "Я - клиент";
            this.clientStartButton.UseVisualStyleBackColor = true;
            this.clientStartButton.Click += new System.EventHandler(this.clientStartButton_Click);
            // 
            // playersName
            // 
            this.playersName.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playersName.Location = new System.Drawing.Point(141, 284);
            this.playersName.MaxLength = 12;
            this.playersName.Name = "playersName";
            this.playersName.Size = new System.Drawing.Size(141, 32);
            this.playersName.TabIndex = 96;
            this.playersName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(147, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 97;
            this.label2.Text = "Имя игрока";
            // 
            // multiplayerSwitchMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(449, 500);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playersName);
            this.Controls.Add(this.clientStartButton);
            this.Controls.Add(this.serverStartButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "multiplayerSwitchMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сетевая игра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button serverStartButton;
        private System.Windows.Forms.Button clientStartButton;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox playersName;
    }
}