using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriJud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] XY = new double[3, 2];

            XY[0, 0] = double.Parse(textBox1.Text);
            XY[0, 1] = double.Parse(textBox2.Text);
            XY[1, 0] = double.Parse(textBox3.Text);
            XY[1, 1] = double.Parse(textBox4.Text);
            XY[2, 0] = double.Parse(textBox5.Text);
            XY[2, 1] = double.Parse(textBox6.Text);
            double[] ABC = new double[3];
            ABC[0] =Math.Round( Math.Sqrt(Math.Pow(XY[1, 0] - XY[0, 0], 2) + Math.Pow(XY[1, 1] - XY[0, 1], 2)),3);
            ABC[1] = Math.Round( Math.Sqrt(Math.Pow(XY[2, 0] - XY[1, 0], 2) + Math.Pow(XY[2, 1] - XY[1, 1], 2)),3);
            ABC[2] =Math.Round( Math.Sqrt(Math.Pow(XY[0, 0] - XY[2, 0], 2) + Math.Pow(XY[0, 1] - XY[2, 1], 2)),3);
            A_LBL.Text = ABC[0].ToString();
            B_LBL.Text = ABC[1].ToString();
            C_LBL.Text = ABC[2].ToString();
            Array.Sort(ABC);
            if ((XY[0, 0] == XY[1, 0] && XY[0, 1] == XY[1, 1]) ||
                (XY[0, 0] == XY[2, 0] && XY[0, 1] == XY[2, 1]) ||
                (XY[2, 0] == XY[1, 0] && XY[2, 1] == XY[1, 1]))
            {
                ANS_LBL.Text = "有相同點座標";
                return;
            }
            
            
            if (ABC[0] == ABC[1] && ABC[0] == ABC[2])
            {
                ANS_LBL.Text = "此為正三角形";
            }
            else if (ABC[0] == ABC[1] || ABC[0] == ABC[2] || ABC[1] == ABC[2])//有兩邊相等都是等腰
            {
                double fix =Math.Abs( ABC[0] * ABC[0] + ABC[1] * ABC[1] - ABC[2] * ABC[2]);
                if (fix<=1)
                {
                    ANS_LBL.Text = "此為等腰直角三角形";

                }
                else
                {
                    ANS_LBL.Text = "此為等腰三角形";
                }
            }
            else if (ABC[0] * ABC[0] + ABC[1] * ABC[1] == ABC[2] * ABC[2])
            {
                ANS_LBL.Text = "此為直角三角形";
            }
            else if (ABC[0] * ABC[0] + ABC[1] * ABC[1] < ABC[2] * ABC[2])
            {
                ANS_LBL.Text = "此為鈍角三角形";
            }
            else if (ABC[0] * ABC[0] + ABC[1] * ABC[1] > ABC[2] * ABC[2])
            {
                ANS_LBL.Text = "此為銳角三角形";
            }
            else
            {
                ANS_LBL.Text = "此為三點一直線";
            }
        }
    }
}
