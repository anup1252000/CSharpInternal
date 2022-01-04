using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpInternals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 100);

            var result=list.Where(x=>x == 1);
            var list1 = new BlockingCollection<int>();
            Parallel.ForEach(list, x =>
            {
                list1.Add(x);
            });

            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            //try
            //{
            //    var task1 = Task.Run(() => { throw new CustomException("This exception is expected!"); });
            //    var task2 = Task.Run(() => { throw new CustomException("This exception is expected2!"); });

            //    try
            //    {
            //        task1.Wait();
            //        task2.Wait();
            //    }
            //    catch (Exception ae)
            //    {
            //        // Call the Handle method to handle the custom exception,
            //        // otherwise rethrow the exception.
            //        //ae.Handle(ex =>
            //        //{
            //        //    if (ex is CustomException)
            //        //        Console.WriteLine(ex.Message);
            //        //    return ex is CustomException;
            //        //});
            //        Console.WriteLine(ae.Message);
            //    }
            //}
            //catch (AggregateException ex)
            //{
            //    ex.Handle((x) =>
            //    {
            //        if (x is Exception)
            //        {
            //            Console.WriteLine(x.Message);
            //            return true;
            //        }
            //        return false;
            //    });
            //}

            Console.ReadLine();
        }
    }

    public class CustomException : Exception
    {
        public CustomException(String message) : base(message)
        { }
    }

    public partial class SomethingPartial
    {
        partial void GetData(string value);
    }

    public partial class SomethingPartial
    {
        partial void GetData(string value)
        {
             //do something
        }
    }

    public class Sample : ISample<Service>
    {
        public Service GetT(int value)
        {
            return (Service)Activator.CreateInstance(typeof(Service));
        }
    }

    public interface ISample<out T> where T: class,new()
    {
        T GetT(int value);

        //void SetT(T value);
    }

    public interface ISample1<in T>
    {
        string GetT(T value);

        //T GetT1(int value);
    }

    public static class SomeExtension
    {
        public static string ToInt(this int value)
        {
            return value.ToString();
        }
    }

    public class Service : IServiceA,IServiceB
    {
        public string GetData(int value)
        {
            return $"Value is {value}";
        }

        string IServiceA.GetData(int value)
        {
            return $"Value is {value}";
        }
    }

    public interface IServiceA
    {
        string GetData(int value);
    }

    public interface IServiceB
    {
        string GetData(int value);
    }
}
