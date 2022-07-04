
namespace Game
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продолжитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьЗановоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDIFF = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.паузаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1900, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.продолжитьToolStripMenuItem,
            this.начатьЗановоToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.паузаToolStripMenuItem.Text = "Пауза";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // продолжитьToolStripMenuItem
            // 
            this.продолжитьToolStripMenuItem.Name = "продолжитьToolStripMenuItem";
            this.продолжитьToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.продолжитьToolStripMenuItem.Text = "Продолжить";
            this.продолжитьToolStripMenuItem.Click += new System.EventHandler(this.продолжитьToolStripMenuItem_Click);
            // 
            // начатьЗановоToolStripMenuItem
            // 
            this.начатьЗановоToolStripMenuItem.Name = "начатьЗановоToolStripMenuItem";
            this.начатьЗановоToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.начатьЗановоToolStripMenuItem.Text = "Начать заново";
            this.начатьЗановоToolStripMenuItem.Click += new System.EventHandler(this.начатьЗановоToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.выйтиToolStripMenuItem.Text = "Выход";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(758, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(1862, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Game.Properties.Resources.ANT;
            this.pictureBox1.Location = new System.Drawing.Point(1800, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelDIFF
            // 
            this.labelDIFF.AutoSize = true;
            this.labelDIFF.Location = new System.Drawing.Point(393, 0);
            this.labelDIFF.Name = "labelDIFF";
            this.labelDIFF.Size = new System.Drawing.Size(13, 13);
            this.labelDIFF.TabIndex = 5;
            this.labelDIFF.Text = "0";
            this.labelDIFF.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1900, 461);
            this.Controls.Add(this.labelDIFF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продолжитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьЗановоToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelDIFF;
    }
}

