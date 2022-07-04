using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game
{
    
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = !button4.Visible;
            button5.Visible = !button5.Visible;
            button6.Visible = !button6.Visible;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            StreamReader sr = new StreamReader("Records.txt");
            label1.Text = sr.ReadLine().ToString();
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
        public int difficult;
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.labelDIFF.Text = "1";
            
            
            f1.ShowDialog();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.labelDIFF.Text = "2";
            
            f1.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.labelDIFF.Text = "3";
            
            f1.ShowDialog();
            this.Close();
        }
    }
}
