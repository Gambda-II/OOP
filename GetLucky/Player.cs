namespace GetLucky;

public class Player
{
    private string ticketNumber;
    private int[] betNumbers = new int[6];
    private int superNumber;

    public string TicketNumber { get; set; }
    public int[] BetNumbers { get; set; }
    public int SuperNumber { get; set; }

    public Player()
    {
        this.TicketNumber = GenerateTicketNumber();
        this.SuperNumber = RetrieveSuperNumber(TicketNumber);
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
        return string.Join("", ticketNumberString);
    }

    public int RetrieveSuperNumber(string ticketNumberString)
    {
        // ticketNumber will always store digits in each character, therefor no need for TryParse
        return int.Parse(ticketNumberString[ticketNumberString.Length - 1].ToString());
    }
}
