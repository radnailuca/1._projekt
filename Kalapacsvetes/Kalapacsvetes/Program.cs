using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    public class Sportolo
    {

        public int Helyezes { get; set; }
        public double Eredmeny { get; set; }
        public string Nev { get; set; }
        public string Orszagkod { get; set; }
        public string Helyszin { get; set; }
        public string Datum { get; set; }
    

        public Sportolo(int helyezes, double eredmeny, string nev, string orszagkod, string helyszin, string datum)
        {
            Helyezes = helyezes;
            Eredmeny = eredmeny;
            Nev = nev;
            Orszagkod = orszagkod;
            Helyszin = helyszin;
            Datum = datum;
        }

        public void Kiir()
        {
            Console.WriteLine($"Helyezés: {Helyezes}");
            Console.WriteLine($"Eredmény: {Eredmeny}");
            Console.WriteLine($"Sportoló: {Nev}");
            Console.WriteLine($"Országkód: {Orszagkod}");
            Console.WriteLine($"Helyszín: {Helyszin}");
            Console.WriteLine($"Dátum: {Datum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Sportolo> sportolok = new List<Sportolo>();
        
                using (StreamReader sr = new StreamReader("kalapacsvetes.txt"))
                {
                    string sor;

                    sr.ReadLine();

                    while ((sor = sr.ReadLine()) != null)
                    {
                        string[] adatok = sor.Split(';');

                        if (adatok.Length == 6)
                        {
                            int helyezes = int.Parse(adatok[0]);
                            double eredmeny = double.Parse(adatok[1]);
                            string nev = adatok[2];
                            string orszagkod = adatok[3];
                            string helyszin = adatok[4];
                            string datum = adatok[5];

                            sportolok.Add(new Sportolo(helyezes, eredmeny, nev, orszagkod, helyszin, datum));
                        }
                    }
                }

                Console.WriteLine("Sportolók adatainak listája:");
                foreach (var sportolo in sportolok)
                {
                    sportolo.Kiir();
                    Console.WriteLine();

                }
            Console.ReadLine();
            }
        }
    }
