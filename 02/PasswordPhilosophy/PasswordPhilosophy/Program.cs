using System;
using System.IO;
using System.Linq;

namespace PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }


        public static void Part1()
        {
            var input = File.ReadAllLines("input.txt");
            int counter = 0;
            foreach (string str in input)
            {
                string[] substrings = str.Split('-', ':', ' ');
                int min = Convert.ToInt32(substrings[0]);
                int max = Convert.ToInt32(substrings[1]);
                char character = Convert.ToChar(substrings[2]);
                int charcount = substrings[4].Count(x => x == character);

                if (charcount >= min && charcount <= max)
                {
                    counter += 1;
                }
            }

            Console.WriteLine($"{counter} passwords are valid!");
        }



        public static void Part2()
        {
            var input = File.ReadAllLines("input.txt");
            int counter = 0;
            foreach (string str in input)
            {
                string[] substrings = str.Split('-', ':', ' ');
                int min = Convert.ToInt32(substrings[0]);
                int max = Convert.ToInt32(substrings[1]);
                char character = Convert.ToChar(substrings[2]);
                string password = substrings[4];

                if (password[min - 1] == character && password[max - 1] != character)
                {
                    counter += 1;
                }
                else if (password[min - 1] != character && password[max - 1] == character)
                {
                    counter += 1;
                }

            }
            Console.WriteLine($"{counter} passwords are valid!");
        }
    }
}
