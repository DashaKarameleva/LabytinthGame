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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.armor3 = new System.Windows.Forms.PictureBox();
            this.patron1 = new System.Windows.Forms.PictureBox();
            this.points = new System.Windows.Forms.PictureBox();
            this.armor = new System.Windows.Forms.PictureBox();
            this.patron2 = new System.Windows.Forms.PictureBox();
            this.pointsA = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patron1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.points)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patron2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsA)).BeginInit();
            this.SuspendLayout();
            // 
            // gLControl
            // 
            this.gLControl.BackColor = System.Drawing.SystemColors.WindowText;
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
            this.health1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.health1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.health1.Location = new System.Drawing.Point(194, 842);
            this.health1.Name = "health1";
            this.health1.Size = new System.Drawing.Size(66, 50);
            this.health1.TabIndex = 1;
            this.health1.Text = "label1";
            this.health1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.health1.Click += new System.EventHandler(this.health1_Click);
            // 
            // health2
            // 
            this.health2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.health2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.health2.Location = new System.Drawing.Point(1009, 842);
            this.health2.Name = "health2";
            this.health2.Size = new System.Drawing.Size(66, 50);
            this.health2.TabIndex = 2;
            this.health2.Text = "label1";
            this.health2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.health2.Click += new System.EventHandler(this.label1_Click);
            // 
            // armor1
            // 
            this.armor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.armor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armor1.Location = new System.Drawing.Point(310, 841);
            this.armor1.Name = "armor1";
            this.armor1.Size = new System.Drawing.Size(66, 50);
            this.armor1.TabIndex = 3;
            this.armor1.Text = "label1";
            this.armor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // armor2
            // 
            this.armor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.armor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.armor2.Location = new System.Drawing.Point(1125, 842);
            this.armor2.Name = "armor2";
            this.armor2.Size = new System.Drawing.Size(66, 50);
            this.armor2.TabIndex = 4;
            this.armor2.Text = "label1";
            this.armor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patronCount1
            // 
            this.patronCount1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.patronCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronCount1.Location = new System.Drawing.Point(426, 842);
            this.patronCount1.Name = "patronCount1";
            this.patronCount1.Size = new System.Drawing.Size(66, 50);
            this.patronCount1.TabIndex = 5;
            this.patronCount1.Text = "10";
            this.patronCount1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.patronCount1.Click += new System.EventHandler(this.patronCount1_Click);
            // 
            // patronCount2
            // 
            this.patronCount2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.patronCount2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patronCount2.Location = new System.Drawing.Point(1241, 842);
            this.patronCount2.Name = "patronCount2";
            this.patronCount2.Size = new System.Drawing.Size(66, 50);
            this.patronCount2.TabIndex = 6;
            this.patronCount2.Text = "10";
            this.patronCount2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // points1
            // 
            this.points1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.points1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.points1.Location = new System.Drawing.Point(542, 842);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(66, 50);
            this.points1.TabIndex = 7;
            this.points1.Text = "label1";
            this.points1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // points2
            // 
            this.points2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.points2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.points2.Location = new System.Drawing.Point(1357, 842);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(66, 50);
            this.points2.TabIndex = 8;
            this.points2.Text = "label1";
            this.points2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(26, 841);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "Игрок1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(841, 841);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 48);
            this.label2.TabIndex = 10;
            this.label2.Text = "Игрок2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.pictureBox1.Location = new System.Drawing.Point(150, 851);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.pictureBox2.Location = new System.Drawing.Point(965, 851);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 34);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // armor3
            // 
            this.armor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.armor3.Location = new System.Drawing.Point(266, 851);
            this.armor3.Name = "armor3";
            this.armor3.Size = new System.Drawing.Size(38, 34);
            this.armor3.TabIndex = 13;
            this.armor3.TabStop = false;
            // 
            // patron1
            // 
            this.patron1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.patron1.Location = new System.Drawing.Point(382, 851);
            this.patron1.Name = "patron1";
            this.patron1.Size = new System.Drawing.Size(38, 34);
            this.patron1.TabIndex = 14;
            this.patron1.TabStop = false;
            // 
            // points
            // 
            this.points.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.points.Location = new System.Drawing.Point(498, 853);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(38, 34);
            this.points.TabIndex = 15;
            this.points.TabStop = false;
            // 
            // armor
            // 
            this.armor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.armor.Location = new System.Drawing.Point(1081, 851);
            this.armor.Name = "armor";
            this.armor.Size = new System.Drawing.Size(38, 34);
            this.armor.TabIndex = 16;
            this.armor.TabStop = false;
            // 
            // patron2
            // 
            this.patron2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.patron2.Location = new System.Drawing.Point(1197, 853);
            this.patron2.Name = "patron2";
            this.patron2.Size = new System.Drawing.Size(38, 34);
            this.patron2.TabIndex = 17;
            this.patron2.TabStop = false;
            // 
            // pointsA
            // 
            this.pointsA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(176)))), ((int)(((byte)(235)))));
            this.pointsA.Location = new System.Drawing.Point(1313, 853);
            this.pointsA.Name = "pointsA";
            this.pointsA.Size = new System.Drawing.Size(38, 34);
            this.pointsA.TabIndex = 18;
            this.pointsA.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 900);
            this.Controls.Add(this.pointsA);
            this.Controls.Add(this.patron2);
            this.Controls.Add(this.armor);
            this.Controls.Add(this.points);
            this.Controls.Add(this.patron1);
            this.Controls.Add(this.armor3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patron1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.points)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patron2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsA)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox armor3;
        private System.Windows.Forms.PictureBox patron1;
        private System.Windows.Forms.PictureBox points;
        private System.Windows.Forms.PictureBox armor;
        private System.Windows.Forms.PictureBox patron2;
        private System.Windows.Forms.PictureBox pointsA;
    }
}

