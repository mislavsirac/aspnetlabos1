using System;

namespace Vjezba.Model
{
    public class Student : Osoba
    {
        public decimal Prosjek { get; set; }
        public int BrPolozeno { get; set; }
        public int ECTS { get; set; }
        private string jmbag;
        public string JMBAG
        {
            get => jmbag;
            set
            {
                if (value.Length != 10 || !long.TryParse(value, out _))
                {
                    throw new InvalidOperationException("JMBAG mora sadržavati točno 10 znamenki.");
                }
                jmbag = value;

            }
        }


    }
}
