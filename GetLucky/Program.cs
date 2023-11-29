namespace GetLucky;

/*
Schreiben Sie ein Lottoprogramm (6 aus 49).
Dieses soll ein Array enthalten, das 6 pseudozufallsgenerierte Gewinnzahlen beinhaltet.
Nun soll der Anwender 6 Zahlen aus 49 auswählen, die mit den Gewinnzahlen verglichen werden müssen
und es ausgegeben wird, wie viele Richtige man hat.

Beispiel-Ausgabe:

Lotto-Zahlen:   1 2 9 10 42 49
Superzahl:      7

Spielschein:    1234567
Ihre Zahlen:    2 5 9 11 42 48
Richtige:       3 + Superzahl

------------------------------
Lotto-Zahlen:   1 2 9 10 42 49
Superzahl:      6

Spielschein:    1234567
Ihre Zahlen:    2 5 9 11 42 48
Richtige:       3

Optional:
Arbeiten Sie zusätzlich mit der Zusatzzahl.
*/

// Schritt 1. Dafuq ist eine Zusatzzahl? -> Jeder Schein hat eine Spielscheinnummer (6 bzw. 7 stellig, Ziffern von 0 bis 9), die letzte Ziffer ist die SUPERZAHL
// Schritt 2. Rest
// Schritt 4. Vielleicht noch mehrere Tipps gleichzeitig, Preis / Gewinn etc..

public class Program
{
    public static void Main()
    {
        Player player = new Player();
        Console.Clear();
        Lotto spiel = new Lotto();
        spiel.DisplayGame(player.BetNumbers,spiel.WinNumbers);
        //Console.WriteLine(spiel.CountMatchingNumbers(player.BetNumbers,spiel.WinNumbers));
    }
}

public class Lotto
{
    private int[] numbers = new int[49];
    private int[] winNumbers = new int[6];
    private string ticketNumber;
    private int superNumber;
    private int jackpot;

    public int[] Numbers { get => numbers; set => numbers = value; }
    public int[] WinNumbers { get => winNumbers; set => winNumbers = value; }
    public int SuperNumber { get => superNumber; set => superNumber = value; }
    public int Jackpot { get => jackpot; set => jackpot = value; }

    public Lotto()
    {
        this.ticketNumber = GenerateTicketNumber();
        this.superNumber = RetrieveSuperNumber(ticketNumber);
        this.numbers = ShuffleDomain(GenerateDomain());
        this.WinNumbers = PickWinNumbers(numbers);
    }

    private int[] GenerateDomain()
    {
        int[] numbers = new int[49];
        for (int i = 1; i < numbers.Length; i++)
        {
            numbers[i - 1] = i;
        }

        return numbers;
    }

    // Fisher-Yates-Shuffle
    // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    private int[] ShuffleDomain(int[] numbersToShuffle)
    {
        Random rnd = new Random();

        for (int i = numbersToShuffle.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(minValue: 0, maxValue: i + 1);
            int tmp = numbersToShuffle[i];
            numbersToShuffle[i] = numbersToShuffle[j];
            numbersToShuffle[j] = tmp;
        }

        return numbersToShuffle;
    }

    private int[] PickWinNumbers(int[] shuffledNumbers)
    {
        int[] winNumbers = new int[6];
        for (int i = 0; i < 6; i++)
        {
            winNumbers[i] = shuffledNumbers[i];
        }

        // hint: winNumbers = Array.Sort(winNumbers) does not work, because Array.Sort "overwrites" the array
        Array.Sort(winNumbers);

        return winNumbers;
    }

    // premise: ticketnumber may start with a 0, has a fixed length of 7
    // string[] then to string = uh? fix this later
    public string GenerateTicketNumber()
    {
        string[] ticketNumberString = new string[7];

        Random rnd = new Random();
        for (int i = 0; i < 7; i++)
        {
            ticketNumberString[i] = (rnd.Next(minValue: 0, maxValue: 10).ToString());
        }
        return string.Join("",ticketNumberString);
    }

    public int RetrieveSuperNumber(string ticketNumberString)
    {
        // ticketNumber will always store digits in each character, therefor no need for TryParse
        return int.Parse(ticketNumberString[ticketNumberString.Length - 1].ToString());
    }

    public int CountMatchingNumbers(int[] playerNumbers, int[] winningNumbers)
    {
        int matches = 0;

        foreach (int i in playerNumbers)
        {
            if (winningNumbers.Contains(i))
                matches++;
        }

        return matches;
    }

    public void DisplayGame(int[] playerNumbers, int[] winningNumbers)
    {
        Console.Write("Lotto-Zahlen: \t");
        foreach (int i in winningNumbers)
        {
            Console.Write(i.ToString(i < 10 ? " 0 " : "00 "));
        }
        Console.WriteLine("\nSuperzahl: \t {0}\n",superNumber);

        Console.WriteLine("ScheinNr.: \t "+ ticketNumber);
        Console.Write("Ihre Zahlen: \t");
        foreach (int i in playerNumbers)
        {
            Console.Write(i.ToString(i < 10 ? " 0 " : "00 "));
        }
    }
}

public class Player
{
    private int[] betNumbers = new int[6];
    public int[] BetNumbers { get; set; }

    public Player()
    {
        this.BetNumbers = GetPlayerNumbers();
    }

    public int[] GetPlayerNumbers()
    {
        int[] numbersUsed = new int[6] { 0, 0, 0, 0, 0, 0 };
        int currentNumber;
        bool mustLoop = true;

        Console.WriteLine("Regeln: Es müssen sechs verschiedene Zahlen zwischen 1 und 49 eingegeben werden.");
        for (int i = 1; i < 7; i++)
        {
            Console.SetCursorPosition(left: 2, top: i * 2 + 1);
            Console.Write("Bitte die {0}. Zahl eingeben: \t", i);
            int x = Console.GetCursorPosition().Left, y = Console.GetCursorPosition().Top;

            while (mustLoop)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("".PadLeft(Console.WindowWidth));
                Console.SetCursorPosition(x, y);
                if (int.TryParse(Console.ReadLine(), out currentNumber) & currentNumber > 0 && currentNumber < 50)
                {
                    mustLoop = false;
                }
                if (i > 1 & numbersUsed.Contains<int>(currentNumber))
                {
                    mustLoop = true;
                    Console.SetCursorPosition(x, y);
                    Console.Write("".PadLeft(Console.WindowWidth));

                }
                numbersUsed[i - 1] = currentNumber;
                Console.SetCursorPosition(x, y);
                Console.Write("{0}".PadLeft(Console.WindowWidth), currentNumber);

            }
            mustLoop = true;
        }

        this.betNumbers = numbersUsed;
        SortPlayerNumbers();
        return betNumbers;
    }

    public void SortPlayerNumbers()
    {
        Array.Sort(this.betNumbers);
    }
}