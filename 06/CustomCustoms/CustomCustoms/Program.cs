using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace CustomCustoms
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = File.ReadAllLines("input.txt");
            var answers = new List<string>();
            string answerData = "";


            foreach (string line in input)
            {
            
                if (line == "")
                {
                    answers.Add(answerData = answerData.Remove(answerData.Length - 1));
                    answerData = "";
                }
                else
                {
                    answerData += line + ".";
                }
            }
            answers.Add(answerData = answerData.Remove(answerData.Length - 1));
            int sum = 0;
            foreach (string answer in answers)
            {
                var personalAnswers = answer.Split(".");
                string hattenwaschon = "";
                foreach (char character in answer)
                {
                    if (answer.Count(f => f == character) == personalAnswers.Length & !hattenwaschon.Contains(character))
                    {
                        sum += 1;
                        hattenwaschon += character;
                    }
                }
            }
            Console.WriteLine($"Summe ist {sum}");

        }
        
    }
}
