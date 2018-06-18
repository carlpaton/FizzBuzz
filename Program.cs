using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var lowerBound = Environment.GetEnvironmentVariable("lowerBound") == null ? 1 : Convert.ToInt32(Environment.GetEnvironmentVariable("lowerBound"));
            var upperBound = Environment.GetEnvironmentVariable("upperBound") == null ? 100 : Convert.ToInt32(Environment.GetEnvironmentVariable("upperBound"));

            var fizzAt = Environment.GetEnvironmentVariable("fizzAt") == null ? 3 : Convert.ToInt32(Environment.GetEnvironmentVariable("fizzAt"));
            var buzzAt = Environment.GetEnvironmentVariable("buzzAt") == null ? 3 : Convert.ToInt32(Environment.GetEnvironmentVariable("buzzAt"));

            var outPut = "";

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (i % fizzAt == 0)
                    outPut = "FIZZ";

                if (i % buzzAt == 0)
                    outPut += "BUZZ";

                if (outPut.Equals(""))
                    Console.WriteLine(i);
                else
                    Console.WriteLine(outPut);

                outPut = "";
            }
        }
    }
}
