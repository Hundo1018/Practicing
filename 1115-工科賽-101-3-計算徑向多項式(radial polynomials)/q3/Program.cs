using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入逕向距離(r) = ");
                double r = double.Parse(Console.ReadLine());
                Console.Write("請輸入逕向多項式的次數(n) = ");
                double n = double.Parse(Console.ReadLine());
                for (double m = 0; m <= n; m++)
                {
                    if ((n - Math.Abs(m)) % 2 == 0 && Math.Abs(m) <= n)
                    {
                        double sumR = 0;
                        for (double s = 0; s <= ((n - Math.Abs(m)) / 2d); s++)
                        {
                            double A = Math.Pow(-1, s);
                            double B = stage(n - s);
                            double C = stage(s);
                            double D = stage(((n + Math.Abs(m)) / 2) - s);
                            double E = stage(((n - Math.Abs(m)) / 2) - s);
                            double F = Math.Pow(r, n - 2 * s);
                            double Total = A * B / (C * D * E) * F;
                            sumR += Total;
                        }
                        Console.WriteLine($"計算逕向多項式(radial polynomials) ..., r = {r}, n = {n}, m = {m}");
                        Console.WriteLine($"所求之逕向多項式為 = {sumR}");
                    }
                }
                Console.WriteLine("計算完畢！");
                Console.WriteLine("");
            }
        }
        static double stage(double v)
        {
            if (v == 0 || v == 1) return 1;
            return v * stage(v - 1);
        }
    }
}
