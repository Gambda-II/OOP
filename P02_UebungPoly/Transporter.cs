using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal class Transporter : Fahrzeug, IEntfernung, IZeit
    {
        public string Hersteller { get; set; }
        public string Modell { get; set; }
        public double Verbrauch { get; set; }
        public string Groesse { get; set; }
        public double KmStand { get; set; }
        public double? KmStandNeu { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }

        public override decimal PreisBerechnung()
        {
            if(KmStandNeu.HasValue && Start.HasValue && Ende.HasValue)
            {
                decimal preis = 0;

                preis += Convert.ToDecimal(Math.Floor(Ende.Value.Subtract(Start.Value).TotalHours) * 10);

                preis += Convert.ToDecimal(Math.Floor((KmStandNeu.Value - KmStand) / 10) * 20);
                
                KmStand = KmStandNeu.Value;
                KmStandNeu = null;
                Start = null;
                Ende = null;

                return preis;
            }
            return -1;
        }
    }
}
