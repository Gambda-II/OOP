using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_UebungPoly
{
    internal interface IZeit
    {
        DateTime? Start { get; set; }
        DateTime? Ende { get; set; }

    }
}
