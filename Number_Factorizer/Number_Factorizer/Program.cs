using System.Collections.Generic;
using System;

namespace Number_Factorizer
{
    internal class Program
    {
        static List<ulong> factors = new List<ulong>();

        static void Main(string[] args)
        {
            while (true)
            {
                string input = GetInput();
                factors = FactorizeNumbers(Convert.ToUInt64(input));
                Console.WriteLine("Result: " + string.Join(" * ", factors));
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
            if (num < 2)
                return false;
            if (num % 2 == 0)
                return num == 2;

            ulong root = (ulong)Math.Sqrt(num);
            for (ulong j = 3; j <= root; j += 2)
            {
                if (num % j == 0)
                    return false;
            }
            return true;
        }
    }
}
