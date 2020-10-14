using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{

    class Customer
    {
        public string Name;
        public string State;
        public string Phone;

        public Customer(string n, string s, string p)
        {
            Name = n;
            State = s;
            Phone = p;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var customers = new List<Customer>();
            customers.Add(new Customer("Chandler", "OR", "555-555-5555"));
            customers.Add(new Customer("Monica", "CO", "555-666-6666"));
            customers.Add(new Customer("Joey", "CO", "555-777-7777"));
            customers.Add(new Customer("Ross", "NY", "555-000-0000"));
            customers.Add(new Customer("Phoebe", "NY", "555-111-1111"));
            customers.Add(new Customer("Rachel", "NJ", "555-222-2222"));

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string[] numNames = { "nulla", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };

            // 5 alatti számok kiírása
            var otAlatt = from n in numbers where n < 5 && n > 2 orderby n descending select n;

            // Azonnali kiértékelés --> átalakítással
            ///var ujTomb = otAlatt.ToList();
            ///var ujTomb = otAlatt.ToArray();

            foreach (var o in otAlatt)
            {
                Console.Write(o + ", ");
                Console.WriteLine();
            }


            // Kik laknak "CO" államban?
            var coState = from c in customers where c.State == "CO" orderby c.Name select c;
            foreach (var c in coState)
            {
                Console.WriteLine(c.Name + " -- " + c.State);
            }

            // számok értéke növelve 2-vel
            var kettovel = from n in numbers select n + 2;

            //var kettoTomb = kettovel.ToArray();
            //for (int i = 0; i < kettoTomb.Length; i++)
            //{
            //    Console.WriteLine($"{numbers[i]} --> {kettoTomb[i]}");
            //}

            int i = 0;
            foreach (var k in kettovel)
            {
                Console.WriteLine($"{numbers[i++]} --> {k}");
            }

            // A Customer-ből csak név és telefonszám kell --> anonim objektum típus felhasználása
            var namePhone = from c in customers orderby c.Name select new { nev = c.Name, tel = c.Phone};

            foreach (var n in namePhone)
            {
                Console.WriteLine($"{n.nev,8} -- {n.tel}");
            }

            // számokból --> szöveg
            int[] ujTomb = { 2, 4, 0, 1, 9, 6 };

            var szoveges = from u in ujTomb select numNames[u];

            Console.WriteLine();
            foreach (var sz in szoveges)
            {
                Console.Write($"{sz}, ");
            }

            // csoportosítás
            var nevek = from c in customers select c.Name;

            var nevlista = nevek.ToList();

            var kezdoBetu = from n in nevlista
                            orderby n
                            where n[0] != 'R'
                            group n by n[0] into tempNevek
                            select tempNevek;


            Console.WriteLine("\nCsoportosítás kezdőbetű szerint");
            foreach (var csoport in kezdoBetu)
            {
                Console.WriteLine("Kezdőbetű: {0}", csoport.Key);
                foreach (var csoportTag in csoport)
                {
                    Console.WriteLine($"\t{csoportTag}");
                }
            }


            Console.ReadLine();
        }

    }

}
