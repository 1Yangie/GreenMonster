using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;

namespace Game
{
    public partial class Form1 : Form
    {
        Image FonImg;
        Image AntImg1;
        Image AntImg2;
        Image AntImg3;
        Image Frog1Img;
        Image Frog2Img;
        Image Frog3Img;
        Image Frog4Img;
        Image Frog5Img;
        Image Frog_eat4;
        
        public Form1()
        {
            InitializeComponent();
        }
        Rectangle r1;
        Rectangle r2;
        Rectangle r3;
        Rectangle r4;
        Rectangle r5;
        Rectangle r6;
        Rectangle r7;
        Rectangle r8;
        Rectangle r1Frog;
        Rectangle r1Frog_2;
        Rectangle[] rectangle;
        string storona = "";
        private int positionFrogX = 20;
        private int positionFrogY = 125;
        private double positionAntY = 200;
        int boost = 0;
        int interval_minute = 1;
        int interval_second = 15;
        int Ants = 8;
        public void MoveFrog()
        {
            if (Convert.ToInt32(split[1]) >= interval_minute)
            {
                if (labelDIFF.Text == "3")
                {
                    boost += 50;
                    interval_minute++;
                }
                else if (labelDIFF.Text == "2")
                {
                    boost += 25;
                    interval_minute++;
                }
                if (labelDIFF.Text == "1")
                {
                    boost += 20;
                    interval_minute++;
                }
            }
            else if (Convert.ToInt32(split[2]) >= interval_second)
            {
                if (labelDIFF.Text == "3")
                {
                    boost += 50;
                    interval_second += 15;
                }
                else if (labelDIFF.Text == "2")
                {
                    boost += 25;
                    interval_second += 15;
                }
                if (labelDIFF.Text == "1")
                {
                    boost += 20;
                    interval_second += 20;
                }
            }     
                if (frogX[0] < -400)
                {
                    
                    Random posFrog = new Random();          //КООРДИНАТЫЫ И РАЗМЕРЫ лягушек
                    frogX = new int[1];
                    for (int i = 0; i < frogX.Length; i++)
                    {
                        frogX[i] = posFrog.Next(1850, 1900);
                    }

                    frogY = new int[1];
                    for (int i = 0; i < frogY.Length; i++)
                    {
                        frogY[i] = posFrog.Next(-150, 650);
                    }
                    frogY[0] += positionFrogY;
                    r1Frog = new Rectangle(frogX[0], frogY[0] + 30, 350, 300);
                    frogX[0] -= (positionFrogX + boost);
                    r1Frog_2 = new Rectangle(frogX[0], frogY[0], 450, 400);
                    frogY[0] -= positionFrogY;
                }
                else
                {
                    frogY[0] += positionFrogY;
                    r1Frog = new Rectangle(frogX[0], frogY[0] + 30, 350, 300);
                    frogY[0] -= positionFrogY;
                    r1Frog_2 = new Rectangle(frogX[0], frogY[0], 450, 400);
                    frogX[0] -= (positionFrogX + boost);
                }    
        }
        bool IsKeyDown = false;
        public void Array(ref Rectangle[] rectangle, int index)
        {
            massX[index] += 100000000;
            massY[index] += 100000000; 
            IsKeyDown = false;
            if (Ants <= 3)
            {
                if (Ants == 3)
                {
                    label2.Font = new Font(label2.Font.Name, 10, label2.Font.Style);
                    label2.Location = new Point(1852, 118);
                    label2.ForeColor = Color.ForestGreen;
                    label2.Text = Ants.ToString();
                }
                else if(Ants == 2)
                {
                    label2.Font = new Font(label2.Font.Name, 20, label2.Font.Style);
                    label2.Location = new Point(1845, 107);
                    label2.ForeColor = Color.Orange;
                    label2.Text = Ants.ToString();
                }
                else if (Ants == 1)
                {
                    label2.Font = new Font(label2.Font.Name, 22, label2.Font.Style);
                    label2.Location = new Point(1842, 105);
                    label2.ForeColor = Color.Red;
                    label2.Text = Ants.ToString();                 
                }
            
            }
            Rectangle[] newRectangle = new Rectangle[rectangle.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newRectangle[i] = rectangle[i];
            }
            for (int i = index + 1; i < rectangle.Length; i++)
            {
                newRectangle[i - 1] = rectangle[i];
            }
            rectangle = newRectangle;            
        }
        int index;
        bool IsAte = false;
        public void MoveAnt()
        {           
            if (!IsAte)
            {
                rectangle = new Rectangle[8] { r1, r2, r3, r4, r5, r6, r7, r8 };
            }           
            r1 = new Rectangle(massX[0], massY[0], massSize[0], massSize[0]);
                r2 = new Rectangle(massX[1], massY[1], massSize[1], massSize[1]);
                r3 = new Rectangle(massX[2], massY[2], massSize[2], massSize[2]);
                r4 = new Rectangle(massX[3], massY[3], massSize[3], massSize[3]);
                r5 = new Rectangle(massX[4], massY[4], massSize[4], massSize[4]);
                r6 = new Rectangle(massX[5], massY[5], massSize[5], massSize[5]);
                r7 = new Rectangle(massX[6], massY[6], massSize[6], massSize[6]);
                r8 = new Rectangle(massX[7], massY[7], massSize[7], massSize[7]);
                positionAntY = 200;
            for (int i = 0; i < rectangle.Length; i++)
            {
                if (storona == "Up")
                {
                    bg.Graphics.Clear(BackColor);
                    if (massY[i] > 80)
                        rectangle[i] = new Rectangle(massX[i], massY[i] -= (int)Math.Round(Math.Sqrt(positionAntY)), massSize[i], massSize[i]);
                }
                if (storona == "Left")
                {
                    bg.Graphics.Clear(BackColor);
                    if (massX[i] > 20)
                        rectangle[i] = new Rectangle(massX[i] -= (int)Math.Round(Math.Sqrt(positionAntY)), massY[i], massSize[i], massSize[i]);
                }
                if (storona == "Right")
                {
                    bg.Graphics.Clear(BackColor);
                    if (massX[i] < 1600)
                        rectangle[i] = new Rectangle(massX[i] += (int)Math.Round(Math.Sqrt(positionAntY)), massY[i], massSize[i], massSize[i]);
                }
                if (storona == "Space")
                {
                    rectangle[i] = new Rectangle(massX[i], massY[i], massSize[i], massSize[i]);
                    IsKeyDown = false;
                }
                if (storona == "Down")
                {
                    bg.Graphics.Clear(BackColor);
                    if (massY[i] < 850)
                        rectangle[i] = new Rectangle(massX[i], massY[i] += (int)Math.Round(Math.Sqrt(positionAntY)), massSize[i], massSize[i]);
                }
                if (positionAntY <= 1700)
                {
                    positionAntY *= 2;
                }
                else
                {
                    positionAntY /= 5;
                }
                if (storona == "Up" || storona == "Down" || storona == "Right" || storona == "Left")
                {
                    IsKeyDown = true;
                }               
            }

            for (int i = 0; i < rectangle.Length; i++)                                                                                                                                                                                              //Y
            {              
                    if (((massX[i] + 10 <= frogX[0] + 80 && massX[i] + massSize[i] - 10 >= frogX[0] + 80) || (massX[i] - 10 + massSize[i] <= frogX[0] + 80 + 400 && massX[i] + 10 >= frogX[0] + 80) || (massX[i] + 10 >= frogX[0] + 80 && massX[i] <= frogX[0] + 400 - 80)) && ((massY[i] + 10 + massSize[i] >= frogY[0] + 40 && massY[i] + 10 + massSize[i] <= frogY[0] + 350) || (massY[i] + 10 >= frogY[0] + 20 && massY[i] + 10 <= frogY[0] +350) || (massY[i] + 10 + massSize[i] >= frogY[0] + 40 && massY[i] + 10 + massSize[i] <= frogY[0] + 350)))
                    {
                        index = i;
                        IsAte = true;
                        bg.Graphics.Clear(BackColor);
                        bg.Graphics.DrawImage(Game.Properties.Resources.box, rectangle[i], 50, 100, 600, 500, GraphicsUnit.Pixel);

                        if (Ants != 0)
                        {
                            Ants -= 1;
                            label2.Text = Ants.ToString();
                        }
                        else
                            label2.Text = Ants.ToString();

                        for (int j = 0; j < rectangle.Length; j++)
                        {
                            if (index != j)
                            {
                                rectangle[j] = new Rectangle(massX[j], massY[j], massSize[j], massSize[j]);
                            }
                        }
                        Array(ref rectangle, index);
                    }                             
            }
            End();           
        }
        StreamWriter sw;
        StreamReader sr;
        private void End()                                                                  //ПРОИГРЫШ
        {                     
            if (Ants == 0 && window == true)
            {
                sr = new StreamReader("Records.txt", Encoding.GetEncoding(1251));
                while (!sr.EndOfStream)
                {
                    qst = sr.ReadLine();
                }
                    window = false;
                    timer1.Stop();
                    timer2.Stop();
                    Form3 f3 = new Form3();
                    f3.time2.Text = time.ToString("mm:ss:ff");
                    f3.ShowDialog();
                    this.Close();
                sr.Close();
                
                if (Convert.ToInt32(split[1]) > Convert.ToInt32(qst.Split(':')[0]))
                    {
                        sw = new StreamWriter("Records.txt", false);
                        sw.WriteLine(time.ToString("mm:ss:ff"));
                    sw.Close();
                }
                else if (Convert.ToInt32(split[2]) > Convert.ToInt32(qst.Split(':')[1]))
                    {
                        sw = new StreamWriter("Records.txt", false);
                        sw.WriteLine(time.ToString("mm:ss:ff"));
                        sw.Close();                    
                    }
                                
            }
        }

