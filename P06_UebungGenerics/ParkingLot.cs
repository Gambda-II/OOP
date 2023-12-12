namespace P06_UebungGenerics;

internal class ParkingLot<T> where T : IDriveable
{
    T[] parked = new T[10];

    public void UpdateParkedAtIndex(T toPark, int atIndex)
    {
        if (atIndex < 0 | atIndex > parked.Length)
            return;

        parked[atIndex] = toPark;
    }

}
