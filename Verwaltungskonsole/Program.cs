namespace Verwaltungskonsole;

internal class Program
{
    static List<Kunde> alleKunden = new List<Kunde>();
    static void Main()
    {


        HauptMenue();


    }

    static void HauptMenue()
    {
        Console.WriteLine(
            """
            -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-.
            |                                                                       |
            |                                                                       |
            |                                                                       |
            |                                                                       |
            |                       1. Neuer Kunde                                  |
            !                                                                       !
            :                       2. Alle Kunden ausgeben                         :
            :                                                                       :
            .                       3.                                              .
            .                                                                       .
            :                       4.                                              :
            :                                                                       :
            !                       X.                                              !
            |                                                                       |
            |                                                                       |
            |                                                                       |
            |                                                                       |
            |                                                                       |
            `-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-'
            """);

        UserOption(UserInputKey());
    }

    static ConsoleKeyInfo UserInputKey()
    {
        return Console.ReadKey(true);
    }

    static void UserOption(ConsoleKeyInfo pressed)
    {
        switch (pressed.Key)
        {
            case ConsoleKey.D1:
                CreateNewKunde(alleKunden);
                break;

            case ConsoleKey.D2:
                DisplayAllKunden(alleKunden);
                break;

            case ConsoleKey.D3:

                break;

            case ConsoleKey.D4:

                break;

            case ConsoleKey.X:

                break;

            default:
                Console.WriteLine("Bitte Eingabe wiederholen.");
                UserOption(UserInputKey());
                break;
        }

    }

    static void DisplayAllKunden(List<Kunde> kunden)
    {
        Console.Clear();
        //Console.WriteLine("ID \t Vorname \t Nachname \t Geburtsdatum \t Telefonnummer\n ----------------------------------------------------------");
        foreach(Kunde k in kunden)
        {
            Console.WriteLine(k.Ausgabe());
        }
        Console.ReadKey();
        Console.Clear();
        HauptMenue();
    }

    static void CreateNewKunde(List<Kunde> kunden)
    {
        Kunde kunde = new Kunde() { ID = kunden.Count + 1 };
        (int x, int y) = (0,0);

        Console.Clear();
        Console.WriteLine("ID wurde automatisch generiert: {0}", kunde.ID);
        
        (x,y) = Console.GetCursorPosition();
        Console.Write("Bitte Vorname eingeben: ");
        kunde.Vorname= TryGetString();
        Console.SetCursorPosition(x, y);
        Console.WriteLine("".PadLeft(Console.WindowWidth));
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Vorname:\t " + kunde.Vorname);

        (x,y) = Console.GetCursorPosition();
        Console.Write("Bitte Nachname eingeben: ");
        kunde.Nachname = TryGetString();
        Console.SetCursorPosition(x, y);
        Console.WriteLine("".PadLeft(Console.WindowWidth));
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Nachname:\t" + kunde.Nachname);

        (x, y) = Console.GetCursorPosition();
        Console.Write("Bitte Geburtsdatum eingeben: ");
        kunde.Geburtsdatum = TryGetDate();
        Console.SetCursorPosition(x, y);
        Console.WriteLine("".PadLeft(Console.WindowWidth));
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Geburtsdatum:\t" + kunde.Geburtsdatum);

        (x, y) = Console.GetCursorPosition();
        Console.Write("Bitte Telefonnummer eingeben: ");
        kunde.Telefonnummer = TryGetString();
        Console.SetCursorPosition(x, y);
        Console.WriteLine("".PadLeft(Console.WindowWidth));
        Console.SetCursorPosition(x, y);
        Console.WriteLine("Telefonnummer:\t" + kunde.Telefonnummer);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Eingabe erfogreich. Bitte eine beliebige Taste drücken um zurückzukehren.");
        Console.ReadKey();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        kunden.Add(kunde);
        HauptMenue();
    }

    private static DateOnly TryGetDate()
    {
        bool hasWorked = false;
        DateOnly date = new DateOnly();

        while (!hasWorked)
        {
            hasWorked = DateOnly.TryParse(Console.ReadLine(), out date);
        }

        return date;
    }

    static string TryGetString()
    {
        string tmp = "";

        while (string.IsNullOrEmpty(tmp))
        {
            tmp = Console.ReadLine();
        }
        return tmp;
    }

    static void GenerateKunden(List<Kunde> kunden)
    {
        kunden.Add(new Kunde()
        {
            ID = 1,
            Vorname = "Max",
            Nachname = "Mustermann",
            Geburtsdatum = new DateOnly(1990, 30, 6),
            Telefonnummer = "555-123 069 420"
        });
        kunden.Add(new Kunde()
        {
            ID = 2,
            Vorname = "Min",
            Nachname = "Musterinfrau",
            Geburtsdatum = new DateOnly(1999, 6, 3),
            Telefonnummer = "555-177 166 155"
        });
        kunden.Add(new Kunde()
        {
            ID = 3,
            Vorname = "Nuck",
            Nachname = "Chorris",
            Geburtsdatum = new DateOnly(1943, 7, 12),
            Telefonnummer = "555-999 999 999"
        });
    }
}