        int[] massX = new int[8];           //массив координат X муравьев
        int[] massY = new int[8];           //массив координат Y муравьев
        int[] massSize = new int[8];        //массив размеров муравьев
        int[] frogX = new int[1];           //массив координат X лягушки
        int[] frogY = new int[1];           //массив координат Y лягушки
        Graphics g;

        public void Form1_Load(object sender, EventArgs e)                                                  //      LOAD
        {
            label2.Text = Ants.ToString();
            label2.BackColor = Color.White;
            pictureBox1.BackColor = Color.White;
            label2.Location = new Point(1852, 120);
            Window();
            g = CreateGraphics();
            bg = buff.Allocate(CreateGraphics(), ClientRectangle);
            bg.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Random pos = new Random();          //КООРДИНАТЫЫ И РАЗМЕРЫ муравьев
            massX = new int[8];
            for (int i = 0; i < 8; i++)
            {
                massX[i] = pos.Next(300);
            }
            massY = new int[8];
            for (int i = 0; i < 8; i++)
            {
                massY[i] = pos.Next(88, 900);
            }
            Random posFrog = new Random();          //КООРДИНАТЫЫ И РАЗМЕРЫ лягушек
            frogX = new int[1];
            for (int i = 0; i < frogX.Length; i++)
            {
                frogX[i] = posFrog.Next(1800, 1850);
            }

            frogY = new int[1];
            for (int i = 0; i < frogY.Length; i++)
            {
                frogY[i] = posFrog.Next(0, 640);
            }

            Random random_size = new Random();
            massSize = new int[8];
            for (int i = 0; i < 8; i++)
            {
                massSize[i] = pos.Next(90, 120);
            }
            bg = buff.Allocate(CreateGraphics(), ClientRectangle);
            bg.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            AntImg1 = new Bitmap(Game.Properties.Resources.ANT);
            AntImg2 = new Bitmap(Game.Properties.Resources.ANT21);
            AntImg3 = new Bitmap(Game.Properties.Resources.ANT3);
            Frog1Img = new Bitmap(Game.Properties.Resources.frog);
            Frog2Img = new Bitmap(Game.Properties.Resources.frog2);
            Frog3Img = new Bitmap(Game.Properties.Resources.frog3);
            Frog4Img = new Bitmap(Game.Properties.Resources.frog4);
            Frog5Img = new Bitmap(Game.Properties.Resources.frog5);
            Frog_eat4 = new Bitmap(Game.Properties.Resources.frog_eat4);
            FonImg = new Bitmap(Game.Properties.Resources.Background1);
            timer1.Start();
            timer2.Start();
        }
       
