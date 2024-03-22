using System;
using System.Collections.Generic;
using System.Linq;

namespace Vjezba.Model
{
    public class Fakultet
    {
        public List<Osoba> Ljudi { get; set; }

        public Fakultet()
        {
            Ljudi = new List<Osoba>();
        }

        public int KolikoProfesora()
        {
            return Ljudi.Count(osoba => osoba is Profesor);
        }
        public int KolikoStudenata()
        {
            return Ljudi.Count(osoba => osoba is Student);
        }
        public Student DohvatiStudenta(string JMBAG)
        {
            var student = Ljudi.Find(x => x is Student student && student.JMBAG == JMBAG);

            if (student != null)
                return student as Student;

            return null;
        }

        public IEnumerable<Profesor> DohvatiProfesore()
        {
            return Ljudi.OfType<Profesor>()
                .OrderBy(profesor => profesor.DatumIzbora);
        }

        public IEnumerable<Student> DohvatiStudente91()
        {
            return Ljudi.OfType<Student>()
                .Where(x => x.DatumRodjenja.Year > 1991);
        }

        public IEnumerable<Student> DohvatiStudente91NoLinq()
        {
            List<Student> students = new List<Student>();

            foreach (Student student in Ljudi.OfType<Student>())
                if (student.DatumRodjenja.Year > 1991)
                    students.Add(student);

            return students;
        }

        public IEnumerable<Student> StudentiNeTvzD()
        {
            return Ljudi.OfType<Student>()
                .Where(x => !x.JMBAG.StartsWith("0246") && x.Prezime.StartsWith("D"));
        }
        public List<Student> DohvatiStudente91List()
        {
            return Ljudi.OfType<Student>()
                .Where(x => x.DatumRodjenja.Year > 1991)
                .ToList();
        }
        public Student NajboljiProsjek(int god)
        {
            return Ljudi.OfType<Student>()
                .Where(x => x.DatumRodjenja.Year == god)
                .OrderByDescending(x => x.Prosjek)
                .FirstOrDefault();
        }
        public IEnumerable<Student> StudentiGodinaOrdered(int god)
        {
            return Ljudi.OfType<Student>()
                .Where(x => x.DatumRodjenja.Year == god)
                .OrderByDescending(x => x.Prosjek);
        }
        public IEnumerable<Profesor> SviProfesori(bool asc)
        {
            if (asc)
                return Ljudi.OfType<Profesor>()
                    .OrderBy(x => x.Prezime)
                    .ThenBy(x => x.Ime);

            return Ljudi.OfType<Profesor>()
                .OrderByDescending(x => x.Prezime)
                .ThenBy(x => x.Ime);
        }

        public int KolikoProfesoraUZvanju(Zvanje zvanje)
        {
            return Ljudi.OfType<Profesor>()
                .Count(x => x.Zvanje == zvanje);
        }
        public IEnumerable<Profesor> NeaktivniProfesori(int x)
        {
            return Ljudi.OfType<Profesor>()
                .Where(profesor => (profesor.Zvanje == Zvanje.Predavac || profesor.Zvanje == Zvanje.VisiPredavac) && profesor.Predmeti.Count() < x);
        }
        public IEnumerable<Profesor> AktivniAsistenti(int x, int minEcts)
        {
            return Ljudi.OfType<Profesor>()
                .Where(profesor => profesor.Zvanje == Zvanje.Asistent && profesor.Predmeti.Count(predmet => predmet.ECTS >= minEcts) > x);
        }
        public void IzmjeniProfesore(Action<Profesor> action)
        {
            foreach (var profesor in Ljudi.OfType<Profesor>())
            {
                action(profesor);
            }
        }
    }
}
