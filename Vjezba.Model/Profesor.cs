using System;
using System.Collections.Generic;

namespace Vjezba.Model
{
    public class Profesor : Osoba
    {
        public string Odjel { get; set; }
        public Zvanje Zvanje { get; set; }
        public DateTime DatumIzbora { get; set; }
        public List<Predmet> Predmeti { get; set; }

        public Profesor()
        {
            Predmeti = new List<Predmet>();
        }

        public int KolikoDoReizbora()
        {
            int intervalIzbora = Zvanje == Zvanje.Asistent ? 4 : 5;
            var protekloGodina = DateTime.Now.Year - DatumIzbora.Year;

            return intervalIzbora - protekloGodina;
        }
    }
}
