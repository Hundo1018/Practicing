using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Equals_BTN_Click(null, null);
        }
        List<string> HoShe;
        private void Equals_BTN_Click(object sender, EventArgs e)
        {

            Stack<string> vs = new Stack<string>();
            HoShe = new List<string>();
            string Temp = "";
            string temp = textBox1.Text;
            int GuaHow = 0;
            //緊急措施

            //
            try
            {

            
            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i] != '.' && temp[i] != '(' && temp[i] != ')' && temp[i] != '+' && temp[i] != '-' && temp[i] != '*' && temp[i] != '/' && !(temp[i] >= '0' && temp[i] <= '9')))
                {
                    MessageBox.Show("Error");
                    return;
                }
                if (temp[i] == '(')
                {
                    GuaHow += 1;
                    vs.Push(temp[i].ToString());

                    if (Temp.Length > 0)
                    {
                        HoShe.Add(Temp);
                        Temp = "";
                    }
                }
                else if (temp[i] == ')')
                {
                    GuaHow -= 1;
                    if (Temp.Length > 0)
                    {
                        HoShe.Add(Temp);
                        Temp = "";
                    }

                    while (vs.Count>0)
                    {
                        if (vs.Peek() == "(")
                        {
                            vs.Pop();
                            break;
                        }
                        else
                        {
                            HoShe.Add(vs.Pop());
                        }
                    }
                }
                else
                {
                    if (temp[i] == '+' || temp[i] == '-' || temp[i] == '*' || temp[i] == '/')
                    {

                        if (vs.Count > 0 && (vs.Peek() == "*" || vs.Peek() == "/") &&
                            temp[i].ToString() == "+" || temp[i].ToString() == "-")
                        {
                            HoShe.Add(vs.Pop());
                        }

                        vs.Push(temp[i].ToString());
                        if (Temp.Length > 0)
                        {
                            HoShe.Add(Temp);
                            Temp = "";
                        }
                    }
                    else
                    {
                        Temp += temp[i].ToString();
                    }
                }
            }

            if (Temp != "")
            {
                HoShe.Add(Temp);
            }

            while (vs.Count > 0)
            {
                if (vs.Peek() == "(")
                {
                    vs.Pop();
                }
                else
                {
                    HoShe.Add(vs.Pop());
                }
            }

            if (GuaHow != 0)
            {
                MessageBox.Show("Error");
                return;
            }


            List<double> Res = new List<double>();
            for (int i = 0; i < HoShe.Count; i++)
            {
                //如果是 符號:運算 如果是數字 加入List
                if (HoShe[i] == "+" || HoShe[i] == "-" || HoShe[i] == "*" || HoShe[i] == "/")
                {
                    if (HoShe[i] == "+")// Res.Add(Res[0] + Res[1]);
                    Res.Add(Res[Res.Count - 2] + Res[Res.Count - 1]);
                    else if (HoShe[i] == "-")// Res.Add(Res[0] - Res[1]);
                    Res.Add(Res[Res.Count - 2] - Res[Res.Count - 1]);
                    else if (HoShe[i] == "*")// Res.Add(Res[0] * Res[1]);
                    Res.Add(Res[Res.Count - 2] * Res[Res.Count - 1]);
                    else if (HoShe[i] == "/")// Res.Add(Res[0] / Res[1]);
                    Res.Add(Res[Res.Count - 2] / Res[Res.Count - 1]);
                    Res.RemoveAt(Res.Count - 2);
                    Res.RemoveAt(Res.Count - 2);
                    //Res.RemoveAt(0);
                    //Res.RemoveAt(0);
                }
                else
                {
                    double t = 0;
                    try
                    {
                        t = double.Parse(HoShe[i]);
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                        return;
                    }
                    Res.Add(t);
                }
            }
            textBox2.Text = Res.Last().ToString();
            }
            catch
            {

                MessageBox.Show("Error");
            }
        }
    }
}