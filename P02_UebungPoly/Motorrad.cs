using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal class Motorrad : Fahrzeug, IPauschal, IEntfernung
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public double Verbrauch { get; set; }
        public decimal Pauschale { get; set; }
        public double KmStand { get; set; }
        public double? KmStandNeu { get; set; }

        public override decimal PreisBerechnung()
        {
            if (KmStandNeu.HasValue)
            {
                decimal preis = 0;

                preis += Pauschale;

                double entfernung = Math.Floor((KmStandNeu.Value - KmStand) / 5) - 4;
                if(entfernung > 0)
                {
                    preis += (decimal)(entfernung * Verbrauch/10);
                }

                KmStand = KmStandNeu.Value;
                KmStandNeu = null;

                return preis;
            }
            return -1;
        }
    }
}
