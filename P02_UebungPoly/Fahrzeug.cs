using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal abstract class Fahrzeug
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public string BenoetigterFuehrerschein { get; set; }

        public abstract decimal PreisBerechnung(); // Abstrakte Klasssen können abstrakte Members haben
        // wie bei Interfaces bedeutet das, dass die Kinderklassen diesen Member konkret implementieren müssen


    }
}
