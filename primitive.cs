using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primszamok meghatarozasa sorozatban");
            Console.Write("tol=");
            int tol = int.Parse(Console.ReadLine());
            Console.Write("ig=");
            int ig = int.Parse(Console.ReadLine());
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<int> primes = new List<int>();
            
            for (int i = tol; i < ig; i++)
            {
                int osztok_szama = 0;
                for (int j = 1; j <= i; j++) {
                    if (i % j == 0)
                    {
                        osztok_szama++;
                    }
                }
                   if (osztok_szama == 2)
                {
                    primes.Add(i);
                }

            }
            watch.Stop();
            Console.WriteLine("{0}", string.Join(", ", primes));
            Console.WriteLine("Primek szama: " + primes.ToArray().Length);
            Console.WriteLine("Elapsed: " + watch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }
    }
}
