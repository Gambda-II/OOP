using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal abstract class PKW : Fahrzeug, IPauschal
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public double Verbrauch { get; set; }
        public decimal Pauschale { get; set; }
    }
}
