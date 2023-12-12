using System.ComponentModel.DataAnnotations;

namespace P06_UebungGenerics;

public class Strasse<T> where T : IDriveable
{
    public static void UpdateCurrentSpeed(T ride, int limit)
    {
        int stdDeviation = 5;

        if (ride.CurrentSpeed <= 0)
        {
            ride.CurrentSpeed = new Random().Next(limit - 10, limit + 10);
            return;
        }

        ride.CurrentSpeed = new Random().Next(limit - stdDeviation, limit + stdDeviation);

    }
}