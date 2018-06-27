using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public class GenerateData
    {
        readonly int LowerBound;
        readonly int UpperBound;
        readonly int FizzAt;
        readonly int BuzzAt;

        public List<string> Data { get; private set; }

        public GenerateData(int lowerBound, int upperBound, int fizzAt, int buzzAt)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            FizzAt = fizzAt;
            BuzzAt = buzzAt;
            Data = new List<string>();
        }

        public void Go()
        {
            if (!Valid())
                return;

            var outPut = "";

            Console.WriteLine("------------------------------");
            Console.WriteLine("Running FizzBuzz: lowerBound={0} upperBound={1} fizzAt={2} buzzAt={3}",
                LowerBound,
                UpperBound,
                FizzAt,
                BuzzAt);
            Console.WriteLine("------------------------------");

            for (int i = LowerBound; i <= UpperBound; i++)
            {
                if (i % FizzAt == 0)
                    outPut = "FIZZ";

                if (i % BuzzAt == 0)
                    outPut += "BUZZ";

                if (outPut.Equals(""))
                    outPut = i.ToString();

                Console.WriteLine(outPut);
                Data.Add(outPut);
                outPut = "";
            }

            Console.WriteLine("------------------------------");
        }

        #region helpers
        private bool Valid()
        {
            if (LowerBound.Equals(0))
            {
                Console.WriteLine("Invalid lowerBound");
                return false;
            }

            if (UpperBound.Equals(0))
            {
                Console.WriteLine("Invalid upperBound");
                return false;
            }

            if (FizzAt.Equals(0))
            {
                Console.WriteLine("Invalid fizzAt");
                return false;
            }

            if (BuzzAt.Equals(0))
            {
                Console.WriteLine("Invalid buzzAt");
                return false;
            }

            return true;
        }
        #endregion
    }
}
