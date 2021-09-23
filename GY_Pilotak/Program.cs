using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GY_Pilotak
{
    class Program
    {
        static List<Adatok> adatok = new List<Adatok>();
        static void Main(string[] args)
        {
            Feladat_2();
            Feladat_3();
            Feladat_4();
            Feladat_5();
            Feladat_6();
            Feladat_7();
            Console.WriteLine("------------------------VÉGE------------------------");
            Console.ReadLine();
        }

        private static void Feladat_7()
        {
            Console.WriteLine("7.Feladat:\n");
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in adatok.Where(q=>q.Rajtszam != string.Empty).Distinct())
            {
                if (!dic.ContainsKey(item.Rajtszam))
                {
                dic.Add(item.Rajtszam,adatok.Count(q=>q.Rajtszam == item.Rajtszam));
                }
                
            }

            foreach (var item in dic)
            {
                if (item.Value > 1)
                {
                    Console.Write("\t{0},",item.Key);
                }
            }
            Console.WriteLine();
        }

        private static void Feladat_6()
        {
            int min = Convert.ToInt32(adatok.Select(q=>q.Rajtszam).First());
            Console.WriteLine("6.Feladat:");
            foreach (var item in adatok.Where(q=>q.Rajtszam != string.Empty))
            {
               
                if ( Convert.ToInt32(item.Rajtszam) < min)
                {
                    min = Convert.ToInt32(item.Rajtszam);
                }
            }
            
            foreach (var item in adatok.Where(q => q.Rajtszam != string.Empty))
            {
                if (item.Rajtszam == min.ToString())
                {
                    Console.WriteLine($"\t{item.Nemzetiseg}");
                }
            }
        }

        private static void Feladat_5()
        {
            Console.WriteLine("5.Feladat:");
            foreach (var item in adatok.Where(q=>q.Szul_ido.Year < 1901))
            {
                Console.WriteLine($"\t{item.Nev}({item.Szul_ido})");
            }
        }

        private static void Feladat_4()
        {
            Console.WriteLine($"4.Feladat:\n\t{adatok.Last().Nev}");
        }

        private static void Feladat_3()
        {
            Console.WriteLine($"3.Feladat\n\t{adatok.Count()}");
        }

        private static void Feladat_2()
        {
            string sor;
            string[] t;
            try
            {
                using (StreamReader sr = new StreamReader("pilotak.csv"))
                {
                    sr.ReadLine();

                    while ((sor = sr.ReadLine()) != null)
                    {
                        t = sor.Split(';');

                        adatok.Add(new Adatok()
                        {
                            Nev = t[0],
                            Szul_ido = new DateTime(int.Parse(t[1].Substring(0,4)),int.Parse(t[1].Substring(5,2)),int.Parse(t[1].Substring(8,2))),
                            Nemzetiseg = t[2],
                            Rajtszam = t[3]
                        }) ;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    class Adatok
    {
        public string Nev { get; set; }
        public DateTime Szul_ido { get; set; }
        public string Nemzetiseg { get; set; }
        public string Rajtszam { get; set; }
    }
}
