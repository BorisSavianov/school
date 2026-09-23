using System;

class Program
{
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        return a;
    }

    static void Main()
    {
        Console.Clear();
        string[] input = Console.ReadLine().Split();
        int p = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        while (p > 1)
        {
            int r = (q + p - 1) / p;

            Console.Write($"1/{r} + ");

            p = p * r - q;
            q = q * r;

            int d = GCD(p, q);
            p /= d;
            q /= d;
        }

        Console.WriteLine($"1/{q}");
    }
}