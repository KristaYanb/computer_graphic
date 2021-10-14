using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace L2
{
    public partial class Form1 : Form
    {
        int x = 30;  //НК центра колеса1
        Point wheel1; //центр заднего колеса
        Point wheel2; //центр переднего колеса
        Point chair;  //центр сидушки
        Point pedal;  //центр педалей
        Point rudder; //центр руля

        Point[] pointsWheel1 = new Point[8]; //точки основания заднего колеса (8шт)
        Point[] pointsWheel2 = new Point[8]; //точки основания переднего колеса (8шт)
        float corner; //угол поворота
        public Form1()
        {
          InitializeComponent();
        }
        void Draw(Graphics gr) //ф-ия, рисующая колесо по коорд центра
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;

            float[] dashValues = { 5, 2 };  //рисование дорожки пунктиром
            Pen greenPen = new Pen(Color.Green, 3);
            greenPen.DashPattern = dashValues;
            gr.DrawLine(greenPen, new Point(0, 200), new Point(590, 200));

            wheel1.X = x; //НК колеса1 = НК центра колеса (30)
            wheel2.X = x + 135; //НК колеса2 = НК центра колеса (30+135)
            chair.X = x + 40; //основание сидушки
            pedal.X = x + 50; //основание педалей
            rudder.X = x + 110; //основание руля
            var r = 30;  //радиус колеса

            using (var p1 = new Pen(Color.Gray, 2)) //ручка для рисования спиц
            {
                for (int i = 0; i < 8; i++)
                {
                    gr.DrawLine(p1, wheel1, pointsWheel1[i]); //рисование спиц1 (8шт)
                    gr.DrawLine(p1, wheel2, pointsWheel2[i]); //рисование спиц2 (8шт)
                }
            }

            using (var p2 = new Pen(Color.Black, 5)) //ручка для рисования колеса
            {
                gr.DrawPolygon(p2, pointsWheel1); //рисование основания колеса1 (восьмиугольник)
                gr.DrawPolygon(p2, pointsWheel2); //рисование основания колеса2 (восьмиугольник)
            }

            for (int i = 0; i < 8; i++) // поворот
            {
                // рассчитываем точки с учетом смещения (движение колеса)
                pointsWheel1[i].X = wheel1.X + (int)Math.Round(Math.Cos(Math.PI * 2.0 * i / 8) * r);
                pointsWheel1[i].Y = wheel1.Y + (int)Math.Round(Math.Sin(Math.PI * 2.0 * i / 8) * r);

                pointsWheel2[i].X = wheel2.X + (int)Math.Round(Math.Cos(Math.PI * 2.0 * i / 8) * r);
                pointsWheel2[i].Y = wheel2.Y + (int)Math.Round(Math.Sin(Math.PI * 2.0 * i / 8) * r);
                //Console.WriteLine("X1 = {0}, Y1 = {1}, X2 = {2}, Y2 = {3}", pointsWheel1[i].X, pointsWheel1[i].Y, pointsWheel2[i].X, pointsWheel2[i].Y);
                // рассчитываем поворот
                double xt = wheel1.X + (pointsWheel1[i].X - wheel1.X) * Math.Cos(corner * (Math.PI / 180)) + (wheel1.Y - pointsWheel1[i].Y) * Math.Sin(corner * (Math.PI / 180));
                double yt = wheel1.Y + (pointsWheel1[i].X - wheel1.X) * Math.Sin(corner * (Math.PI / 180)) + (pointsWheel1[i].Y - wheel1.Y) * Math.Cos(corner * (Math.PI / 180));
                pointsWheel1[i].X = Convert.ToInt32(xt);
                pointsWheel1[i].Y = Convert.ToInt32(yt);

                double xt1 = wheel2.X + (pointsWheel2[i].X - wheel2.X) * Math.Cos(corner * (Math.PI / 180)) + (wheel2.Y - pointsWheel2[i].Y) * Math.Sin(corner * (Math.PI / 180));
                double yt1 = wheel2.Y + (pointsWheel2[i].X - wheel2.X) * Math.Sin(corner * (Math.PI / 180)) + (pointsWheel2[i].Y - wheel2.Y) * Math.Cos(corner * (Math.PI / 180));
                pointsWheel2[i].X = Convert.ToInt32(xt1);
                pointsWheel2[i].Y = Convert.ToInt32(yt1);
                //Console.WriteLine("X1 = {0}, Y1 = {1}, X2 = {2}, Y2 = {3}", pointsWheel1[i].X, pointsWheel1[i].Y, pointsWheel2[i].X, pointsWheel2[i].Y);
            }
            // рама
            using (var pen = new Pen(Color.BlueViolet, 5)) //ручка для рисования рамы
            {
                gr.DrawLine(pen, wheel1.X, wheel1.Y, pedal.X, pedal.Y);     // От заднего колеса к педалям
                gr.DrawLine(pen, wheel1.X, wheel1.Y, rudder.X, rudder.Y);   // От заднего колеса к рулю
                gr.DrawLine(pen, pedal.X, pedal.Y, rudder.X, rudder.Y);     // От педалей к рулю

                gr.DrawLine(pen, pedal.X, pedal.Y, chair.X, chair.Y);       // От педалей к сидушке
                gr.DrawLine(pen, rudder.X, rudder.Y, wheel2.X, wheel2.Y);   // От руля  к переднему колесу

                gr.DrawLine(new Pen(Color.DarkGray, 4), rudder.X, rudder.Y, wheel2.X - 5, wheel2.Y - 55);   // руль
                gr.DrawRectangle(new Pen(Color.DarkGray, 5), chair.X - 10, chair.Y - 5, 20, 2);    //сидушка(прямоуг)
            }

            if (x > 620)       //если вышли за границу окна (вправо)
            {
                x = -195;	       //возврат обратно
            }
            if (x < -195)       //если вышли за границу окна (влево)
            {
                x = 620;	       //возврат обратно
            }
        }
        private void button1_Click(object sender, EventArgs e) // кнопка "старт/пауза"
        {
            timer1.Enabled = !timer1.Enabled;

            if (timer1.Enabled == true)
            {
                button1.Text = "Пауза";
            }
            else
            {
                button1.Text = "Старт";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)	//таймер
        {
            corner += 5f;   // скорость поворота колеса (увеличиваем на 5) (с минусом - в др сторону)
            x += 3;         // движение велосипеда (скорость) (с минусом - в др сторону)
            Invalidate();   // перерисовка
        }
        private void Form1_Paint(object sender, PaintEventArgs e) //задали форму
        {
            var gr = e.Graphics;
            Draw(gr);
        }
        private void Form1_Load(object sender, EventArgs e) //срабатывает при каждой загрузке формы
        {
            // создаем точки для рамы
            wheel1 = new Point(x, 200); //НК колеса1
            wheel2 = new Point(x + 135, 200); //НК колеса2
            chair = new Point(x + 40, 170); //НК сидушки
            pedal = new Point(x + 50, 198); //НК педалей
            rudder = new Point(x + 110, 148); //НК руля

            // точки колес (8шт)
            for (int i = 0; i < 8; i++)
            {
                int r = 30; //радиус колеса
                pointsWheel1[i] = new Point
                (
                    wheel1.X + (int)Math.Round(Math.Cos(Math.PI * 2.0 * i / 8) * r),
                    wheel1.Y + (int)Math.Round(Math.Sin(Math.PI * 2.0 * i / 8) * r)
                );

                pointsWheel2[i] = new Point
                (
                    wheel2.X + (int)Math.Round(Math.Cos(Math.PI * 2.0 * i / 8) * r),
                    wheel2.Y + (int)Math.Round(Math.Sin(Math.PI * 2.0 * i / 8) * r)
                );
                //Console.WriteLine("X1 = {0}, Y1 = {1}, X2 = {2}, Y2 = {3}", pointsWheel1[i].X, pointsWheel1[i].Y, pointsWheel2[i].X, pointsWheel2[i].Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)	//кнопка "стоп"
        {
            x = 0;
        }
    }
}
