using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("輸入 初始值 = ");
                int N = int.Parse(Console.ReadLine());
                Console.Write("輸入 層數");
                int Cost = int.Parse(Console.ReadLine());
                Recu(N.ToString(), Cost);
                Console.WriteLine("");
            }
        }
        static void Recu(string str, int cost)
        {
            if (cost == 0) return;
            string Ans = "";
            char tempchar = str[0];
            string tempstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (tempchar != str[i])
                {
                    Ans += tempstr.Length + tempchar.ToString();
                    tempchar = str[i];
                    tempstr = "";
                }
                tempstr += str[i].ToString();
            }
            if (tempstr.Length > 0)
                Ans += tempstr.Length + tempchar.ToString();
            Console.WriteLine(Ans);
            Recu(Ans, cost - 1);
        }
    }
}
