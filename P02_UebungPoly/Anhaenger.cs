using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal class Anhaenger : Fahrzeug, IPauschal, IZeit
    {
        public bool Geschlossen { get; set; }
        public double Volumen { get; set; }
        public double Nutzlast { get; set; }
        public string Besonderheit { get; set; }
        public decimal Pauschale { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }

        public override decimal PreisBerechnung()
        {
            if(Start.HasValue && Ende.HasValue)
            {
                decimal preis = 0;

                preis += Pauschale;

                preis += Convert.ToDecimal(Math.Floor(Ende.Value.Subtract(Start.Value).TotalHours / 3) * 10);

                Start = null;
                Ende = null;

                return preis;
            }
            return -1;
        }
    }
}
