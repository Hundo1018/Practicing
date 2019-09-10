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

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            path = textBox1.Text = "ringout.wav";
            textBox2.Text = "0";
            button1_Click(null, null);
        }
        string path = "ringout.wav";
        List<byte> data = new List<byte>();
        List<int> Wave = new List<int>();
        double VoiceTime = 0;
        double Sec = 0;

        void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics G = Graphics.FromImage(bmp);
            G.TranslateTransform(0, pictureBox1.Height / 2);
            G.Clear(Color.Black);
            float sec = (int)((Sec / VoiceTime) * data.Count);
            Brush b = Brushes.Green;
            float max = Wave.Max();
            int we = pictureBox1.Width / 100;
            for (int i = (int)sec ; i < sec + pictureBox1.Width && i < Wave.Count ; i++)
            {
                float temp = Wave[i];
                float h = ((temp / max) * pictureBox1.Height / 2);
                float w = we;
                RectangleF R = new RectangleF((i - sec), -h, w, h * 2);
                G.FillEllipse(b, R);
            }
            pictureBox1.Image = bmp;
        }



        void VoiceData()
        {
            for (int i = 44; i < data.Count; i++)
            {
                Wave.Add(Math.Abs(data[i] - 128));
            }
        }
        double NumberofSample()
        {
            double temp = 0;
            for (int i = 40; i <= 43; i++)
            {
                temp += data[i] * Math.Pow(256, i - 40);
            }
            return temp;
        }
        double SampleRate()
        {
            double temp = 0;
            for (int i = 24; i <= 27; i++)
            {
                temp += (data[i] * Math.Pow(256, i - 24));
            }
            return temp;
        }
        bool Check()
        {
            if (Check_RIFF() && Check_WAVEfmt() && Check_PCM() && Check_BitsPerSample() && Check_Single()) return true;
            else return false;
        }
        bool Check_BitsPerSample()
        {
            if ((data[34] + data[35] * 256) == 8) return true;
            return false;
        }
        bool Check_Single()
        {
            if (data[22] == 1 && data[23] == 0) return true;
            return false;
        }
        bool Check_PCM()
        {
            if (data[20] == 1 && data[21] == 0) return true;
            return false;
        }
        bool Check_WAVEfmt()
        {
            string WAVEfmt = "";
            for (int i = 8; i <= 14; i++) WAVEfmt += (char)data[i];
            if (WAVEfmt == "WAVEfmt") return true;
            return false;
        }
        bool Check_RIFF()
        {
            string RIFF = "";
            for (int i = 0; i < 4; i++) RIFF += (char)data[i];
            if (RIFF == "RIFF") return true;
            return false;
        }
        void ReadData()
        {
            path = textBox1.Text;
            using (FileStream FS = new FileStream(path, FileMode.Open))
            {
                int temp = 0;
                while (temp < FS.Length)
                {
                    data.Add((byte)FS.ReadByte());
                    temp++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadData();
            if (!Check())
            {
                MessageBox.Show("輸入的檔案名稱是RIFF WAVEfmt、PCM格式、8位元及單聲道");
                return;
            }
            double SR = SampleRate();
            double NS = NumberofSample();
            VoiceData();
            VoiceTime = Math.Round(NS / SR, 5);
            textBox3.Text = VoiceTime.ToString();
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            double bound = ((HScrollBar)sender).Maximum - ((HScrollBar)sender).Minimum;
            double now = (e.NewValue - ((HScrollBar)sender).Minimum) / bound * VoiceTime;
            Sec =Math.Round( now,5);
            textBox2.Text = Sec.ToString();
            Draw();
        }
    }
}
