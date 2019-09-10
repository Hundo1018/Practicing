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

                Console.WriteLine("輸入比值：");
                double[,] RMatrix = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        RMatrix[i, j] = 1;
                    }
                }
                string[] temp;
                double a;
                double b;
                string[] Que = new string[3] {
                    "專業能力",
                    "通識素養",
                    "合群性" };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = i + 1; j < 3; j++)
                    {
                        Console.Write($"請輸入「{Que[i]}」對「{Que[j]}」的指標比值<輸入2個數值>：");
                        temp = Console.ReadLine().Split(' ');
                        a = double.Parse(temp[0]);
                        b = double.Parse(temp[1]);
                        RMatrix[i, j] = a / b;
                        RMatrix[j, i] = b / a;
                    }
                }
                double[,] Bmatrix = new double[3, 3];
                double[] Weight = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    double sum1 = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        double sum2 = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            sum2 += RMatrix[k, j];
                        }
                        Bmatrix[i, j] = RMatrix[i, j] / sum2;
                        sum1 += Bmatrix[i, j];
                    }
                    Weight[i] = sum1 / 3;
                }
                double lambdamax = 0;
                for (int i = 0; i < 3; i++)
                {
                    double Rsum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        Rsum += RMatrix[j, i];
                    }
                    lambdamax += Weight[i] * Rsum;
                }
                double CR = (lambdamax - 3) / ((3 - 1) * 0.58);
                #region Show
                Console.WriteLine("顯示比值矩陣");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(" " + (Math.Round(RMatrix[i, j], 3)).ToString("0.000") + " ");
                    }
                    Console.WriteLine("");
                }

                Console.Write("顯示指標的權重：");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"w{i + 1}：{Weight[i].ToString("0.000")} ");
                }
                Console.WriteLine("");
                Console.Write($"顯示最大特徵值：LundaMax = { lambdamax.ToString("0.000")}");
                Console.WriteLine("");
                Console.Write($"顯示一致性比率 = {lambdamax.ToString("0.000")} 。CR{(CR < 0.1 ? "小於" : "不小於")}0.1， {(CR < 0.1 ? "" : "不")}符合一致性");
                Console.WriteLine("");
                #endregion
                Console.WriteLine("繼續否？<y or n>");
                string tempcon = Console.ReadLine();
                if (tempcon != "y")
                {
                    return;
                }
            }
        }
    }
}
