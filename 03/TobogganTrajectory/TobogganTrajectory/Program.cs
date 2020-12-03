using System;
using System.IO;
using System.Collections.Generic;


namespace TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            var watch = new System.Diagnostics.Stopwatch();
            CalculateTrajectory(3, 1);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            //Part2
            var watch2 = new System.Diagnostics.Stopwatch();
            uint trees1 = CalculateTrajectory(1, 1);
            uint trees2 = CalculateTrajectory(3, 1);
            uint trees3 = CalculateTrajectory(5, 1);
            uint trees4 = CalculateTrajectory(7, 1);
            uint trees5 = CalculateTrajectory(1, 2);
            Console.WriteLine($"Multiplied trees: {trees1 * trees2 * trees3 * trees4 * trees5}");
            watch2.Stop();
            Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");
        }
        public static uint CalculateTrajectory(int step_right, int step_down)
        {
            string[] input = File.ReadAllLines("input.txt");
            List<List<char>> ylist = new List<List<char>>();

            foreach (string line in input)
            {
                List<char> xlist = new List<char>();
                xlist.AddRange(line);
                ylist.Add(xlist);
            }
            int y = 0;
            int x = 0;
            uint counter = 0;
            while (true)

            {
                if (y >= ylist.Count)
                {
                    break;
                }

                if (x >= ylist[y].Count)
                {
                    x = x - ylist[y].Count;
                }

                if (ylist[y][x] == '#')
                {
                    counter += 1;
                }
                x += step_right;
                y += step_down;
            }
            Console.WriteLine($"You encountered {counter} trees!");
            return counter;
        }

    }
}
