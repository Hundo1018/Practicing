using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null, null);
        }
        Range Range;
        double u, a2;
        double STRE;
        double bei = 10;
        int fix = 32;
        private void button1_Click(object sender, EventArgs e)
        {

            Range = new Range(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
            u = double.Parse(textBox3.Text) /* /** (panel1.Width/(Range.Max-Range.Min))*/;
            a2 = double.Parse(textBox4.Text)  /** (panel1.Width / (Range.Max - Range.Min))*/;
            Bitmap BMP = new Bitmap(panel1.Width, panel1.Height);
            Graphics G = Graphics.FromImage(BMP);
            Pen Pe = new Pen(Color.Black, 1f);
            List<Pointd> pli = new List<Pointd>();

            G.DrawLine(Pe, new Point(fix, 0), new Point(fix, panel1.Height));
            G.DrawLine(Pe, new Point(0, panel1.Height - fix), new Point(panel1.Width, panel1.Height - fix));

            STRE = panel1.Width / (Range.Max - Range.Min);


            G.TranslateTransform(/*panel1.Width / 2*/0, panel1.Height / 2);


            for (double i = 0; i <= STRE; i++)
            {
                double tempy = -P(Range.Min + i * ((Range.Max - Range.Min) / STRE)) * bei;
                pli.Add(new Pointd((int)i, tempy));
            }


            for (int i = 0; i < pli.Count - 1; i++)
            {
                G.DrawLine(Pe,
                    (((float)pli[i].X * BMP.Width / (float)STRE) + (float)fix),
                    (((float)pli[i].Y * BMP.Width / (float)STRE)),
                    (((float)pli[i + 1].X * BMP.Width / (float)STRE) + (float)fix),
                    (((float)pli[i + 1].Y * BMP.Width / (float)STRE)));
            }

            panel1.BackgroundImage = BMP;
        }
        double P(double x)
        {
            double temp = (1d / (Math.Sqrt(2d * Math.PI) * a2) * Math.Exp(-1d * Math.Pow((x - u), 2d) / (2d * a2)));

            return temp;
        }
    }
    class Pointd
    {
        public double X, Y;
        public Pointd(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    class Range
    {
        public double Min, Max;
        public Range(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}
