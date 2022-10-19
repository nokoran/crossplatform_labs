using Microsoft.VisualBasic;

namespace lab2
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            Dictionary<string, string> rules = new Dictionary<string, string>();
            // rules.Add("N", Console.ReadLine()!);
            // rules.Add("S", Console.ReadLine()!);
            // rules.Add("E", Console.ReadLine()!);
            // rules.Add("W", Console.ReadLine()!);
            // rules.Add("U", Console.ReadLine()!);
            // rules.Add("D", Console.ReadLine()!);
            
            rules.Add("N", "N");
            rules.Add("S", "NUSDDUSE");
            rules.Add("E", "UEWWD");
            rules.Add("W", "");
            rules.Add("U", "U");
            rules.Add("D", "WED");

            string[] input = {"S", "10"};//Console.ReadLine()!.Split("");
            
            list.Add(input[0]);
            
            int moves = Int32.Parse(input[1]) - 1;
            
            int iterations = 1;
            
            for (;moves != 0; moves--)
            {
                var temp = new List<string>();
                if (moves == Int32.Parse(input[1]) - 1)
                {
                    list.Add(rules[input[0]]);
                    continue;
                }
                
                foreach (var move in list[iterations])
                {
                    temp.Add(rules[move.ToString()]);
                }
                list.Add(String.Join("", temp));
                iterations++;
            }
            
            Console.WriteLine(String.Join("", list).Length);
        }

    }
}