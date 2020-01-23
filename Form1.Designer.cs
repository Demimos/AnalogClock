namespace AnalogClock
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Zone = new System.Windows.Forms.ComboBox();
            this.dateText = new System.Windows.Forms.Label();
            this.clockBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.date = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clockBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Zone
            // 
            this.Zone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Zone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Zone.FormattingEnabled = true;
            this.Zone.Location = new System.Drawing.Point(12, 468);
            this.Zone.Name = "Zone";
            this.Zone.Size = new System.Drawing.Size(400, 21);
            this.Zone.TabIndex = 0;
            this.Zone.SelectedIndexChanged += new System.EventHandler(this.Zone_SelectedIndexChanged);
            // 
            // dateText
            // 
            this.dateText.AutoSize = true;
            this.dateText.Location = new System.Drawing.Point(12, 263);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(0, 13);
            this.dateText.TabIndex = 1;
            // 
            // clockBox
            // 
            this.clockBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clockBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.clockBox.Location = new System.Drawing.Point(12, 12);
            this.clockBox.Name = "clockBox";
            this.clockBox.Size = new System.Drawing.Size(400, 411);
            this.clockBox.TabIndex = 2;
            this.clockBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date.Location = new System.Drawing.Point(12, 426);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 39);
            this.date.TabIndex = 3;
            this.date.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 502);
            this.Controls.Add(this.date);
            this.Controls.Add(this.clockBox);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.Zone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Clock";
            ((System.ComponentModel.ISupportInitialize)(this.clockBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Zone;
        private System.Windows.Forms.Label dateText;
        private System.Windows.Forms.PictureBox clockBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label date;
    }
}

