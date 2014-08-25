namespace MashBesh
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.musicCheckBox = new System.Windows.Forms.CheckBox();
            this.soundCheckBox = new System.Windows.Forms.CheckBox();
            this.musicVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(176, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 30);
            this.label1.TabIndex = 80;
            this.label1.Text = "Машбеш";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MashBesh.Properties.Resources.symbol;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(160, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 130);
            this.button1.TabIndex = 79;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(139, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 49);
            this.button2.TabIndex = 90;
            this.button2.Text = "В главное меню";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // musicCheckBox
            // 
            this.musicCheckBox.AutoSize = true;
            this.musicCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.musicCheckBox.Location = new System.Drawing.Point(176, 210);
            this.musicCheckBox.Name = "musicCheckBox";
            this.musicCheckBox.Size = new System.Drawing.Size(99, 31);
            this.musicCheckBox.TabIndex = 91;
            this.musicCheckBox.Text = "Музыка";
            this.musicCheckBox.UseVisualStyleBackColor = true;
            // 
            // soundCheckBox
            // 
            this.soundCheckBox.AutoSize = true;
            this.soundCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundCheckBox.Location = new System.Drawing.Point(121, 321);
            this.soundCheckBox.Name = "soundCheckBox";
            this.soundCheckBox.Size = new System.Drawing.Size(208, 31);
            this.soundCheckBox.TabIndex = 92;
            this.soundCheckBox.Text = "Звуковые эффекты";
            this.soundCheckBox.UseVisualStyleBackColor = true;
            // 
            // musicVolumeTrackBar
            // 
            this.musicVolumeTrackBar.LargeChange = 20;
            this.musicVolumeTrackBar.Location = new System.Drawing.Point(121, 247);
            this.musicVolumeTrackBar.Maximum = 100;
            this.musicVolumeTrackBar.Name = "musicVolumeTrackBar";
            this.musicVolumeTrackBar.Size = new System.Drawing.Size(208, 58);
            this.musicVolumeTrackBar.SmallChange = 5;
            this.musicVolumeTrackBar.TabIndex = 93;
            this.musicVolumeTrackBar.TickFrequency = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(138, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 25);
            this.label2.TabIndex = 94;
            this.label2.Text = "Громкость музыки";
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelSettingsButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelSettingsButton.Location = new System.Drawing.Point(249, 369);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(137, 49);
            this.cancelSettingsButton.TabIndex = 82;
            this.cancelSettingsButton.Text = "Отмена";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveSettingsButton.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveSettingsButton.Location = new System.Drawing.Point(70, 369);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(137, 49);
            this.saveSettingsButton.TabIndex = 81;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(449, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.musicVolumeTrackBar);
            this.Controls.Add(this.soundCheckBox);
            this.Controls.Add(this.musicCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(457, 516);
            this.MinimumSize = new System.Drawing.Size(457, 516);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.musicVolumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox musicCheckBox;
        private System.Windows.Forms.CheckBox soundCheckBox;
        private System.Windows.Forms.TrackBar musicVolumeTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}