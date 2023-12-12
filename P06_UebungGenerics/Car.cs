using System.Net.WebSockets;

namespace P06_UebungGenerics;

internal class Car : Ride
{

    //public int MinSpeed { get { return MinSpeed; } set { MinSpeed = value > 0 ? value : 0; } }

    public Car(string name, int max) 
    {
        Name = name;
        MaxSpeed = max;
        CurrentSpeed = 0;
    }


}