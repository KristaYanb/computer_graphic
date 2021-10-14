//параллельная
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace LABA3
{
    public partial class Form1 : Form
    {
        Point3DCollection points1 = new Point3DCollection(); //коллекц точек в мировой СК
        Matrix3D Matrix = new Matrix3D(); //матр преобразов (умнож на нее для перевода в экранные коорд)
        Point3DCollection points2 = new Point3DCollection(); //коллекц точек в экранной СК
        Pen penGreen = new Pen(new SolidBrush(Color.Green), 3.00f); //нижн осн
        Pen penBlack = new Pen(new SolidBrush(Color.Black), 3.00f); //верхн осн
        Pen penViolet = new Pen(new SolidBrush(Color.BlueViolet), 3.00f); //грани
        double fi = 2 * Math.PI; //угол φи
        double teta = 0; //угол тета
        int n = 0; //кол-во граней
        int r = 0; //радиус осн
        int h = 0; //высота

        Matrix3D GetViewMatrix(double Teta, double Fi, double r)
        {
            var SinFi = Math.Sin(Fi);
            var CosFi = Math.Cos(Fi);
            var SinTeta = Math.Sin(Teta);
            var CosTeta = Math.Cos(Teta);

            var Resultat = new Matrix3D();
            Resultat.SetIdentity();

            Resultat.M11 = SinTeta * CosFi;
            Resultat.M12 = -SinFi;
            Resultat.M13 = -CosTeta * CosFi;

            Resultat.M21 = CosTeta;
            Resultat.M22 = 0;
            Resultat.M23 = SinTeta;

            Resultat.M31 = SinTeta * SinFi;
            Resultat.M32 = CosFi;
            Resultat.M33 = -CosTeta * SinFi;

            return Resultat;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) //верхн осн-черн, нижнее-зел, грани n-гранной призмы-фиол
        { 
            int s1 = 600; //по x
            int s2 = 150; //по y
            if (points2.Count > 0)
            {
                for (int i = 0; i <= n - 2; i++) //нижн осн
                {
                    e.Graphics.DrawLine(penGreen, (float)points2[i].X + s1, (float)points2[i].Y + s2, (float)points2[i + 1].X + s1, (float)points2[i + 1].Y + s2);
                }
                for (int i = n; i <= (2 * n - 2); i++) //верхн осн
                {
                    e.Graphics.DrawLine(penBlack, (float)points2[i].X + s1, (float)points2[i].Y + s2, (float)points2[i + 1].X + s1, (float)points2[i + 1].Y + s2);
                }
                e.Graphics.DrawLine(penGreen, (float)points2[n - 1].X + s1, (float)points2[n - 1].Y + s2, (float)points2[0].X + s1, (float)points2[0].Y + s2); //посл сторона нижн осн
                e.Graphics.DrawLine(penBlack, (float)points2[2 * n - 1].X + s1, (float)points2[2 * n - 1].Y + s2, (float)points2[n].X + s1, (float)points2[n].Y + s2); //посл сторона верхн осн

                for (int i = 0; i <= n - 1; i++) //грани
                {
                    e.Graphics.DrawLine(penViolet, (float)points2[i].X + s1, (float)points2[i].Y + s2, (float)points2[i + n].X + s1, (float)points2[i + n].Y + s2);
                }
            }
        }

        private void Standart_Click(object sender, EventArgs e) //заполн станд парам
        {
            Radius.Text = Convert.ToString(50);
            number.Text = Convert.ToString(10);
            height.Text = Convert.ToString(100);
            Fi.Text = Convert.ToString(60);
            Teta.Text = Convert.ToString(60);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            if (Radius.Text == String.Empty || number.Text == String.Empty || height.Text == String.Empty || Fi.Text == String.Empty || Teta.Text == String.Empty)
            {
                MessageBox.Show("Заполните пустые поля!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invalidate();
                points1.Clear();
                points2.Clear();
                r = (Convert.ToInt32(Radius.Text));
                n = (Convert.ToInt32(number.Text));
                h = (Convert.ToInt32(height.Text));
                fi = (Convert.ToInt32(Fi.Text)) * Math.PI / 180;
                teta = (Convert.ToInt32(Teta.Text)) * Math.PI / 180;

                double angle = 2 * Math.PI / n; //создание n-гранника в мировой СК (добавл эл-тов в коллекцию точек)

                for (int i = 0; i < n; i++) //нижн осн
                {
                    points1.Add(new Point3D(Math.Cos(angle * i) * r, Math.Sin(angle * i) * r, 0));
                }

                for (int i = n; i < 2 * n; i++) //верхн осн
                {
                    points1.Add(new Point3D(Math.Cos(angle * (i - n)) * r, Math.Sin(angle * (i - n)) * r, h));

                }
                //timer1.Enabled = true;
                CalculateCoords();
            }
        }
        /*private void timer1_Tick(object sender, EventArgs e) //таймер
        {
            Matrix = GetViewMatrix(f, t, 1.00);

            points2.Clear();

            foreach (var P in points1) //вект-строка (кажд коорд точки)
            {
                points2.Add(P * Matrix); //умнож на матр перехода; рез-т в коллекцию точек
                Invalidate(); //рисуем ее
            }
        }*/
        private void CalculateCoords() //считаем коорд в экр СК
        {
            Matrix = GetViewMatrix(fi, teta, 1.00);

            points2.Clear();

            foreach (var P in points1) //вект-строка (кажд коорд точки)
            {
                points2.Add(P * Matrix); //умнож на матр перехода; рез-т в коллекцию точек
            }
        }
        private void Radius_TextChanged(object sender, EventArgs e) //заполняем радиус
        {
            if (!(Radius.Text == String.Empty))
            {
                try
                {
                    int s = Convert.ToInt32(Radius.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Введите цифрy, а не символ!");
                    Radius.Clear();
                }
            }
            if (!(Radius.Text == String.Empty))
            {
                int s = Convert.ToInt32(Radius.Text);
                if (s > 100 || s <= 0)
                {
                    MessageBox.Show("Введите целое число от 1 до 100!");
                    Radius.Clear();
                }
            }
        }

        private void number_TextChanged(object sender, EventArgs e) //заполняем кол-во граней
        {
            if (!(number.Text == String.Empty))
            {
                try
                {
                    int s = Convert.ToInt32(number.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Введите цифрy, а не символ!");
                    number.Clear();
                }
            }
            if (!(number.Text == String.Empty))
            {
                int s = Convert.ToInt32(number.Text);
                if (s > 100 || s <= 0)
                {
                    MessageBox.Show("Введите целое число от 1 до 100!");
                    number.Clear();
                }
            }
        }

        private void height_TextChanged(object sender, EventArgs e) //заполняем высоту
        {
            if (!(height.Text == String.Empty))
            {
                try
                {
                    int s = Convert.ToInt32(height.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Введите цифрy, а не символ!");
                    height.Clear();
                }
            }
            if (!(height.Text == String.Empty))
            {
                int s = Convert.ToInt32(height.Text);
                if (s > 600 || s <= 0)
                {
                    MessageBox.Show("Введите целое число от 1 до 600!");
                    height.Clear();
                }
            }
        }

        private void Minus_Click(object sender, EventArgs e) //уменьш угла фи
        {
            if (!(Fi.Text == String.Empty))
            {
                if (fi > 0)
                {
                    fi = (180 * fi / Math.PI - 1) * Math.PI / 180;
                    Fi.Text = Convert.ToString(Convert.ToInt32(Fi.Text) - 1);
                    Invalidate();
                    points2.Clear();
                    CalculateCoords();
                }
                else
                {
                    MessageBox.Show("Угол минимальный");
                }
            }
        }

        private void Plus_Click(object sender, EventArgs e) //увелич угла фи
        {
            if (!(Fi.Text == String.Empty))
            {
                if (fi < 2 * Math.PI)
                {
                    fi = (180 * fi / Math.PI + 1) * Math.PI / 180;
                    Fi.Text = Convert.ToString(Convert.ToInt32(Fi.Text) + 1);
                    Invalidate();
                    points2.Clear();
                    CalculateCoords();
                }
                else
                {
                    MessageBox.Show("Угол максимальный");
                }
            }
        }

        private void munisT_Click(object sender, EventArgs e) //уменьш угла тета
        {
            if (!(Teta.Text == String.Empty))
            {
                if (teta > 0)
                {
                    teta = (180 * teta / Math.PI - 1) * Math.PI / 180;
                    Teta.Text = Convert.ToString(Convert.ToInt32(Teta.Text) - 1);
                    Invalidate();
                    points2.Clear();
                    CalculateCoords();
                }
                else
                {
                    MessageBox.Show("Угол минимальный");
                }
            }
        }

        private void plusT_Click(object sender, EventArgs e) //увелич угла фи
        {
            if (!(Teta.Text == String.Empty))
            {
                if (teta < 2 * Math.PI)
                {
                    teta = (180 * teta / Math.PI + 1) * Math.PI / 180;
                    Teta.Text = Convert.ToString(Convert.ToInt32(Teta.Text) + 1);
                    Invalidate();
                    points2.Clear();
                    CalculateCoords();
                }
                else
                {
                    MessageBox.Show("Угол максимальный");
                }
            }
        }

        private void Teta_TextChanged_1(object sender, EventArgs e)  //заполняем угол тета
        {
            if (!(Teta.Text == String.Empty))
            {
                try
                {
                    int s = Convert.ToInt32(Teta.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Введите цифрy, а не символ!");
                    Teta.Clear();
                }

            }
            if (!(Teta.Text == String.Empty))
            {
                int s = Convert.ToInt32(Teta.Text);
                if (s > 360 || s < 0)
                {
                    MessageBox.Show("Введите целое число от 0 до 360!");
                    Fi.Clear();
                }
            }
        }

        private void Fi_TextChanged(object sender, EventArgs e) //заполняем угол фи
        {
            if (!(Fi.Text == String.Empty))
            {
                try
                {
                    int s = Convert.ToInt32(Fi.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Введите цифрy, а не символ!");
                    Fi.Clear();
                }
            }

            if (!(Fi.Text == String.Empty))
            {
                int s = Convert.ToInt32(Fi.Text);
                if (s > 360 || s < 0)
                {
                    MessageBox.Show("Введите целое число от 0 до 360!");
                    Fi.Clear();
                }
            }
        }
    }
}
