using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knapsack_Problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetUp();
            Knapsack_Class MaybeIsABigestOne = ToDo(0, items, new Knapsack_Class(10), false);
            Knapsack_Class MaybeIsABigestOne2 = Answers.Find(x => x.Cost_Total == Answers.Max(z => z.Cost_Total));
        }
        List<ItemTable_Class> itemTable;
        List<Items_Class> items = new List<Items_Class>();
        List<Knapsack_Class> Answers;
        Knapsack_Class ToDo(int n, List<Items_Class> items_L, Knapsack_Class pack, bool Take)
        {
            if (pack.Weight_Total == pack.Load)
                return pack;
            if (Take && items_L.ElementAt(n).Weight + pack.Weight_Total <= pack.Load)
                pack.Add(items_L.ElementAt(n));
            if (n == (items_L.Count - 1))
            {
                Answers.Add(new Knapsack_Class(pack));
                return pack;
            }
            Knapsack_Class A = ToDo(n + 1, items_L, (new Knapsack_Class(pack)), false);
            Knapsack_Class B = ToDo(n + 1, items_L, (new Knapsack_Class(pack)), true);
            return (A.Cost_Total > B.Cost_Total ? A : B);
        }
        void SetUp()
        {
            itemTable = new List<ItemTable_Class>();
            for (int i = 1; i <= 5; i++)
            {
                itemTable.Add(new ItemTable_Class(("Item" + i), i, (5 - i + 1), (5 - i + 1)));
            }
            items = new List<Items_Class>();
            foreach (var item in itemTable)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    items.Add(new Items_Class(item.Name, item.Cost, item.Weight));
                }
            }
            Answers = new List<Knapsack_Class>();
        }
    }
    class Knapsack_Class
    {
        public List<ItemTable_Class> items;
        public Knapsack_Class(int load)
        {
            items = new List<ItemTable_Class>();
            Cost_Total = 0;
            Weight_Total = 0;
            Quantity_Total = 0;
            Load = load;
        }
        public Knapsack_Class(Knapsack_Class In)
        {
            items = new List<ItemTable_Class>();
            foreach (var temp in In.items)items.Add(temp);
            Cost_Total = In.Cost_Total;
            Weight_Total = In.Weight_Total;
            Quantity_Total = In.Quantity_Total;
            Load = In.Load;
        }
        public int Load;
        public int Cost_Total;
        public int Weight_Total;
        public int Quantity_Total;
        public void Add(Items_Class AddIn)
        {
            int ind = items.FindIndex(x => x.Name == AddIn.Name);
            if (ind < 0)
            {
                items.Add(new ItemTable_Class(AddIn.Name, AddIn.Cost, AddIn.Weight, 1));
                Cost_Total += AddIn.Cost;
                Weight_Total += AddIn.Weight;
                Quantity_Total += 1;
            }
            else
            {
                Cost_Total += AddIn.Cost;
                Weight_Total += AddIn.Weight;
                Quantity_Total += 1;
                items[ind].Quantity += 1;
            }
        }
    }
    class Items_Class
    {
        public string Name;
        public int Cost;
        public int Weight;
        public Items_Class(string name , int cost , int weight)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
        }
    }
    class ItemTable_Class: Items_Class
    {
        public int Quantity;
        public ItemTable_Class(string name, int cost, int weight , int quantuty) : base(name, cost, weight)
        {
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
            this.Quantity = quantuty;
        }
    }
}
