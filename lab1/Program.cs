namespace lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n (max number of elements in subset):");
            int n = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter k (number of elements overall):");
            int k = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double total = 0;
            while (n > 0)
            {
                total += Math.Pow(k, n);
                n--;
            }

            Console.WriteLine($"Total is {total}");
        }
    }
}

