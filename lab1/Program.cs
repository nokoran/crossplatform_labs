namespace lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = Int32.Parse(Console.ReadLine()!);
            var b = Int32.Parse(Console.ReadLine()!);
            var c = Int32.Parse(Console.ReadLine()!);
            
            List<int> a_combinations = new List<int>();
            List<int> b_combinations = new List<int>();
            List<(int x, int y)> result = new List<(int x, int y)>();
            
            a_combinations.Add(a);
            b_combinations.Add(b);
            
            for (int i = 1; i < a.ToString().Length; i++)
            {
                a_combinations.Add(Int32.Parse(a.ToString().Substring(i) + a.ToString().Substring(0, i)));
            }
            
            for (int i = 1; i < b.ToString().Length; i++)
            {
                b_combinations.Add(Int32.Parse(b.ToString().Substring(i) + b.ToString().Substring(0, i)));
            }

            foreach (var ai in a_combinations)
            {
                foreach (var bi in b_combinations)
                {
                    if (ai + bi == c)
                    {
                        result.Add((ai, bi));
                    }
                }
            }

            Console.WriteLine("Result:");

            if (!result.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
                var temp = result.FirstOrDefault(o => o.x == result.Min(r => r.x));
                Console.WriteLine(temp.x);
                Console.WriteLine(temp.y);
            }
        }
    }
}