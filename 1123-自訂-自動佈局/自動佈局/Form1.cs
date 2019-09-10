using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自動佈局
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }
        List<Point> PL = new List<Point>();
        List<double> Cost = new List<double>();
        Point Center = new Point();
        Size size = new Size(10, 10);
        List<Bitmap> bmpl = new List<Bitmap>();
        List<Graphics> Gl = new List<Graphics>();
        Bitmap obmp;
        private void button1_Click(object sender, EventArgs e)
        {
            Cost = new List<double>();
            bmpl = new List<Bitmap>();
            Gl = new List<Graphics>();
            PL = new List<Point>();
            PL.Add(new Point(70, 15));
            PL.Add(new Point(30, 60));
            PL.Add(new Point(90, 120));
            PL = new List<Point>();
            for (int i = 0; i < 3; i++)
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                PL.Add(new Point(rdm.Next(0, 200), rdm.Next(0, 200)));
            }
            obmp = new Bitmap(200, 200);
            Graphics G = Graphics.FromImage(obmp);
            Center = new Point((int)PL.Average(x => x.X), (int)PL.Average(x => x.Y));
            for (int i = 0; i < PL.Count; i++)
            {
                G.DrawEllipse(new Pen(Color.Blue, 0.5f), new Rectangle(PL[i].X - size.Width / 2, PL[i].Y - size.Height / 2, size.Width, size.Height));

                G.DrawLine(new Pen(Color.Black, 0.5f), new Point(PL[i].X, Center.Y), new Point(Center.X, Center.Y));//橫
                G.DrawLine(new Pen(Color.Black, 0.5f), new Point(PL[i].X, PL[i].Y), new Point(PL[i].X, Center.Y));//縱
            }
            G.DrawEllipse(new Pen(Color.Red, 0.5f), new Rectangle(Center.X - size.Width / 2, Center.Y - size.Height / 2, size.Width, size.Height));
            for (int i = 0; i <= 7; i++)
            {
                string mode = Convert.ToString(i, 2).PadLeft(3, '0');
                Cost.Add(GetCost(mode));
            }
            pictureBox1.Image = obmp;
            int mini = Cost.IndexOf(Cost.Min());
            pictureBox2.Image = bmpl[mini];

            label1.Text = $"Cost:{Cost[0]}";
            label2.Text = $"Cost:{Cost[mini]}";
            label3.Text = $"{ Cost[mini] / Cost[0] * 100}%";
        }
        double GetCost(string Mode)
        {
            double cost = 0;
            bmpl.Add(new Bitmap(obmp.Width, obmp.Height));
            Gl.Add(Graphics.FromImage(bmpl.Last()));
            Gl.Last().DrawEllipse(new Pen(Color.Red, 0.5f), new Rectangle(Center.X - size.Width / 2, Center.Y - size.Height / 2, size.Width, size.Height));
            for (int i = 0; i < PL.Count; i++)
            {

                Gl.Last().DrawEllipse(new Pen(Color.Blue, 0.5f), new Rectangle(PL[i].X - size.Width / 2, PL[i].Y - size.Height / 2, size.Width, size.Height));

                Point Np = new Point();
                //點到np
                if (Mode[i] == '0')//縱
                {
                    Np = new Point(PL[i].X, Center.Y);
                    Gl.Last().DrawLine(new Pen(Color.Black, 0.5f),
                        PL[i],
                        Np);
                    cost += Math.Abs(Np.Y - PL[i].Y);
                    cost += Math.Abs(Np.X - Center.X);
                }
                else//斜
                {
                    Np = new Point(
                        PL[i].X - (Center.Y - PL[i].Y),
                        Center.Y);
                    Gl.Last().DrawLine(new Pen(Color.Red, 0.5f),
                        Np,
                        PL[i]);
                    cost += Math.Sqrt(Math.Pow((Center.Y - PL[i].Y), 2) + Math.Pow((Center.Y - PL[i].Y), 2));
                    cost += Math.Abs(Np.X - Center.X);
                }
                Gl.Last().DrawEllipse(new Pen(Color.Black, 0.5f), new Rectangle(Np.X - size.Width / 2, Np.Y - size.Height / 2, size.Width, size.Height));

                //橫
                Gl.Last().DrawLine(new Pen(Color.Black, 0.5f), Np, Center);
                //cost += Math.Abs(Np.X - PL[i].X);

                //if (Mode[i] == '0')//用縱橫線
                //{
                //    //cost += Math.Abs(PL[i].X - Center.X) + Math.Abs(PL[i].Y - Center.Y);
                //}
                //else//用斜線
                //{
                //    double temp = Math.Min(Math.Abs(PL[i].X - Center.X), Math.Abs(PL[i].Y - Center.Y));
                //    if (PL[i].X > Center.X)
                //    {
                //        Np = new Point(
                //               (int)(PL[i].X - ((Math.Cos((double)(Center.X - PL[i].X) / 180d * Math.PI)) * temp)),
                //               (int)(PL[i].Y + ((Math.Sin((double)(Center.Y - PL[i].Y) / 180d * Math.PI)) * temp)));
                //    }
                //    else
                //    {
                //        Np = new Point(
                //               (int)(PL[i].X + (float)((Math.Cos((double)(Center.X - PL[i].X) / 180d * Math.PI)) * temp)),
                //               (int)(PL[i].Y + (float)((Math.Sin((double)(Center.Y - PL[i].Y) / 180d * Math.PI)) * temp)));
                //    }
                //    Gl.Last().DrawLine(
                //        new Pen(Color.Black, 0.5f),
                //        PL[i], Np);
                //    cost += Math.Sqrt(Math.Pow(temp, 2) + Math.Pow(temp, 2));
                //}
                //Gl.Last().DrawLine(new Pen(Color.Black, 0.5f), new Point(Np.X, Center.Y), new Point(Center.X, Center.Y));//橫
                //Gl.Last().DrawLine(new Pen(Color.Black, 0.5f), new Point(Np.X, Np.Y), new Point(Np.X, Center.Y));//縱
                //cost += Math.Abs(Np.X - Center.X) + Math.Abs(Np.Y - Center.Y);
            }
            pictureBox2.Image = bmpl.Last();
            return cost;
        }
    }
}
