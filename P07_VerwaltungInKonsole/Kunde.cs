using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P07_VerwaltungInKonsole
{
    internal class Kunde
    {
        private static int lastID = 1;
        public int ID { get;}
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateOnly Geburtsdatum { get; set; }
        public string Telefonnummer { get; set; }

        public Kunde()
        {
            ID = ++lastID;
            
        }

        override public string ToString()
        {
            return $"ID: {ID} Vorname: {Vorname} Nachname: {Nachname}";
        }

        public string Ausgabe()
        {
            return $"{ID}: {Vorname} {Nachname}, {Geburtsdatum}, {Telefonnummer}";
        }
    }
}
