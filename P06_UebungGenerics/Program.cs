namespace P06_UebungGenerics;

internal class Program
{

    public static void Main()
    {


        Car car1 = new Car("Speedy", 150);
        Car car2 = new Car("Gonzales", 200);
        Car car3 = new Car("Flying Nudgeman", 80);
        Car car4 = new Car("Fast Boy", 99);

        List<Ride> rides = new List<Ride>();

        rides.Add(car1);
        rides.Add(car2);
        rides.Add(car3);
        rides.Add(car4);

        DateTime now = DateTime.Now;
        while (true)
        {
            (int x, int y) = Console.GetCursorPosition();

            Console.WriteLine("Currently tracking (local time {0})", now);
            now = DateTime.Now;
            foreach (Ride r in rides)
            {
                Strasse<Ride>.UpdateCurrentSpeed(r, 100);
                Console.WriteLine("{0}:\n\t{1}\n", r.Name, r.CurrentSpeed.ToString("000"));
            }
            Console.SetCursorPosition(x, y);
            Thread.Sleep(1000);
        }


    }
}
