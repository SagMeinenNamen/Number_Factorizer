using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Number_Factorizer
{
    internal class Program
    {
        static List<ulong> factors = new List<ulong>();

        static void Main(string[] args)
        {
            while (true)
            {
                Stopwatch stopwatch = new Stopwatch();
                string input = GetInput(); 
                stopwatch.Start();
                factors = FactorizeNumbers(Convert.ToUInt64(input));
                Console.WriteLine("Result: " + string.Join(" * ", factors));
                Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + "ms");
                Console.ReadLine();
                Console.Clear();
            }
        }


        private static List<ulong> FactorizeNumbers(ulong num)
        {
            factors = new List<ulong>() { num };
            int previousCount;

            //if count is the same as before then there are no numbers anymore to split into more factors
            do
            {
                previousCount = factors.Count;
                foreach (ulong factor in factors)
                {
                    if (!IsPrime(factor))
                    {
                        for (uint i = 2; i <= factor / 2; i++)
                        {
                            if (factor % i == 0)
                            {
                                //Replace old factor with the new one
                                factors.Remove(factor);
                                factors.AddRange(new List<ulong>() { i, factor / i });
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            while (factors.Count != previousCount);

            return factors;
        }
        private static string GetInput()
        {
            Console.WriteLine("Enter a number");
            while (true)
            {
                string input = Console.ReadLine();
                if (ulong.TryParse(input, out _) == false)
                {
                    Console.WriteLine("\nInput not valid. Try again.");
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    return input;
                }
            }
        }
        private static bool IsPrime(ulong num)
        {
            if (num <= 1)
                return false;
            if (num <= 3)
                return true;
            if (num % 2 == 0 || num % 3 == 0)
                return false;

            for (ulong i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                    return false;
            }
            return true;
        }
    }
}
