using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes
{
    public class Sportolo  //ez a sportoló osztály a sportolókkal kapcsolatos információkat tartalmazza
    {
        public int Helyezes { get; set; }
        public double Eredmeny { get; set; }
        public string Nev { get; set; }
        public string Orszagkod { get; set; }
        public string Helyszin { get; set; }
        public string Datum { get; set; }

        public Sportolo(int helyezes, double eredmeny, string nev, string orszagkod, string helyszin, string datum) //ez a sportolo osztály konstruktora célja hogy inicializálja (visszaállítsa) az objektumot
        {
            Helyezes = helyezes;
            Eredmeny = eredmeny;
            Nev = nev;
            Orszagkod = orszagkod;
            Helyszin = helyszin;
            Datum = datum;
        }

        public void Kiir() //amikor ezt a metódust meghívják, az információkat a konzolon megjeleníti
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

            using (StreamReader sr = new StreamReader("kalapacsvetes.txt")) //beolvassa a kalapacsvetes.txt-t
            {
                string sor;
                sr.ReadLine();

                while ((sor = sr.ReadLine()) != null) //sorokat olvas be és a listába teszi őket
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

            Console.WriteLine("Add meg a kereséshez szükséges adatokat (hagyj üresen, ha nem tudod):"); //a felhasználótól kér be adatokat egészen pontosan ezzel lehet megtalálni egy sportolót akit keresünk

            Console.WriteLine("Helyezés:");
            string helyezesBeker = Console.ReadLine();
            int helyezesKeres = !string.IsNullOrEmpty(helyezesBeker) ? int.Parse(helyezesBeker) : -1;

            Console.WriteLine("Eredmény:");
            string eredmenyBeker = Console.ReadLine();
            double eredmenyKeres = !string.IsNullOrEmpty(eredmenyBeker) ? double.Parse(eredmenyBeker) : -1;

            Console.WriteLine("Országkód:");
            string orszagkodKeres = Console.ReadLine();

            Console.WriteLine("Helyszín:");
            string helyszinKeres = Console.ReadLine();

            Console.WriteLine("Dátum:");
            string datumKeres = Console.ReadLine();

            bool talaltSportolo = false;

            foreach (var sportolo in sportolok) //ez megkeresi azt a sportolót aki megfelel a megadott feltételekhez
            {
                if ((helyezesKeres == -1 || sportolo.Helyezes == helyezesKeres) &&
                    (eredmenyKeres == -1 || sportolo.Eredmeny == eredmenyKeres) &&
                    (string.IsNullOrEmpty(orszagkodKeres) || sportolo.Orszagkod.Equals(orszagkodKeres, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(helyszinKeres) || sportolo.Helyszin.Equals(helyszinKeres, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(datumKeres) || sportolo.Datum.Equals(datumKeres, StringComparison.OrdinalIgnoreCase)))
                {
                    sportolo.Kiir();
                    talaltSportolo = true;
                    break;
                }
            }

            if (!talaltSportolo) //ez akkor íródik ki amikor nincs megfelelő feltétel
            {
                Console.WriteLine("Nincs a megadott adatoknak megfelelő sportoló az adatbázisban.");
            }

            Console.ReadLine();
        }
    }
}
