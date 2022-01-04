using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
            Console.ReadLine();

        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    public class Bench
    {
        [Params(100, 200)]
        public int A { get; set; }

        [Params(100, 200)]
        public int B { get; set; }


        [Benchmark(Baseline =true)]
        public void Sum()
        {
            var SomeClass = new SomeClass();
            SomeClass.Sum(A, B);
        }

        [Benchmark]
        public void Sum1()
        {
            var SomeClass = new SomeClass();
            SomeClass.Sum1(A, B);
        }
    }


    public class SomeClass
    {

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public virtual int Sum1(int a, int b) => a + b;
    }
}
