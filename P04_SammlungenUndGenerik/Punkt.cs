using System.Numerics;

namespace P04_SammlungenUndGenerik;

internal class Punkt<T> where T : INumber<T>
{
    public T Punkt1X { get; set; }
    public T Punkt1Y { get; set; }
    public T Punkt2X { get; set; }
    public T Punkt2Y { get; set; }

    public Punkt(T punkt1x, T punkt1y, T punkt2x, T punkt2y)
    {
        Punkt1X = punkt1x;
        Punkt1Y = punkt1y;
        Punkt2X = punkt2x;
        Punkt2Y = punkt2y;
    }

    public double Steigung()
    {
        return (Convert.ToDouble(Punkt2Y - Punkt1Y) / Convert.ToDouble(Punkt2X - Punkt1X));
    }
}
