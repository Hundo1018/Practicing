using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Text = "1輸入1";
            groupBox2.Text = "2核k設定";
            groupBox3.Text = "4輸出O";
            button1.Text = "3運算";
            label1.Text = "MSE=";
            label2.Text = "MAE=";
            label3.Text = "PSNR=";
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    OTB7x7[i, j] = new TextBox() { Size = new Size(25, 22), Location = new Point(60 + j * 30, 60 + i * 30), Text = "0" };
                    groupBox1.Controls.Add(OTB7x7[i, j]);
                    NTB7x7[i, j] = new TextBox() { Size = new Size(25, 22), Location = new Point(60 + j * 30, 60 + i * 30), Text = "0" };
                    groupBox2.Controls.Add(NTB7x7[i, j]);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    KTB3x3[i, j] = new TextBox() { Size = new Size(25, 22), Location = new Point(60 + j * 30, 60 + i * 30), Text = "0" };
                    groupBox3.Controls.Add(KTB3x3[i, j]);
                }
            }
            int count = 1;
            for (int i = 2; i <= 4; i++)
            {
                for (int j = 2; j <= 4; j++)
                {
                    OTB7x7[i, j].Text = $"{count++}";
                }
            }
            KTB3x3[0, 0].Text = "-1";
            KTB3x3[0, 1].Text = "-2";
            KTB3x3[0, 2].Text = "-1";
            KTB3x3[1, 0].Text = "0";
            KTB3x3[1, 1].Text = "0";
            KTB3x3[1, 2].Text = "0";
            KTB3x3[2, 0].Text = "1";
            KTB3x3[2, 1].Text = "2";
            KTB3x3[2, 2].Text = "1";
        }
        TextBox[,] OTB7x7 = new TextBox[7, 7];
        TextBox[,] NTB7x7 = new TextBox[7, 7];
        TextBox[,] KTB3x3 = new TextBox[3, 3];

        double[,] O7x7 = new double[7, 7];
        double[,] N7x7 = new double[7, 7];
        double[,] k3x3 = new double[3, 3];
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            N7x7 = new double[7, 7];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    O7x7[i, j] = double.Parse(OTB7x7[i, j].Text);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    k3x3[i, j] = double.Parse(KTB3x3[i, j].Text);
                }
            }
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            N7x7[i, j] += k3x3[k + 1, l + 1] * O7x7[i - k, j - l];
                        }
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    NTB7x7[i, j].Text = $"{N7x7[i, j]}";
                }
            }
            Cal();
            textBox1.Text = mse.ToString();
            textBox2.Text = mae.ToString();
            textBox3.Text = psnr.ToString();
        }
        double mse = 0, mae = 0, psnr = 0;
        void Cal()
        {
            MSE();
            MAE();
            PSNR();
        }
        void MSE()
        {
            double sum = 0;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    sum += Math.Pow(N7x7[i, j] - O7x7[i, j], 2);
                }
            }
            mse = sum / 49d;
        }
        void MAE()
        {
            double sum = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    sum += Math.Abs(N7x7[i, j] - O7x7[i, j]);
                }
            }
            mae = sum / 49d;
        }
        void PSNR()
        {
            psnr = 10 * Math.Log10((255d * 255d) / mse);
        }
    }
}
