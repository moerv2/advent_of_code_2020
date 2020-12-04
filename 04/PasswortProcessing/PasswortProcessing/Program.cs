using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PasswortProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            var rawpassports = new List<string>();
            var passportlist = new List<Dictionary<string, string>>();
            string passportinfo = null;
            

            foreach (string line in input)
            {
                
                passportinfo += line + " ";
                if (line == "")
                {
                    rawpassports.Add(passportinfo);
                    passportinfo = null;
                }
            }
            rawpassports.Add(passportinfo);


            foreach(string passport in rawpassports)
            {
                string[] data = passport.Split(" ");
                var passportdict = new Dictionary<string, string>();
                
                foreach (var entry in data)
                {
                    if (entry != "")
                    {
                        string[] durch = entry.Split(":");
                        passportdict.Add(durch[0], durch[1]);
                    }
                }
                passportlist.Add(passportdict);
            }

            int counter = 0;
            foreach (var passport in passportlist)
            {
                try
                {
                    Int32 birthYear = Convert.ToInt32(passport["byr"]);
                    Int32 issueYear = Convert.ToInt32(passport["iyr"]);
                    Int32 expirationYear = Convert.ToInt32(passport["eyr"]);
                    string height = passport["hgt"];
                    string hairColor = passport["hcl"];
                    string eyeColor = passport["ecl"];
                    string passportID = passport["pid"];

                    if (birthYear < 1920 | birthYear > 2002)
                    {
                        throw new Exception("Passport Invalid!");
                    }

                    if (issueYear < 2010 | issueYear > 2020)
                    {
                        throw new Exception("Passport Invalid!");
                    }

                    if (expirationYear < 2020 | expirationYear > 2030)
                    {
                        throw new Exception("Passport Invalid!");
                    }

                    Regex re = new Regex(@"(\d+)([a-zA-Z]+)"); 
                    Match result = re.Match(height);
                    string measurement = result.Groups[2].ToString();
                    int iheight = int.Parse(result.Groups[1].ToString());
                    if (measurement == "cm")
                    {
                        if (iheight < 150 | iheight > 193)
                        {
                            throw new Exception("Passport Invalid!");
                        }
                        
                    }
                    else if (measurement == "in")
                    {
                        if (iheight < 59 | iheight > 76)
                        {
                            throw new Exception("Passport Invalid!");
                        }
                    }


                    if (!Regex.IsMatch(hairColor, @"\A#\b[0-9a-fA-F]+\b\Z"))
                    {
                       throw new Exception("Passport Invalid!");
                    }

                    if (!Regex.IsMatch(eyeColor, @"amb|blu|brn|gry|grn|hzl|oth"))
                    {
                        throw new Exception("Passport Invalid!");
                    }


                    if (passportID.Length != 9)
                    {
                        throw new Exception("Passport Invalid!");
                    }



                }
                catch (Exception e)
                {
                    counter -= 1;
                }
                counter += 1;

            }

            Console.WriteLine($"{counter} passwords are valid!");

        }
    }
}
