using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenerfassung_in_CSV_Datei
{
    class KundenVerwaltung
    {
        public static List<Kunde> kundenBase = new List<Kunde>();
        public List<Kunde> GetKunden()
        {
            return kundenBase;
        }
        public void AddKunden(Kunde kunde)
        {
            kundenBase.Add(kunde);
        }
        public void RemoveKunden(Kunde kunde)
        {
            kundenBase.Remove(kunde);
        }
        public string ToCSVDatei(Kunde kunde)
        {
            string retString = $"{kunde.Vorname},{kunde.Nachname},{kunde.Email},{kunde.Geburtsdatum.Date.ToString("yyyy-MM-dd")},{kunde.Tagesziel_In_Kcal}";
            return retString;
        }
    }
}
