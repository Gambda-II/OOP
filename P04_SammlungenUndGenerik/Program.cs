using System.Numerics;

namespace P04_SammlungenUndGenerik;

internal class Program
{

    public static void Main()
    {

        Kunde kunde = new Kunde()
        { Nachname = "Eins" };
        Rechnung<Kunde> kundenrechnung = new Rechnung<Kunde>(kunde);



        Punkt<int> punkteInt = new Punkt<int>(1, 2, 3, 4);

        Punkt<double> punkteDbl = new Punkt<double>(1, 2, 3, 4);

        Punkt<decimal> punkteDcm = new Punkt<decimal>(1, 2, 3, 4);

        Punkt<BigInteger> punkteBig = new Punkt<BigInteger>(1, 2, 3, 4);

        Console.WriteLine(punkteInt.Steigung());
        Console.WriteLine(punkteDbl.Steigung());
        Console.WriteLine(punkteDcm.Steigung());
        Console.WriteLine(punkteBig.Steigung());
    }
}