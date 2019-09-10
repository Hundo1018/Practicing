using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trijgd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null,null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointD[] PP = new PointD[3];
            PP[0] = new PointD(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
            PP[1] = new PointD(double.Parse(textBox3.Text), double.Parse(textBox4.Text));
            PP[2] = new PointD(double.Parse(textBox5.Text), double.Parse(textBox6.Text));
            
            List<double> Len = new List<double>();
            Len.Add(double.Parse(Math.Sqrt(Math.Pow(PP[0].X - PP[1].X, 2) + Math.Pow(PP[0].Y - PP[1].Y, 2)).ToString("0.000")));
            Len.Add(double.Parse(Math.Sqrt(Math.Pow(PP[1].X - PP[2].X, 2) + Math.Pow(PP[1].Y - PP[2].Y, 2)).ToString("0.000")));
            Len.Add(double.Parse(Math.Sqrt(Math.Pow(PP[0].X - PP[2].X, 2) + Math.Pow(PP[0].Y - PP[2].Y, 2)).ToString("0.000")));
            label1.Text = "座標1~座標2 邊長：" + Len[0].ToString("0.000");
            label2.Text = "座標2~座標3 邊長：" + Len[1].ToString("0.000");
            label3.Text = "座標3~座標1 邊長：" + Len[2].ToString("0.000");

            Len = Len.OrderBy(x=>x).ToList();

            List<double> angg = new List<double>();

            angg.Add(Math.Abs((Math.Atan2(PP[0].Y - PP[1].Y, PP[0].X - PP[1].X) * 180 / Math.PI)));
            angg.Add(Math.Abs((Math.Atan2(PP[0].Y - PP[2].Y, PP[0].X - PP[2].X) * 180 / Math.PI)));
            angg.Add(Math.Abs((Math.Atan2(PP[2].Y - PP[1].Y, PP[2].X - PP[1].X) * 180 / Math.PI)));

            List<double> JJ = new List<double>();
            for (int i = 0; i < 3; i++)//基準點
            {
                List<double> ang = new List<double>();
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        ang.Add(Math.Abs((Math.Atan2(PP[j].Y - PP[i].Y, PP[j].X - PP[i].X) * 180 / Math.PI)));
                    }
                }
                JJ.Add(Math.Abs(ang[1] - ang[0]));
            }
            if (JJ[0] == JJ[1] || JJ[0] == JJ[2] || JJ[1] == JJ[2])
            {

                if (
                    (PP[0].X == PP[1].X && PP[0].Y == PP[1].Y) ||
                    (PP[2].X == PP[1].X && PP[2].Y == PP[1].Y) ||
                    (PP[0].X == PP[2].X && PP[0].Y == PP[2].Y))
                {

                    label4.Text = "有相同點座標";
                    return;
                }
                if (angg[0] == angg[1] || angg[0] == angg[2] || angg[1] == angg[2])
                {
                    label4.Text = "三點共線";
                    return;
                }
               
            }

            
            
            if (Len[0] == Len[1] || Len[0] == Len[2] || Len[1] == Len[2])
            {
                if (Len[0] == Len[1] && Len[0] == Len[2] && Len[1] == Len[2])
                {
                    label4.Text = "正三角形";
                    return;
                }
                else//等腰
                {
                    //直角
                    if (JJ.Contains(90))
                    {
                        label4.Text = "等腰直角三角形";
                    }
                    else
                    {
                        label4.Text = "等腰三角形";
                    }
                    return;
                }
            }
            

            
            if (Len[2] == Math.Sqrt(Math.Pow(Len[0], 2) + Math.Pow(Len[1], 2)))
            {
                label4.Text = "直角三角形";
                return;
            }
            if (JJ.Max()>=90d)
            {
                label4.Text = "鈍角三角形";
            }
            else
            {
                label4.Text = "銳角三角形";
            }

            
        }
        
    }
    class PointD
    {
       public double X, Y;
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
