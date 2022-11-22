using System.Text.RegularExpressions;

namespace lab5.ClassLibrary
{
    public static class Lab2
    {
        public static string Run(string? n, string? s, string? w, string? e, string? u, string? d, string firstMove)
        {
            List<string?> list = new List<string?>();

            Dictionary<string, string?> rules = new Dictionary<string, string?>();
            rules.Add("N", n ?? "");
            rules.Add("S", s ?? "");
            rules.Add("E", w ?? "");
            rules.Add("W", e ?? "");
            rules.Add("U", u ?? "");
            rules.Add("D", d ?? "");
            
            var lines = rules.ToList().Select(i => i.Value).ToList();
            
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
            
            if (Int32.Parse(firstMove.Split()[1]) > 100)
            {
                throw new Exception("Number of moves is out of bound");
            }
            
            string?[] arg = {firstMove.Split()[0], firstMove.Split()[1]};
            
            list.Add(arg[0]);
            list.Add(rules[arg[0]]);
            
            int moves = Int32.Parse(arg[1]) - 2;
            
            int iterations = 1;
            
            for (;moves != 0; moves--)
            {
                var temp = new List<string?>();

                foreach (var move in list[iterations])
                {
                    temp.Add(rules[move.ToString()]);
                }
                list.Add(String.Join("", temp));
                iterations++;
            } 
            
            return String.Join("", list).Length.ToString();


        }

    }
}