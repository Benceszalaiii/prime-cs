using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primszam kalkulátor");
            Console.Write("tól=");
            int tol = int.Parse(Console.ReadLine());
            Console.Write("ig=");
            int ig = int.Parse(Console.ReadLine());
            if (tol >= ig)
            {
                Console.WriteLine("Rossz input, tol >= ig");
                return;
            }
            if (ig < 2)
            {
                Console.WriteLine("Nincs a megadott sorozatban primszam");
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool[] vec = Enumerable.Repeat(true, ig).ToArray();
            vec[0] = false; vec[1] = false;
            int lastIndex = (int)Math.Floor(Math.Sqrt(vec.Length));
            //Console.WriteLine("[{0}]", string.Join(", ", vec));
            //Console.WriteLine("Last index: " + lastIndex);  // Sqrt(vec.Length) a legnagyobb szam ami lehet primszam, azutan mar mindent megneztunk

            for (int i = 2; i <= lastIndex; i++)
            {
                if (vec[i])
                {
                    for (int j = i * 2; j < ig; j += i)
                    {
                        vec[j] = false;
                    }
                }
            }
            int a = 0;
            //Console.WriteLine("[{0}]", string.Join(", ", vec));  // Bool meg mindig, de mar csak a primszamok indexei igazak
            int[] primes = vec
                .Select((value, index) => new { Value = value, Index = index })
                .Where(item => item.Value)
                .Select(item => item.Index)
                .ToArray();
            watch.Stop();
            //Console.WriteLine("[{0}]", string.Join(", ", primes)); // Kiirja az osszes szamot
            Console.WriteLine("A megadott sorozatban " + primes.Length + "primszam van.");
            Console.WriteLine("Program lefutasi ideje: " + watch.ElapsedMilliseconds + "ms");
        Console.ReadKey();
        }
    }

}
