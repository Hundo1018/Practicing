using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Floyd_Steinberg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            path = textBox1.Text;
            button1_Click(null,null);
        }
        bool ReadDat = true;
        string path = "";
        double[,] LL = new double[13, 20];
        private void button1_Click(object sender, EventArgs e)
        {
            if (ReadDat)
            {
                using (FileStream FS = new FileStream(path, FileMode.Open))
                {
                    for (int i = 0; i < 13; i++)//h
                    {
                        for (int j = 0; j < 20; j++)//w
                        {
                            LL[i, j] += FS.ReadByte();
                            textBox2.Text += LL[i, j].ToString().PadLeft(4, '_');
                        }
                        textBox2.Text += "\r\n";
                    }
                }
                    double ee=0;
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (LL[i, j] >= 128)
                        {
                            ee = LL[i, j] - 255;
                            LL[i, j] = 255;
                        }
                        else
                        {
                            ee = LL[i, j];
                            LL[i, j] = 0;
                        }
                        textBox3.Text += LL[i, j].ToString("").PadLeft(4, '_');
                        if (j + 1 < 20)
                            LL[i, j + 1] += ee * 7 / 16;
                        if (i + 1 < 13)
                            LL[i + 1, j] += ee * 5 / 16;
                        if (j + 1 < 20 && i + 1 < 13)
                            LL[i + 1, j + 1] += ee * 1 / 16;
                        if (i + 1 < 13 && j - 1 >= 0)
                            LL[i + 1, j - 1] += ee * 3 / 16;
                    }
                    textBox3.Text += "\r\n";
                }
            }
        }
    }
}
