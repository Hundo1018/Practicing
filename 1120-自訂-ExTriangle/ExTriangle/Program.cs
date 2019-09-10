using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("輸入N：");
                N = int.Parse(Console.ReadLine());
                Recu(N, "");
            }
        }
        static int N = 0;
        static void Recu(int first, string fallow)
        {
            if (first == 0)
            {
                return;
            }
            string temp = "".PadLeft((first - 1));
            string temp2 = (first + fallow);
            string nstr = "";
            for (int i = 0; i < temp2.Length; i++)
            {
                nstr += temp2[i] + " ";
            }
            nstr = temp + nstr;
            Console.WriteLine(nstr);
            Recu(first - 1, fallow + "1");
        }
    }
}
