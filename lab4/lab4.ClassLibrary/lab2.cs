using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace lab4.ClassLibrary
{
    public static class Lab2
    {
        public static void Run(string input, string output)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(input);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file: " + e.FileName);
                return;
            }
            if (lines.Length != 7)
            {
                throw new ArgumentException(@"You must have 7 lines in input file");
            }

            List<string> list = new List<string>();

            Dictionary<string, string> rules = new Dictionary<string, string>();
            rules.Add("N", lines[0]);
            rules.Add("S", lines[1]);
            rules.Add("E", lines[2]);
            rules.Add("W", lines[3]);
            rules.Add("U", lines[4]);
            rules.Add("D", lines[5]);
            
            for (int i = 0; i < 6; i++)
            {
                if(lines[i] == "")
                {
                    continue;
                }
                else if (lines[i].Length > 100)
                {
                    throw new Exception($"{rules.ToList()[i].Key} is out of range");
                }
                else if(!Regex.IsMatch(lines[i], @"^[NSWEUD]"))
                {
                    throw new Exception($"{rules.ToList()[i].Key} is in incorrect format");
                }
            }
            
            if (Int32.Parse(lines[^1].Split()[1]) > 100)
            {
                throw new Exception("Number of moves is out of bound");
            }
            
            string[] arg = {lines[^1].Split()[0], lines[^1].Split()[1]};
            
            list.Add(arg[0]);
            list.Add(rules[arg[0]]);
            
            int moves = Int32.Parse(arg[1]) - 2;
            
            int iterations = 1;
            
            for (;moves != 0; moves--)
            {
                var temp = new List<string>();

                foreach (var move in list[iterations])
                {
                    temp.Add(rules[move.ToString()]);
                }
                list.Add(String.Join("", temp));
                iterations++;
            }

            try
            {
                File.WriteAllText(output, String.Join("", list).Length.ToString());
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file: " + e.FileName);
                return;
            }
            Console.WriteLine(String.Join("", list).Length);
        }

    }
}