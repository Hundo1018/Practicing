using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics G;
        Bitmap B;
        Pen P;
        int W;
        int H;
        int XBiLi = 20, YBiLi=45;
        int ZB = 20;
        void ReSet()
        {

            P = new Pen(Color.DeepPink, 0.75f);
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            ZB = Convert.ToInt32(textBox1.Text) ;
            XBiLi = W / ZB-2;
            B = new Bitmap(W, H);
            G = Graphics.FromImage(B);
            G.TranslateTransform(25, (H - 25));
            G.DrawLine((new Pen(Color.Blue, 1f)), 0, 0, W, 0);
            G.DrawLine((new Pen(Color.Blue, 1f)), 0, -H, 0, 0);
            pictureBox1.Image = B;
            for (int x = 0; x < (W / XBiLi); x++)
            {
                G.DrawLine((new Pen(Color.Gray, 0.5f)), x * XBiLi, 0, x * XBiLi, -H);
                G.DrawLine((new Pen(Color.Blue, 1f)), x * XBiLi, 0, x * XBiLi, -5f);

                G.DrawString((x.ToString()), (new Font(FontFamily.GenericMonospace, 9f)), ((new SolidBrush(Color.Black))), new Point(x * XBiLi - 5, 0));
            }

            for (float y = 0; y < (H / YBiLi); y++)
            {
                G.DrawLine((new Pen(Color.Gray, 0.5f)), new Point(0, -(int)y * (YBiLi) ), new Point(W, -(int)y * (YBiLi) ));
                G.DrawLine((new Pen(Color.Blue, 1f)), new Point(0, -(int)y * (YBiLi) ), new Point(5, -(int)y * (YBiLi) ));

                G.DrawString(((y/10).ToString()), (new Font(FontFamily.GenericMonospace, 9f)), ((new SolidBrush(Color.Black))), new Point(-27, -(int)y * (YBiLi) - 10));
            }

            /*
            for (int x = 0; x < W; x+= XBiLi)
            {
                G.DrawString((x.ToString()), (new Font(FontFamily.GenericMonospace,10f)), ((new SolidBrush(Color.Black))), new Point(x, 0));
            }*/
        }
        void DrawS(int a, int m, int b)
        {
            a *= XBiLi;
            b *= XBiLi;
            m *= XBiLi;
            G.DrawLine(P, (new Point(0, 0)), (new Point(a, 0)));
            G.DrawLine(P, (new Point(a, 0)), (new Point(m, -(H - 50))));
            G.DrawLine(P, (new Point(m, -(H - 50))), (new Point(b, 0)));
            G.DrawLine(P, (new Point(b, 0)), (new Point((W-20 - (W/XBiLi)), 0)));
            
            /*
            for (int x = 0; x < (W/XBiLi); x+=XBiLi)
            {
                if(x<=a)
                {

                }
                else if(a<x && x<=m)
                {

                }
                else if(m<x && x<b)
                {

                }
                else if(x>=b)
                {

                }
            }
            */
        }
        void DrawT(int a, int b, int c, int d)
        {
            a *= XBiLi;
            b *= XBiLi;
            c *= XBiLi;
            d *= XBiLi;
            G.DrawLine(P, (new Point(0, 0)), (new Point(a, 0)));
            G.DrawLine(P, (new Point(a, 0)), (new Point(b, -(H - 50))));
            G.DrawLine(P, (new Point(b, -(H - 50) )), (new Point(c, -(H - 50) )));
            G.DrawLine(P, (new Point(c, -(H - 50) )), (new Point(d, 0)));
            G.DrawLine(P, (new Point(d, 0)), (new Point((W ), 0)));

        }
        /*int DrawYConverter()
        {

        }*/
        private void SDraw_BTN_Click(object sender, EventArgs e)
        {
            ReSet();
            int a = Convert.ToInt32(SA_TBX.Text);
            int b = Convert.ToInt32(SB_TBX.Text);
            int m = Convert.ToInt32(SM_TBX.Text);
            DrawS(a, m, b);
        }



        private void TDraw_BTN_Click(object sender, EventArgs e)
        {
            ReSet();
            int a = Convert.ToInt32(TA_TBX.Text);
            int b = Convert.ToInt32(TB_TBX.Text);
            int c = Convert.ToInt32(TC_TBX.Text);
            int d = Convert.ToInt32(TD_TBX.Text);
            DrawT(a, b, c, d);
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
