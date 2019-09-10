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

namespace FruitSaleCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1_Click(null,null);
        }
        string path = "水果1.txt";
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        List<string> Fruits;
        List<string> GroupByFruits;
        Dictionary<string, int> FruitsCount;
        private void button1_Click(object sender, EventArgs e)
        {
                Fruits = new List<string>();
            GroupByFruits = new List<string>();
            FruitsCount = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split('、');
                    for (int i = 0; i < temp.Count(); i++) Fruits.Add(temp[i]);
                }
            }
            GroupByFruits = Fruits.Distinct().ToList();
            foreach (var item in GroupByFruits) FruitsCount.Add(item, 0);
            for (int i = 0; i < Fruits.Count; i++)
            {
                for (int j = 0; j < GroupByFruits.Count; j++)
                {
                    if (Fruits[i] == GroupByFruits[j])
                    {
                        FruitsCount[GroupByFruits[j]] += 1;
                    }
                }
            }
            
            FruitsCount=FruitsCount.OrderBy(x => x.Value).ToDictionary(x=>x.Key,x=>x.Value);
            FruitsCount = FruitsCount.Reverse().ToDictionary(x=>x.Key,x=>x.Value);
            textBox1.Text= FruitsCount.Keys.ElementAt(0);
            textBox2.Text = FruitsCount.Keys.ElementAt(1);
            textBox3.Text = FruitsCount.Keys.ElementAt(2);
            textBox4.Text = FruitsCount.Keys.ElementAt(3);
            textBox5.Text = FruitsCount.Keys.Last();

        }
    }
}
