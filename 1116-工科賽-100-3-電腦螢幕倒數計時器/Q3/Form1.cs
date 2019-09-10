using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1";
            textBox2.Text = "59";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int om = DateTime.Now.Minute;
            int os = DateTime.Now.Second;
            int setm = int.Parse(textBox1.Text);
            int sets = int.Parse(textBox2.Text);
            while (setm > 0 || sets > 0)
            {
                sets--;
                if (sets < 0)
                {
                    setm--;
                    sets = 59;
                }
                textBox1.Text = setm.ToString();
                textBox2.Text = sets.ToString();
                Application.DoEvents();
                Thread.Sleep(1000);
            }
            MessageBox.Show("時間到");
        }
    }
}
