using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Color lineColor;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyValue == (char)Keys.Delete) button5_Click(button5, null); };
            KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyValue == (char)Keys.A) button1_Click(button1, null); };
            KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyValue == (char)Keys.B) button2_Click(button2, null); };
            KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyValue == (char)Keys.C) button3_Click(button3, null); };
            KeyDown += (object sender, KeyEventArgs e) => { if (e.KeyValue == (char)Keys.D) button4_Click(button4, null); };
            timer2.Interval = 200;
            lineColor = Color.Black;
        }
        //1 Task
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            DrawPentagon(g);
            DrawSectorOfEllipse(g);
            DrawDiamond(g);
            DrawCube(g);
        }
        static void DrawPentagon(Graphics g)
        {
            Random rnd = new Random();

            var x_0 = rnd.Next(80, 500);
            var y_0 = rnd.Next(40, 200);

            var shape = new PointF[6];

            var r = rnd.Next(30, 50);

            for (int a = 0; a < 5; a++)
            {
                shape[a] = new PointF(
                    x_0 + r * (float)Math.Cos(a * 72 * Math.PI / 180f),
                    y_0 + r * (float)Math.Sin(a * 72 * Math.PI / 180f));
            }
            shape[5] = shape[0];
            g.DrawLines(Pens.Black, shape);
        }
        static void DrawSectorOfEllipse(Graphics g)
        {
            Random rnd = new Random();
            int x = rnd.Next(60, 400);
            int y = rnd.Next(40, 100);
            int width = rnd.Next(100,200);
            int height = rnd.Next(40,120);
            float startAngle = rnd.Next(0,360);
            float sweepAngle = rnd.Next(40, 360);
            g.FillPie(Brushes.Coral, x + width / 2, y + height / 2, width, height, startAngle, sweepAngle);
        }
        static void DrawDiamond(Graphics g)
        {
            Random rnd = new Random();
            
            var sizeOfVertD = rnd.Next(30, 80);
            var sizeOfHorD = rnd.Next(30, 80);
            var x_0 = rnd.Next(80, 500);
            var y_0 = rnd.Next(40, 200);
            var middle_y = y_0 + sizeOfVertD / 2; 
            var y_1 = y_0 + sizeOfVertD;
            var shape = new Point[] {
                new Point(x_0, y_0),
                new Point(x_0 + sizeOfHorD/2, middle_y),
                new Point(x_0, y_1),
                new Point(x_0 - sizeOfHorD/2, middle_y),
                new Point(x_0, y_0)
            };
            g.DrawLines(Pens.DarkBlue, shape);
        }
        static void DrawCube(Graphics g)
        {
            Random rnd = new Random();

            int size = rnd.Next(50, 80);
            int skew = 20;
            Point Org = new Point(rnd.Next(80, 500), rnd.Next(30, 200));
            Rectangle R = new Rectangle(Org.X, Org.Y, size, size);
            Point[] topCube;
            topCube = new Point[]{
                new Point(Org.X, Org.Y),
                new Point(Org.X + skew, Org.Y - skew),
                new Point(Org.X + size + skew, Org.Y - skew),
                new Point(Org.X + size, Org.Y)};
            g.FillPolygon(Brushes.LightGray, topCube);

            Point[] rightCube;
            rightCube = new Point[]{
                new Point(Org.X + size, Org.Y),
                new Point(Org.X + size + skew, Org.Y - skew),
                new Point(Org.X + size + skew, Org.Y + size - skew),
                new Point(Org.X + size , Org.Y + size)};
            g.FillPolygon(Brushes.Black, rightCube);

            g.FillRectangle(Brushes.Gray, R);
        }
        //2 Task
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Random rnd = new Random();
            Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 5);

            int height = 100;
            int width = 70;
            Point Org = new Point(rnd.Next(80, 500), rnd.Next(30, 200));
            Rectangle topPart = new Rectangle(Org.X, Org.Y, width, height);
            g.FillRectangle(Brushes.LightGray, topPart);

            Rectangle titel = new Rectangle(Org.X + 5, Org.Y + 4, 60, 20);
            g.FillRectangle(Brushes.BlueViolet, titel);
            new Point(Org.X + 10, Org.Y + 9);
            Point[] text;
            text = new Point[]{
                new Point(Org.X + 10, Org.Y + 12),
                new Point(Org.X + 60, Org.Y + 12)
            };
            g.DrawLine(pen, text[0], text[1]);

            Rectangle downPart = new Rectangle(Org.X + 5, Org.Y + 29, 60, 60);
            g.FillRectangle(Brushes.Violet, downPart);
            Point[] text_1;
            text_1 = new Point[]{
                new Point(Org.X + 10, Org.Y + 29 + 10),
                new Point(Org.X + 60, Org.Y + 29 + 10)
            };
            g.DrawLines(Pens.Black, text_1);
            Point[] text_2;
            text_2 = new Point[]{
                new Point(Org.X + 10, Org.Y + 29 + 20),
                new Point(Org.X + 60, Org.Y + 29 + 20)
            };
            g.DrawLines(Pens.Black, text_2);
            Point[] text_3;
            text_3 = new Point[]{
                new Point(Org.X + 10, Org.Y + 29 + 30),
                new Point(Org.X + 60, Org.Y + 29 + 30)
            };
            g.DrawLines(Pens.Black, text_3);
        }
        //3 Task

        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private float x3;
        private float y3;
        //private double k;
        //private double b;
        private int step = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Random rnd = new Random();
            x1 = rnd.Next(10, 300);
            x2 = rnd.Next(x1, 400);
            y1 = rnd.Next(10, 150);
            y2 = rnd.Next(10, 200);
            double k = rnd.NextDouble();
            x3 = (float)(x1 + (x2 - x1) * k);
            y3 = (float)(y1 + (y2 - y1) * k);
            //k = (y2 - y1) / (x2 - x1);
            //b = y2 - k * x2;
            //x3 = rnd.Next(x1,x2);
            //y3 = Convert.ToInt32(k * x3 + b);
            timer2.Start();
        
        }
        private int newX1;
        private int newX2;
        private int newY1;
        private int newY2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            lineColor = GetRandomColor();
            
            double angle = step * Math.PI / 100;
            newX1 = (int)((x1-x3) * Math.Cos(angle) - (y1 - y3) * Math.Sin(angle) + x3);
            newX2 = (int)((x2 - x3) * Math.Cos(angle) - (y2 - y3) * Math.Sin(angle) + x3);
            newY1 = (int)((x1 - x3) * Math.Sin(angle) + (y1 - y3) * Math.Cos(angle) + y3);
            newY2 = (int)((x2 - x3) * Math.Sin(angle) + (y2 - y3) * Math.Cos(angle) + y3);
            //x1 = Convert.ToInt32(x3 - Math.Sqrt(length1) + (float)(Math.Cos(angle)));
            //y1 = Convert.ToInt32(y3 - Math.Sqrt(length1) + (float)(Math.Sin(angle)));
            //y1 = Convert.ToInt32(x3 + Math.Sqrt(length2) + (float)(Math.Cos(angle)));
            //y2 = Convert.ToInt32(y3 + Math.Sqrt(length2) + (float)(Math.Sin(angle)));
            g.DrawLine(Pens.Black, x3, y3, x1, y1);
            using (Pen pen = new Pen(lineColor, 5))
            {
                g.DrawLine(pen, newX1, newY1, newX2, newY2);
            }
            
            step++;
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            return color;
        }

        //4 Task
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            Graphics g = CreateGraphics();
            timer1.Start();
        }
        public int x_0_erstesRad = 50;
        public int x_0_zweitesRad = 150;
        public int x_1 = 20;
        public int x_2 = 180;
        public int x_3 = 160;
        public int angle = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            x_0_erstesRad += 5;
            x_0_zweitesRad += 5;
            x_1 += 5;
            x_2 += 5;
            x_3 += 5;
            int height = 50;
            int width = 200;
            Point[] point;
            point = new Point[]
            {
                new Point(x_2, 220),
                new Point(x_3,170)
            };
            g.DrawLine(Pens.Black, point[0], point[1]);
            Rectangle rech = new Rectangle(x_1, 220, width, height);
            g.FillRectangle(Brushes.DarkGray, rech);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(x_0_erstesRad + 20, 250 + 23);
            g.RotateTransform(angle);
            g.FillEllipse(Brushes.Black, -23, -20, 46, 40);

            g.ResetTransform();
            g.TranslateTransform(x_0_zweitesRad + 20, 250 + 23);
            g.RotateTransform(angle);
            g.FillEllipse(Brushes.Black, -23, -20, 46, 40);
            //Rectangle quadrat2 = new Rectangle(x_0 + 100, 250, 40, 50);
            //g.FillEllipse(Brushes.Black, quadrat2);
            Invalidate();
            angle += 7;
            if (x_1 == 350)
            {
                timer1.Stop();
                timer3.Start();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            x_0_erstesRad -= 5;
            x_0_zweitesRad -= 5;
            x_1 -= 5;
            x_2 -= 5;
            x_3 -= 5;
            int height = 50;
            int width = 200;
            Point[] point;
            point = new Point[]
            {
                new Point(x_2, 220),
                new Point(x_3,170)
            };
            g.DrawLine(Pens.Black, point[0], point[1]);
            Rectangle rech = new Rectangle(x_1, 220, width, height);
            g.FillRectangle(Brushes.DarkGray, rech);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TranslateTransform(x_0_erstesRad + 20, 250 + 23);
            g.RotateTransform(angle);
            g.FillEllipse(Brushes.Black, -23, -20, 46, 40);

            g.ResetTransform();
            g.TranslateTransform(x_0_zweitesRad + 20, 250 + 23);
            g.RotateTransform(angle);
            g.FillEllipse(Brushes.Black, -23, -20, 46, 40);
            Invalidate();
            angle -= 7;
            if (x_1 == 20)
            {
                timer3.Stop();
                timer1.Start();
            }
        }
        //Delete
        private void button5_Click(object sender, EventArgs e)
        {
            Invalidate();
            pictureBox1.Visible = false;
            pictureBox1.Invalidate();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }

        
    }
}
