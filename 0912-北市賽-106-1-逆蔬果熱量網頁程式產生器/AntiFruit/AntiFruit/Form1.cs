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
namespace AntiFruit
{
    public partial class Form1 : Form
    {
                StringBuilder SB = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
            using (StreamReader SR =new StreamReader("Data.html",true))
            {
                while (!SR.EndOfStream)
                {
                string temp = SR.ReadLine();
                    if (temp.Contains("gray"))
                    {
                        int ind = temp.IndexOf("gray")+6;
                        temp = temp.Substring(ind);
                        temp = temp.Replace("<br>", ",");
                        temp = temp.Replace("</td>", string.Empty);
                        string[] temp2 = temp.Split(',');
                        if (temp2[0] != "")
                        {
                        SB.AppendLine(temp2[0] + "\t" + temp2[1]);
                        }
                    
                    }
                }
            }
            using (StreamWriter SW = new StreamWriter("Answer.txt", false))
            {
                SW.Write(SB.ToString());
            }
        }
    }
}
