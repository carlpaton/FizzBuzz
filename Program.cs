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
            var buzzAt = Environment.GetEnvironmentVariable("buzzAt") == null ? 5 : Convert.ToInt32(Environment.GetEnvironmentVariable("buzzAt"));
            var apiUrl = Environment.GetEnvironmentVariable("apiUrl");

            //debug
            //apiUrl = "http://192.168.31.129:3000";

            //generate and display the data
            var objData = new GenerateData(lowerBound, upperBound, fizzAt, buzzAt);
            objData.Go();

            //persist the data to a web api
            //used with docker compose - https://github.com/charleyza/DockerCompose        
            new CallApi(lowerBound, upperBound, fizzAt, buzzAt, apiUrl, objData.Data)
                .Go();
        }
    }
}
