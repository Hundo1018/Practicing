using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSquare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            colorDialog1.Color = Color.Blue;
            textBox1.Text = "9";
            button1_Click(null, null);
        }



        Pen P = new Pen(Color.Blue, 0.75f);
        Graphics G;
        Bitmap B;





        int N = 9, R = 450 / 3, CenterX = 0, CenterY = 0;
        Point Center = new Point(0, 0);
        private void button1_Click(object sender, EventArgs e)
        {
            N = int.Parse( textBox1.Text);



            B = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(B);
            P = new Pen(colorDialog1.Color, 0.75f);


            G.TranslateTransform(B.Width / 2, B.Height / 2);
            List<Point> PL = new List<Point>();

            for (int i = 1; i <= N; i++)

            {
                int x = Convert.ToInt32(R * Math.Cos(2 * Math.PI * i / N) + CenterX);
                int y = Convert.ToInt32(R * Math.Sin(2 * Math.PI * i / N) + CenterY);
                PL.Add(new Point(x, y));
            }

            for (int i = 0; i < PL.Count; i++)
            {
                for (int j = 0; j < PL.Count; j++)
                {
                    G.DrawLine(P, PL[i], PL[j]);
                }
            }
            pictureBox1.Image = B;
        }
    }
}
