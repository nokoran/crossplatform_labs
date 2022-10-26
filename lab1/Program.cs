namespace lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(@"C:\Users\nokkoran\Documents\4 курс\CrossPlatform\lab1\INPUT.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
            if (lines.Length != 3)
            {
                throw new ArgumentException(@"You must have 3 lines in input file");
            }
            int a, b, c;

            try
            {
                a = Int32.Parse(lines[0]);
                b = Int32.Parse(lines[1]);
                c = Int32.Parse(lines[2]);
            }
            catch (Exception e)
            {
                throw new Exception("Wrong data type of input data in file.");
            }

            if (0 <= a && a < 109)
            {
                throw new Exception("a is out of range");
            }
            if (0 <= b&& b < 109)
            {
                throw new Exception("b is out of range");
            }
            if (0 <= c && c < 109)
            {
                throw new Exception("c is out of range");
            }

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
                try
                {
                    File.WriteAllText(@"C:\Users\nokkoran\Documents\4 курс\CrossPlatform\lab1\OUTPUT.txt", "NO");
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.WriteLine("NO");
            }
            else
            {
                
                Console.WriteLine("YES");
                var temp = result.FirstOrDefault(o => o.x == result.Min(r => r.x));
                try
                {
                    File.WriteAllText(@"C:\Users\nokkoran\Documents\4 курс\CrossPlatform\lab1\OUTPUT.txt", $"YES {temp.x} {temp.x}");
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.WriteLine(temp.x);
                Console.WriteLine(temp.y);
            }
        }
    }
}