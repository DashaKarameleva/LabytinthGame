namespace WinFormsGame
{
    partial class GameForm
    {
        private OpenTK.GLControl gLControl;

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
            this.gLControl = new OpenTK.GLControl();
            this.health1 = new System.Windows.Forms.Label();
            this.health2 = new System.Windows.Forms.Label();
            this.armor1 = new System.Windows.Forms.Label();
            this.armor2 = new System.Windows.Forms.Label();
            this.patronCount1 = new System.Windows.Forms.Label();
            this.patronCount2 = new System.Windows.Forms.Label();
            this.points1 = new System.Windows.Forms.Label();
            this.points2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gLControl
            // 
            this.gLControl.BackColor = System.Drawing.Color.Transparent;
            this.gLControl.Location = new System.Drawing.Point(0, 0);
            this.gLControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(1557, 900);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = false;
            this.gLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.gLControl.Resize += new System.EventHandler(this.GLControl_Resize);
            // 
            // health1
            // 
            this.health1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.health1.Location = new System.Drawing.Point(62, 841);
            this.health1.Name = "health1";
            this.health1.Size = new System.Drawing.Size(66, 50);
            this.health1.TabIndex = 1;
            this.health1.Text = "label1";
            this.health1.Click += new System.EventHandler(this.health1_Click);
            // 
            // health2
            // 
            this.health2.AutoSize = true;
            this.health2.Location = new System.Drawing.Point(773, 854);
            this.health2.Name = "health2";
            this.health2.Size = new System.Drawing.Size(46, 17);
            this.health2.TabIndex = 2;
            this.health2.Text = "label1";
            this.health2.Click += new System.EventHandler(this.label1_Click);
            // 
            // armor1
            // 
            this.armor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armor1.Location = new System.Drawing.Point(158, 841);
            this.armor1.Name = "armor1";
            this.armor1.Size = new System.Drawing.Size(66, 50);
            this.armor1.TabIndex = 3;
            this.armor1.Text = "label1";
            // 
            // armor2
            // 
            this.armor2.AutoSize = true;
            this.armor2.Location = new System.Drawing.Point(857, 854);
            this.armor2.Name = "armor2";
            this.armor2.Size = new System.Drawing.Size(46, 17);
            this.armor2.TabIndex = 4;
            this.armor2.Text = "label1";
            // 
            // patronCount1
            // 
            this.patronCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronCount1.Location = new System.Drawing.Point(257, 841);
            this.patronCount1.Name = "patronCount1";
            this.patronCount1.Size = new System.Drawing.Size(66, 50);
            this.patronCount1.TabIndex = 5;
            this.patronCount1.Text = "label1";
            // 
            // patronCount2
            // 
            this.patronCount2.AutoSize = true;
            this.patronCount2.Location = new System.Drawing.Point(946, 854);
            this.patronCount2.Name = "patronCount2";
            this.patronCount2.Size = new System.Drawing.Size(46, 17);
            this.patronCount2.TabIndex = 6;
            this.patronCount2.Text = "label1";
            // 
            // points1
            // 
            this.points1.AutoSize = true;
            this.points1.Location = new System.Drawing.Point(361, 841);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(46, 17);
            this.points1.TabIndex = 7;
            this.points1.Text = "label1";
            // 
            // points2
            // 
            this.points2.AutoSize = true;
            this.points2.Location = new System.Drawing.Point(1027, 854);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(46, 17);
            this.points2.TabIndex = 8;
            this.points2.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 900);
            this.Controls.Add(this.points2);
            this.Controls.Add(this.points1);
            this.Controls.Add(this.patronCount2);
            this.Controls.Add(this.patronCount1);
            this.Controls.Add(this.armor2);
            this.Controls.Add(this.armor1);
            this.Controls.Add(this.health2);
            this.Controls.Add(this.health1);
            this.Controls.Add(this.gLControl);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label health1;
        private System.Windows.Forms.Label health2;
        private System.Windows.Forms.Label armor1;
        private System.Windows.Forms.Label armor2;
        private System.Windows.Forms.Label patronCount1;
        private System.Windows.Forms.Label patronCount2;
        private System.Windows.Forms.Label points1;
        private System.Windows.Forms.Label points2;
    }
}

