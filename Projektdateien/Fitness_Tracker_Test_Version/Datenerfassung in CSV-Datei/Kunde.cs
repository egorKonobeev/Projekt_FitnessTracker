using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenerfassung_in_CSV_Datei
{
    class Kunde
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public int Tagesziel_In_Kcal { get; set; }
        public Kunde(string vorname, string nachname, string email, DateTime geburtsdatum, int tagesziel_In_Kcal)
        {
            Vorname = vorname;
            Nachname = nachname;
            Email = email;
            Geburtsdatum = geburtsdatum;
            Tagesziel_In_Kcal = tagesziel_In_Kcal;
        }
    }
}
