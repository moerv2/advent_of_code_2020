using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExpenseReport
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            bool b_break = false;
            var input = File.ReadAllLines("input.txt").Select(int.Parse).ToList();
            watch.Start();
            foreach (int num1 in input)
                {
                foreach (int num2 in input)
                {
                    foreach (int num3 in input)
                    {
                        if (num1 + num2 + num3 == 2020)
                        {
                            Console.WriteLine("Gefundne " + num1 + " " + num2 + " " + num3 + "! Ergebnis: " + num1 * num2 * num3);
                            b_break = true;
                            break;
                        }
                    }
                    if (b_break == true) { break; }
                }
                if (b_break == true) { break; }
            }
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
