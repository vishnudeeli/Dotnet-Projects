using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueriesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cities = new string[] { "Pune", "Hyd", "Bnglr", "Mummbai","Chennai"};
            var res1=from c in cities 
                where c.StartsWith("B")
                orderby c
                select c;

            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
            var res2 = cities.Where((c) => c.StartsWith("M"));
            var res3 = cities.Where((c) => c.StartsWith("C"));
            var res4 = cities.Where((a,b) => cities.Contains("M"));


            int[] a1 =  { 6,4,8,9,1,0,3,6,2,9 };

            var res5 = a1.Where(a => a % 2 == 0);
            foreach (var item in res5)
            {
                Console.WriteLine(item);
            }
            
            var res6 = from a in a1 where a % 2 == 1 select a;
            foreach (var item in res6)
            {
                Console.WriteLine(item);
            }
            List<int> list = new List<int>(a1);
            Console.WriteLine($"Avg is {list.Average((a) => a)}");
            Console.WriteLine($"Sum is {list.Sum((a) => a)}");
            
            Console.WriteLine("Display using for each method....");
            list.ForEach(x => Console.Write(x + ", "));
            Console.WriteLine();
            list.Sort();
            list.ForEach(x => Console.Write(x + ", "));

            List<int> list2 = new List<int>();
            Console.WriteLine($"use of Firstor Default on empty list :{list2.FirstOrDefault()}");
            Console.WriteLine();
            Console.WriteLine(list.Count);
            int index = list.BinarySearch(1);

            Console.WriteLine(list.IndexOf(2));
            Console.ReadLine();


        }

    }
}
