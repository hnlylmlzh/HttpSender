using System;
using HttpSender;
using BenchmarkDotNet.Running;

namespace Performance.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Test));
            Console.ReadLine();
        }
    }
}
