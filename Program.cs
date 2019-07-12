using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharpCalc
{
    class Program
    {
        static string path = @"./readme.txt";
        
static void Main(string[] args)
        {
            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}
            //else
            //{
            //    File.Create(path);
            //}

            Console.Write("Что вы хотите решить ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0 ");
            Console.ResetColor();
            Console.Write("квадратное уравнение ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("1");
            Console.ResetColor();
            Console.WriteLine(" кубическое уравнение?");
            
            string id = Console.ReadLine();
            int idNum = Convert.ToInt32(id);
            string[] _koeficent2;
            double[] _koeficent;
            switch (idNum)
            {
                case 0:
                    Console.WriteLine("Вы выбрали квадратное уравнение. Введите цифры через запятую ");
                    _koeficent2 = Console.ReadLine().Split(',');
                    _koeficent = new double[3];
                    for (int i = 0; i < _koeficent2.Length; i++)
                    {
                        _koeficent[i] = Convert.ToDouble(_koeficent2[i]);
                    }
                    Descriminant(_koeficent);
                    break;
                case 1:
                    Console.WriteLine("Вы выбрали кубическое уравнение. Введите цифры через запятую ");
                    _koeficent2 = Console.ReadLine().Split(',');
                    _koeficent = new double[4];
                    for (int i = 0; i < _koeficent2.Length; i++)
                    {
                        _koeficent[i] = Convert.ToDouble(_koeficent2[i]);
                    }
                    CubeFunction(_koeficent);
                    break;
                default:

                    break;
            }
            
            Console.ReadKey();
        }
        static void Descriminant(double[] koef)
        {
            double a = koef[0];
            double b = koef[1];
            double c = koef[2];
            double D;
            D = (Math.Pow(b, 2) - 4 * a * c);
            double x1;
            double x2;
            double x3;
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine($"Уравнение имеет вид {a}x^2 +- {b}x +- {c}");
            sw.WriteLine($"Дискрименант уравнение равен {D} и корень дискременанта равен  {Math.Sqrt(D)}");
            if (D == 0)
            {
                D = Math.Sqrt(D);
                x3 = (b - D) / (2 * a);
                Console.WriteLine("Уравнение имеет один корень");
                Console.WriteLine($"Х равен +-{Math.Round(x3, 3)}");
                
                sw.WriteLine($"Уравнение имеет один корень \n Х равен +-{ Math.Round(x3, 3)}");
            }
            else if (D > 0)
            {
                D = Math.Sqrt(D);
                x1 = (-b - D) / (2 * a);
                x2 = (-b + D) / (2 * a);
                Console.WriteLine($"Первый Х равен {Math.Round(x1, 3)}");
                Console.WriteLine($"Второй Х равен {Math.Round(x2, 3)}");

                sw.WriteLine($"Первый Х равен {Math.Round(x1, 3)} \n Второй Х равен {Math.Round(x2, 3)} \n ");
            }
            else if (D < 0)
            {
                Console.WriteLine("Уравнение не имеет корней");
                sw.WriteLine("Уравнение не имеет корней");
            }
            sw.Close();
        }
        static void CubeFunction(double[] koef)
        {
            double y, a, b, c, d, D, delta, eX0, eY0;
            a = koef[0];
            b = koef[1];
            c = koef[2];
            d = koef[3];
            StreamWriter sw = new StreamWriter(path);
            delta = 3 * a * c - Math.Pow(b, 2);

            D = Math.Pow(b, 2) * Math.Pow(c, 2) - 4 * a * Math.Pow(c, 3) - 4 * Math.Pow(b, 3) * d - 27 * Math.Pow(a, 2) * Math.Pow(d, 2) + (18 * a * b * c * d);
            if (D > 0)
            {
                Console.WriteLine("Дескриминант большк нуля => график пересекает оси х: А1, А2, А3");
                sw.WriteLine("Дескриминант большк нуля => график пересекает оси х: А1, А2, А3");
            }
            else if (D == 0)
            {
                Console.WriteLine("Дескриминант равен нулю => график пересекает оси х на одной или в двух точках");
                sw.WriteLine($"Дескриминант равен нулю => график пересекает оси х на одной или в двух точках");
            }
            else if (D < 0)
            {
                Console.WriteLine("Дескриминант меньше нуля => график пересекает оси х на одной точке");
                sw.WriteLine($"Дескриминант меньше нуля => график пересекает оси х на одной точке");
            }

            eX0 = -(b / (3 * a));
            eY0 = (2 * Math.Pow(b, 3) - 9 * a * b * c) / (27 * Math.Pow(a, 2)) + d;
            if (delta > 0)
            {
                Console.WriteLine("Функция не имеет эктремум. \n Есть точка перегиба");
                Console.WriteLine($"Точка перегиба Е х0 = {eX0} \n Точка перегиба Е у0 = {eY0}");
                sw.WriteLine($"Функция не имеет эктремум. \n Есть точка перегиба");
                sw.WriteLine($"Точка перегиба Е х0 = {eX0} \n Точка перегиба Е у0 = {eY0}");
            }
            else if(delta == 0)
            {
                Console.WriteLine("Функция не имеет эктремум. \n Есть точка перегиба. Касательная проведена в точке перегиба, являеться паралленой к оси х");
                eX0 = -(b / (3 * a));
                eY0 = (2 * Math.Pow(b, 3) - 9 * a * b * c) / (27 * Math.Pow(a, 2)) + d;
                Console.WriteLine($"Точка перегиба Е х0 = {eX0} \n Точка перегиба Е у0 = {eY0}");
                sw.WriteLine($"Функция не имеет эктремум. \n Есть точка перегиба. Касательная проведена в точке перегиба, являеться паралленой к оси х");
                sw.WriteLine($"Точка перегиба Е х0 = {eX0} \n Точка перегиба Е у0 = {eY0}");
            }
            else if (delta < 0 && a > 0)
            {
                double xMax, xMin;
                xMax = (-b + Math.Sqrt(-delta) / 3 * a);
                xMin = (-b - Math.Sqrt(-delta) / 3 * a);
                Console.WriteLine($"Функция имеет один макимум Хmax = {xMax} и один минимум Xmin = {xMin}");
                sw.WriteLine($"Функция имеет один макимум Хmax = {xMax} и один минимум Xmin = {xMin}");
            }
        }
    }

}
