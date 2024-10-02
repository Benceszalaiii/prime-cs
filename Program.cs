using System;
using System.Linq;
using System.Threading;
// Time complexity: O(Nlog(Log(N)))
// Space complexity: O(N)

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
            // Algoritmus kezdete
            bool[] vec = Enumerable.Repeat(true, ig).ToArray();
            vec[0] = false; vec[1] = false;
            double lastIndex = Math.Sqrt(vec.Length);
            //Console.WriteLine("[{0}]", string.Join(", ", vec));
            //Console.WriteLine("Last index: " + lastIndex);  // Sqrt(vec.Length) a legnagyobb szam ami lehet primszam, azutan mar mindent megneztunk


            // Nem primek kiszitalasa Eratosthenes algoritmusaval
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
            //Console.WriteLine("[{0}]", string.Join(", ", vec));  // Bool meg mindig, de mar csak a primszamok indexei igazak

            int count = vec.Where(c => c).Count();

            //Megszamlalas, ha kell(addig kikommentezve, if statement lelassitja valamennyivel a programot)
            //int[] primes = vec
            //    .Select((value, index) => new { Value = value, Index = index })
            //    .Where(item => item.Value && item.Index >= tol)
            //    .Select(item => item.Index)
            //    .ToArray();

            // Algoritmus vege

            //  Primek listaja: primes
            //  Primek szama: primes.Length
            //int count = primes.Length;
            watch.Stop();
            //Console.WriteLine("[{0}]", string.Join(", ", primes)); // Kiirja az osszes szamot

            // Ha ki akarjuk iratni a primek szamat, ez a sor teszi meg
            //Console.WriteLine("A megadott sorozatban " + primes.Length + "primszam van.");


            // Ha nem irjuk ki az osszeset, tol nelkul, akkor ez megteszi
            Console.WriteLine("Prímek száma a sorozatban: " + count);



            Console.WriteLine("Program lefutasi ideje: " + watch.ElapsedMilliseconds + "ms");
        Console.ReadKey();
        }
    }
}
