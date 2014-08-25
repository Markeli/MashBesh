namespace MashBesh
{
    partial class WaitingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.conectionStatus = new System.Windows.Forms.Label();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.waitingTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // conectionStatus
            // 
            this.conectionStatus.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conectionStatus.Image = ((System.Drawing.Image)(resources.GetObject("conectionStatus.Image")));
            this.conectionStatus.Location = new System.Drawing.Point(27, 35);
            this.conectionStatus.Name = "conectionStatus";
            this.conectionStatus.Size = new System.Drawing.Size(285, 82);
            this.conectionStatus.TabIndex = 98;
            this.conectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waitingLabel
            // 
            this.waitingLabel.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waitingLabel.Image = ((System.Drawing.Image)(resources.GetObject("waitingLabel.Image")));
            this.waitingLabel.Location = new System.Drawing.Point(27, 138);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(285, 19);
            this.waitingLabel.TabIndex = 99;
            this.waitingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waitingTimer
            // 
            this.waitingTimer.Enabled = true;
            this.waitingTimer.Interval = 500;
            this.waitingTimer.Tick += new System.EventHandler(this.waitingTimer_Tick);
            // 
            // WaitingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(340, 179);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.conectionStatus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "waitingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.Timer waitingTimer;
        public System.Windows.Forms.Label conectionStatus;
    }
}