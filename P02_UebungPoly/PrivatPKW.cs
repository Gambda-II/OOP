using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal class PrivatPKW : PKW, IEntfernung, IZeit
    {
        public double KmStand { get; set; }
        public double? KmStandNeu { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }

        public override decimal PreisBerechnung()
        {
            if(KmStandNeu.HasValue && Start.HasValue && Ende.HasValue)
            {
                decimal preis = 0;

                preis += Pauschale;

                double zeit = Math.Floor(Ende.Value.Subtract(Start.Value).TotalHours / 6) - 2;
                if(zeit > 0)
                {
                    preis += Convert.ToDecimal(zeit * 10);
                }

                double entfernung = Math.Floor((KmStandNeu.Value - KmStand) / 5) - 2;
                if(entfernung > 0)
                {
                    preis += Convert.ToDecimal(entfernung * Verbrauch / 15);
                }
                
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
