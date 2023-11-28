namespace Wassermelonen_Rechnung;

// Note: Any given price will be rounded and the rounded value will be used

public class Program
{
    public static void Main()
    {
        Rechnung rechnung = new Rechnung();
        UserInput.DisplayMessage("Enter drücken, um eine Rechnung darzustellen.");
        Console.ReadLine();
        UserInput.GenerateInvoice(rechnung);
        Console.ReadLine();
    }
}

public class Rechnung
{
    private const float discountAtFive = 0.05f, discountAtTen = 0.10f, discountAtFiveOnTuesDay = 0.07f, discountAtTenOnTuesday = 0.12f;

    private int id;

    private float price;
    private float total;
    private int amount;
    private DateTime date;
    private float discount = 1.00f;
    private float tax;

    public int ID
    {
        get { return id; }
    }
    public float Price
    {
        get {return price; }
        set { price = MathF.Round(value, 2); }
    }
    public float Total
    {
        get { return total; }
        set { total = MathF.Round(value, 2); }
    }
    public int Amount
    {
        get { return  amount; }
        set { amount = value; }
    }
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    public float Discount
    {
        get { return discount; }
        set { discount = MathF.Round(value,2);}
    }

    public float Tax
    {
        get { return tax; }
        set { tax = MathF.Round(value - value / 1.07f, 2); }
    }

    public Rechnung()
    {
        id++;
        this.Date = DateTime.Now;

        UserInput.DisplayMessage("Eine neue Rechnung wird erstellt.\n");

        UserInput.DisplayMessage("Bitte geben Sie einen Preis, ohne Eurozeichen, ein.");
        this.Price = UserInput.GetUserInputPrice();
        UserInput.DisplayMessage($"Gewählter Preis {Price.ToString("0.00")} EUR.\n");
        UserInput.DisplayMessage("Bitte geben Sie die Menge ein.");
        this.Amount = UserInput.GetUserInputInteger();
        this.Discount = GetDiscount(this.Amount, this.Date);
        string discountString = (Discount < 1) ? $" (Rabatt: {MathF.Round((1 - Discount) * 100,2).ToString("0.0")} %)." : ".";
        UserInput.DisplayMessage($"Gewählte Menge {Amount}.\n");
        this.Total = GetTotalPrice(this.Price, this.Amount);
        this.Tax = Total;
        UserInput.DisplayMessage($"Der Gesamtpreis ergibt {this.Total.ToString("0.00")} EUR{discountString}\n");
        UserInput.DisplayMessage("Rechnung erfolgreich gespeichert.");
    }


    public float GetTotalPrice(float price, int amount)
    {
        return price * amount * GetDiscount(amount, this.date);
    }

    public float GetDiscount(int amount, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Tuesday)
        {
            if(amount >= 10)
            {
                return 1 - discountAtTenOnTuesday;
            }
            if(amount >= 5)
            {
                return 1 - discountAtFiveOnTuesDay;
            }
        }

        if (amount >= 10)
        {
            return 1 - discountAtTenOnTuesday;
        }
        if (amount >= 5)
        {
            return 1 - discountAtFiveOnTuesDay;
        }

        return 1;
    }

}

public static class UserInput
{
    public static void DisplayMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public static int GetUserInputInteger()
    {
        int number;
        bool tryingToParse;
        do
        {
            string input = Console.ReadLine();

            tryingToParse = int.TryParse(input, out number);

            if (!tryingToParse || number < 1)
            {
                DisplayMessage("Die Menge muss mindestens 1 sein. Bitte die Eingabe wiederholen.");
                tryingToParse = false;
            }
        }
        while (!tryingToParse);
        return number;
    }

    public static float GetUserInputPrice()
    {
        float number;
        bool tryingToParse;
        do
        {
            string input = Console.ReadLine();

            // Couldn't work out to check and THEN remove EURO symbols

            // O M G, To explain: in GER a comma is used instead of a decimal point, so you must specify that you want to use an invariant culture.
            // float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture,out number) 
            tryingToParse = float.TryParse(input, out number);

            if (!tryingToParse)
            {
                DisplayMessage("Bitte einen Preis eingeben und kein Eurozeichen verwenden.");
            }
            if (number <= 0)
            {
                DisplayMessage("Der Preis muss positiv sein. Bitte die Eingabe wiederholen.");
                tryingToParse = false;
            }
        }
        while (!tryingToParse);
        return number;
    }

    public static void AskForAnotherEntry()
    {
        DisplayMessage("Möchten Sie eine weitere Rechnung angeben?");
    }

    //
    public static void DisplayOption()
    {
        // Do Something
    }


    public static void GenerateInvoice(Rechnung invoice)
    {
        string
            billingNo = "RechnungsNr.",
            price = "Preis ".PadRight(invoice.Price.ToString().Length+5),
            amount = "Bestellmenge ",
            total = "Gesamtpreis ",
            tax = "MwSt (7%) ";

        DisplayMessage($"Datum: {invoice.Date.ToShortDateString()}");
        DisplayMessage($"Uhrzeit: {invoice.Date.ToLongTimeString()} Uhr\n\n");

        DisplayMessage($"" +
            $"{billingNo}\t " +
            $"{price}\t " +
            $"{amount}\t " +
            $"{total}\t\t " +
            $"{tax}");

        DisplayMessage($"" +
            $"{invoice.ID.ToString().PadLeft(billingNo.Length)}\t" +
            $"{invoice.Price.ToString("0.00")} EUR\t" +
            $"{invoice.Amount.ToString().PadLeft(amount.Length)}\t " +
            $"{invoice.Total.ToString("0.00").PadLeft(total.Length)} EUR\t " +
            $"{invoice.Tax.ToString("0.00")} EUR");
    }
}


public static class Wassermelone
{
    private static float price;
    public static float Price
    {
        get
        {
            return MathF.Round(price, 2);
        }
        set
        {
            if (value > 0)
            {
                Price = MathF.Round(value, 2);
                return;
            }
            ReturnErrorMessageNegativePrice();

        }
    }

    private static void ReturnErrorMessageNegativePrice()
    {
        DisplayMessage("Der Preis einer Melone darf nicht negativ sein.\nBitte geben Sie einen positiven Wert ein.");
    }

    private static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}