using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BigNum a = new BigNum("122");
            BigNum b = new BigNum("112");
            BigNum c = a - b;
            FenJ(new BigNum(15));
        }
        BigNum L = new BigNum(0);
        private void button1_Click(object sender, EventArgs e)
        {
            ZL = new List<int>();
            BigNum A = new BigNum(textBox1.Text);
            BigNum AJ = J(A);
            BigNum AK = K(AJ);
            textBox2.Text = AJ.GetValue();
            textBox3.Text = AK.GetValue();
            textBox4.Text = ZL.Count.ToString();
        }
        BigNum J(BigNum z)
        {
            BigNum ans = new BigNum(1);
            for (BigNum i = new BigNum(1); i < z + 1; i += 1)
            {
                ans *=new BigNum( i.GetValue());
                FenJ(i);
            }
            return ans;
        }
        List<int> ZL = new List<int>(1);
        void FenJ(BigNum z)
        {
            int a = int.Parse(z.GetValue().ToString());
            if (a == 2)
            {
                ZL.Add(2);
                return;
            }
            if (a < 2) return;

            if (a == 2)
            {
                ZL.Add(2);
            }
            int count = 2;

            while (a!=1)
            {
                while (true)
                {
                    if (a % count == 0)
                    {
                        ZL.Add(count);
                        a /= count;
                    }
                    else
                    {
                        break;
                    }
                }
                count++;
            }
        }
    
        
        BigNum K(BigNum z)
        {
            BigNum ans = new BigNum(0);
            List<double> temp = new List<double>();
            z.GetValue().ToList().ForEach(x => ans += (x - '0'));
            return ans;
        }


    }
    class BigNum
    {
        List<double> Value = new List<double>();
        public static bool operator >(BigNum a, BigNum b)
        {
            if (a.Value.Count > b.Value.Count) return true;
            else if (a.Value.Count < b.Value.Count) return false;
            for (int i = 0; i < a.Value.Count; i++)
            {
                if (a.Value[i] > b.Value[i])
                {
                    return true;
                }
                else if (a.Value[i] < b.Value[i])
                {
                    return false;
                }
            }
            return false;
        }
        public static bool operator <(BigNum a, BigNum b)
        {
            if (a.Value.Count < b.Value.Count) return true;
            else if (a.Value.Count > b.Value.Count) return false;
            for (int i = 0; i < a.Value.Count; i++)
            {
                if (a.Value[i] < b.Value[i])
                {
                    return true;
                }
                else if (a.Value[i] > b.Value[i])
                {
                    return false;
                }
            }
            return false;
        }
        public static BigNum operator *(BigNum aa, BigNum bb)
        {
            BigNum a = new BigNum(aa.GetValue());
            BigNum b = new BigNum(bb.GetValue());
            BigNum ans = new BigNum();
            a.Value.Reverse();
            b.Value.Reverse();
            while (a.Value.Count < b.Value.Count) a.Value.Add(0);
            while (a.Value.Count > b.Value.Count) b.Value.Add(0);

            List<double> c = new List<double>();
            int startindex = 0;
            double carry = 0;
            for (int i = 0; i < a.Value.Count; i++)
            {
                ans.Value.Add(0);
                startindex = i;
                for (int j = 0; j < b.Value.Count; j++)
                {
                    ans.Value.Add(0);
                    double temp = 0, ansd;
                    temp = a.Value[i] * b.Value[j] + carry;
                    carry = Math.Floor(temp / 10);
                    ansd = temp % 10;
                    ans.Value[startindex++] += ansd;
                }
            }
            ans.Value[startindex] += carry;
            carry = 0;
            for (int i = 0; i < ans.Value.Count; i++)
            {
                ans.Value[i] += carry;
                carry = Math.Floor(ans.Value[i] / 10);
                ans.Value[i] %= 10;
            }
            BigNum ansa = new BigNum();
            bool flag = false;
            ans.Value.Reverse();
            foreach (var item in ans.Value)
            {
                if (item != 0) flag = true;
                if (flag) ansa.Value.Add(item);
            }
            return ansa;
        }
        public static BigNum operator +(BigNum a, BigNum b)
        {
            a.Value.Reverse();
            b.Value.Reverse();
            while (a.Value.Count < b.Value.Count) a.Value.Add(0);
            while (a.Value.Count > b.Value.Count) b.Value.Add(0);
            BigNum c = new BigNum();
            while (c.Value.Count < a.Value.Count+1) c.Value.Add(0);
            double carry = 0;
            for (int i = 0; i < a.Value.Count; i++)
            {
                double temp = a.Value[i] + b.Value[i] + carry;
                carry = Math.Floor(temp / 10);
                c.Value[i] += temp % 10;
            }
            c.Value[c.Value.Count-1]+= carry;
            c.Value.Reverse();
            BigNum ans = new BigNum();
            bool flag = false;
            foreach (var item in c.Value)
            {
                if (item != 0) flag = true;
                if (flag) ans.Value.Add(item);
            }
            return ans;
        }
        public static BigNum operator -(BigNum a, BigNum b)
        {
            BigNum c = new BigNum(0);
            if (a < b)
            {
                BigNum temp;
                temp = new BigNum(a.GetValue());
                a = new BigNum(b.GetValue());
                b = new BigNum(temp.GetValue());
                return new BigNum(-1);
            }
            a.Value.Reverse();
            b.Value.Reverse();
            while (a.Value.Count < b.Value.Count) a.Value.Add(0);
            while (a.Value.Count > b.Value.Count) b.Value.Add(0);
            while (c.Value.Count < a.Value.Count) c.Value.Add(0);
            double carry = 0;

            for (int i = 0; i < a.Value.Count; i++)
            {
                c.Value.Add(0);
                double temp = 0;
                temp = a.Value[i] - carry - b.Value[i];//a-b-c
                carry = (temp < 0 ? 1 : 0);//<0就借位
                c.Value[i] = temp;
            }
            c.Value.Reverse();
            BigNum ans = new BigNum();
            bool flag = false;
            foreach (var item in c.Value)
            {
                if (item != 0) flag = true;
                if (flag) ans.Value.Add(item);
            }
            return ans;
        }
        public static BigNum operator +(BigNum a, int b)
        {
            BigNum c = new BigNum(b.ToString());
            BigNum ans = a + c;
            return ans;
        }
        public string GetValue()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Value)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
        public BigNum(string s)
        {
            if (s == "-")
            {
                Value = new List<double>();
                Value.Add(-1);
                return;
            }
            Value = new List<double>();
            foreach (var item in s)
            {
                Value.Add(item - '0');
            }
        }
        public BigNum()
        {
            Value = new List<double>();
        }
        public BigNum(int ss)
        {
            string s = ss.ToString();
            if (s == "-1")
            {
                Value = new List<double>();
                Value.Add(-1);
                return;
            }
            Value = new List<double>();
            foreach (var item in s)
            {
                Value.Add(item - '0');
            }
        }
        public static bool operator >(int b, BigNum a)
        {
            BigNum bb = new BigNum(b);
            if (bb > a) return true;
            else return false;
        }
        public static bool operator <(int b, BigNum a)
        {
            BigNum bb = new BigNum(b);
            if (bb < a) return true;
            else return false;
        }
    }
}
