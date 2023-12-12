using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal class FirmenPKW : PKW
    {
        public int FirmenID { get; set; }

        public override decimal PreisBerechnung()
        {
            decimal preis = 0;

            preis += Pauschale;

            return preis;
        }
    }
}