        private void Window()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    storona = "Up";

                    break;
                case Keys.Space:
                    storona = "Space";
                    break;
                case Keys.Right:
                    storona = "Right";
                    break;
                case Keys.Left:
                    storona = "Left";
                    break;
                case Keys.Down:
                    storona = "Down";
                    break;

                case Keys.Escape:
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    break;
            }
            MoveAnt();
        }
        bool dir = true;
        BufferedGraphicsContext buff = BufferedGraphicsManager.Current;
        BufferedGraphics bg;
        int num = 0;
        Rectangle fon;
        Rectangle box;
        Rectangle miniAnt;
        bool window = true;
        
        private void timer1_Tick(object sender, EventArgs e)                                               //анимация муравьев и лягушек
        {
            MoveAnt();
            MoveFrog();
            fon = new Rectangle(0, 0, 1956, 1036);
            box = new Rectangle(1800, 25, 210, 150);
            miniAnt = new Rectangle(1840, 45, 100, 100);
          Random monsters_r = new Random();
            timer1.Interval = 70;
            bg = buff.Allocate(CreateGraphics(), ClientRectangle);
            bg.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            bg.Graphics.Clear(BackColor);
            num++;

            if (dir)
            {
                if (num == 1)
                {
                    bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);
                    if (IsAte == true)
                    {              
                            bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);                     
                        IsAte = false;
                    }


                    else
                    {
                            bg.Graphics.DrawImage(Frog1Img, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);
                    }

                    if (IsKeyDown)
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        
                    }
                    else
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        
                    }
                }
                else if (num == 2)
                {
                    bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);


                    if (IsAte == true)
                    {
                       
                            bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);
                       
                        IsAte = false;
                    }

                    else
                    {                    
                            bg.Graphics.DrawImage(Frog2Img, r1Frog_2, 5, 10, 1300, 1000, GraphicsUnit.Pixel);                      
                    }

                    if (IsKeyDown)
                    {
                        bg.Graphics.DrawImage(AntImg2, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        
                    }
                    else
                    {
                 bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                      
                    }

                }
                else if (num == 3)
                {
                    bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);

                    if (IsAte == true)
                    {                      
                            bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);                      
                        IsAte = false;
                    }

                    else
                    {                       
                            bg.Graphics.DrawImage(Frog3Img, r1Frog_2, 5, 10, 1300, 1000, GraphicsUnit.Pixel);                      
                    }
                    if (IsKeyDown)
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                      
                    }
                    else
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);                       
                    }
                }
                else if (num == 4)
                {
                    bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);
                    if (IsAte == true)
                    {                     
                            bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);                    
                        IsAte = false;
                    }
                    else
                    {
                            bg.Graphics.DrawImage(Frog4Img, r1Frog_2, 5, 10, 1300, 1000, GraphicsUnit.Pixel);
                    }
                    if (IsKeyDown)
                    {
                        bg.Graphics.DrawImage(AntImg3, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg3, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        
                    }
                    else
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);                     
                    }
                }
                else if (num == 5)
                {
                    bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);
                    

                    if (IsAte == true)
                    {                       
                            bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);                       
                        IsAte = false;
                    }


                    else { 
                    
                        bg.Graphics.DrawImage(Frog5Img, r1Frog_2, 5, 10, 1280, 1000, GraphicsUnit.Pixel);
                   
                    }
                    if (IsKeyDown)
                    {
                        bg.Graphics.DrawImage(AntImg2, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg2, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                      
                    }
                    else
                    {
                        bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                        bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);

                    }
                }
                else dir = false;
                if (dir)
                {
                    bg.Render();
                }
            }
            else
            {
                num = 0;
                bg.Graphics.DrawImage(FonImg, fon, 0, 0, 1900, 1000, GraphicsUnit.Pixel);
                if (IsAte == true)
                {                    
                        bg.Graphics.DrawImage(Frog_eat4, r1Frog, 50, 150, 1000, 700, GraphicsUnit.Pixel);                   
                    IsAte = false;
                }
                else
                {
                   
                        bg.Graphics.DrawImage(Frog1Img, r1Frog, 100, 50, 1000, 700, GraphicsUnit.Pixel);
                   
                };
                if (IsKeyDown)
                {
                    bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    
                }
                else
                {
                    bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
                    bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
                  
                }
                dir = true;
                bg.Render();
            }

            timer2.Interval = 1;                     
        }
        
        DateTime time = new DateTime(0, 0);
        string[] split = new string[3];
        string qst = "";
        private void timer2_Tick(object sender, EventArgs e)                                        //ВРЕМЯ                             
        {
            time = time.AddMilliseconds(20);
            
            label1.Text = time.ToString("mm:ss:ff");

            split = time.ToString().Split(':');          
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void продолжитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            timer2.Enabled = !timer2.Enabled;

        }

        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            interval_second = 15;
            interval_minute = 1;
            boost = 0;
            frogX[0] = positionFrogX;
            frogY[0] = positionFrogY;
            label2.Font = new Font(label2.Font.Name, 8, label2.Font.Style);
            label2.Location = new Point(1852, 120);
            label2.ForeColor = Color.Black;
            label2.Text = Ants.ToString();
            Rectangle[] rectangle = new Rectangle[8] { r1, r2, r3, r4, r5, r6, r7, r8 };
                IsAte = false;
                r1 = new Rectangle(massX[0], massY[0], massSize[0], massSize[0]);
                r2 = new Rectangle(massX[1], massY[1], massSize[1], massSize[1]);
                r3 = new Rectangle(massX[2], massY[2], massSize[2], massSize[2]);
                r4 = new Rectangle(massX[3], massY[3], massSize[3], massSize[3]);
                r5 = new Rectangle(massX[4], massY[4], massSize[4], massSize[4]);
                r6 = new Rectangle(massX[5], massY[5], massSize[5], massSize[5]);
                r7 = new Rectangle(massX[6], massY[6], massSize[6], massSize[6]);
                r8 = new Rectangle(massX[7], massY[7], massSize[7], massSize[7]);
            Ants = 8;
            label2.Text = Ants.ToString();

            positionAntY = 200;
            Random pos = new Random();
            massY = new int[8];
            for (int i = 0; i < 8; i++)
            {
                massY[i] = pos.Next(88, 900);
            }
            massX = new int[8];
            for (int i = 0; i < 8; i++)
            {
                massX[i] = pos.Next(300);
            }
            Random posFrog = new Random();          //КООРДИНАТЫЫ И РАЗМЕРЫ лягушек
            frogX = new int[1];
            for (int i = 0; i < frogX.Length; i++)
            {
                frogX[i] = posFrog.Next(1300, 1350);
            }
            frogY = new int[1];
            for (int i = 0; i < frogY.Length; i++)
            {
                frogY[i] = posFrog.Next(88, 700);
            }
         bg.Graphics.DrawImage(AntImg1, r1, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r2, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r3, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r4, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r5, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r6, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r7, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(AntImg1, r8, 50, 100, 600, 500, GraphicsUnit.Pixel);
            bg.Graphics.DrawImage(Frog1Img, r1Frog, 100, 50, 1000, 700, GraphicsUnit.Pixel);      
            storona = "";
            IsKeyDown = false;
            timer1.Start();
            timer2.Start();
            time = new DateTime(0, 0);
            bg.Render();
        }  
    }
}


    


