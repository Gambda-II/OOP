namespace GetLucky;

public static class Logic
{

    public static int CountMatchingNumbers(Player player, Lotto lotto)
    {
        int matches = 0;

        foreach (int i in player.BetNumbers)
        {
            if (lotto.WinNumbers.Contains(i))
                matches++;
        }

        return matches;
    }

    public static void DisplayGame(Player player, Lotto lotto)
    {
        //DisplayTitleAndNumber("Lotto-Zahlen: ", lotto.WinNumbers);
        SimulateRoll("Lotto-Zahlen: ", lotto.WinNumbers);
        Console.WriteLine();
        DisplayTitleAndNumber("Superzahl: ",lotto.SuperNumber);
        Console.WriteLine();
        Console.WriteLine();
        DisplayTitleAndText("ScheinNr.: ", player.TicketNumber);
        Console.WriteLine();
        DisplayTitleAndNumber("Ihre Zahlen: ", player.BetNumbers);
        Console.WriteLine();
        string superHit = (player.SuperNumber == lotto.SuperNumber) ? " + Superzahl" : "";
        DisplayTitleAndText("Richtige: ", $"{CountMatchingNumbers(player,lotto)} {superHit}");
    }

    public static void DisplayTitleAndNumber(string title, int[] numbers)
    {
        Console.Write(title + "\t");
        foreach (int i in numbers)
            Console.Write(i.ToString(i < 10 ? " 0 " : "00 "));
    }

    public static void DisplayTitleAndText(string title, string text)
    {
        Console.Write(title + "\t " + text);
    }

    public static void SimulateRoll(string title, int[] numbers)
    {
        Console.Write(title + "\t");
        

        foreach (int i in numbers)
        {
            int posX = Console.GetCursorPosition().Left, posY = Console.GetCursorPosition().Top;
            IterateRoll(posX,posY);
            Console.Write(i.ToString(i < 10 ? " 0 " : "00 "));
        }
    }

    public static void DisplayTitleAndNumber(string title, int number)
    {
        int[] numbers = new int[1] { number };
        DisplayTitleAndNumber(title, numbers);
    }
    
    public static void IterateRoll(int posX, int posY)
    {
        int count = 20;
        Console.SetCursorPosition(posX, posY);
        Console.CursorVisible = false;
        while (count > 0)
        {
            Random r = new Random();
            Thread.Sleep(25);
            Console.Write(r.Next(0,50));
            count--;
            Console.SetCursorPosition(posX, posY);
        }
        Console.CursorVisible = true;
    }
}