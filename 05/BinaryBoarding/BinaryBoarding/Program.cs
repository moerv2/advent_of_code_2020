using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BinaryBoarding
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            List<int> seatIDs = new List<int>();
         


            foreach (string boardingpass in input)
            {
                int[] rows = { 0, 127 };
                int[] columns = { 0, 7 };
                foreach (char letter in boardingpass)
                {
                    if (letter == 'F')
                    {
                        int median = (rows[1] - rows[0]) / 2;
                        rows[1] = rows[1] - median - 1;
                    }
                    else if (letter == 'B')
                    {
                        int median = (rows[1] - rows[0]) / 2;
                        rows[0] = rows[0] + median +1;
                    }
                    else if (letter == 'L')
                    {
                        int median = (columns[1] - columns[0]) / 2;
                        columns[1] = columns[1] - median - 1;
                    }
                    else if (letter == 'R')
                    {
                        int median = (columns[1] - columns[0]) / 2;
                        columns[0] = columns[0] + median + 1;
                    }
                }

                int seatID = rows[0] * 8 + columns[0];
                seatIDs.Add(seatID);

                //Console.WriteLine($"Seat is in row {rows[0]} and column {columns[0]}! The SeatID is {seatID}");
            }

            seatIDs.Sort();
            

            Console.WriteLine(seatIDs[seatIDs.Count() - 1]);
            int iterator = 0;
            foreach (int number in Enumerable.Range(15, 947))
            {
                if (number != seatIDs[iterator])
                {
                    Console.WriteLine($"Seatnumber {number} missing from list!");
                    break;
                }
             
                iterator += 1;
            }





        }
    }
}
