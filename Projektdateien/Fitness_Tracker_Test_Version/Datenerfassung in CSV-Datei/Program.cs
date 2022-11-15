using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Datenerfassung_in_CSV_Datei
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateiname = @"Datenervassung.csv";

            KundenVerwaltung kundenVerwaltung = new KundenVerwaltung();
            kundenVerwaltung.AddKunden(new Kunde("Egor", "Konobeev", "egor.konobeeff@gmail.com", new DateTime(1999, 06, 04), 500));
            kundenVerwaltung.AddKunden(new Kunde("Christiano", "Ronaldo", "c.ronaldo@gmail.com", new DateTime(1985, 02, 05), 1000));
            kundenVerwaltung.AddKunden(new Kunde("Lionel", "Messi", "l.messi@gmail.com", new DateTime(1987, 06, 24), 800));
            kundenVerwaltung.AddKunden(new Kunde("LeBron", "James", "lb.james@gmail.com", new DateTime(1984, 12, 30), 1500));
            kundenVerwaltung.AddKunden(new Kunde("Stephen", "Curry", "s.curry@gmail.com", new DateTime(1988, 03, 14), 900));

            List<string> ausgabe = new List<string>();

            foreach (Kunde kunde in kundenVerwaltung.GetKunden())
            {
                ausgabe.Add(kundenVerwaltung.ToCSVDatei(kunde));
            }

            File.WriteAllLines(dateiname, ausgabe);

            Console.ReadLine();
        }
    }
}
