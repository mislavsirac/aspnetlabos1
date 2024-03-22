using System;

namespace Vjezba.Model
{
    public class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        private string oib;
        public string OIB
        {
            get => oib;
            set
            {
                if (value.Length != 11 || !long.TryParse(value, out _))
                {
                    throw new InvalidOperationException("OIB mora sadržavati točno 11 znamenki.");
                }
                oib = value;
            }
        }

        private string jmbg;
        public string JMBG
        {
            get => jmbg;
            set
            {
                if (value.Length != 13 || !long.TryParse(value, out _))
                {
                    throw new InvalidOperationException("JMBG mora sadržavati točno 13 znamenki.");
                }
                jmbg = value;

            }
        }
        public DateTime DatumRodjenja
        {
            get
            {
                int dan = int.Parse(JMBG.Substring(0, 2));
                int mjesec = int.Parse(JMBG.Substring(2, 2));
                int godina = int.Parse(JMBG.Substring(4, 3));

                godina += godina >= 900 ? 1000 : 2000;

                return new DateTime(godina, mjesec, dan);
            }
        }
    }
}
