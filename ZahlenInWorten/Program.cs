namespace Zahlen;

public class Program
{
    public static Dictionary<int, string> ZahlenDict = new Dictionary<int, string>();
    public static void Main()
    {
    Console.WriteLine(HunderterString(3));
    }

public void ZahlenWort()
{
    ZahlenDict.Add(0, "Null");
    ZahlenDict.Add(1, "Ein");
    ZahlenDict.Add(2, "Zwei");
    ZahlenDict.Add(3, "Drei");
    ZahlenDict.Add(4, "Vier");
    ZahlenDict.Add(5, "Fünf");
    ZahlenDict.Add(6, "Sechs");
    ZahlenDict.Add(7, "Sieben");
    ZahlenDict.Add(8, "Acht");
    ZahlenDict.Add(9, "Neun");
    ZahlenDict.Add(10, "Zehn");
    ZahlenDict.Add(11, "Elf");
    ZahlenDict.Add(12, "Zwölf");
    ZahlenDict.Add(20, "Zwanzig");
    ZahlenDict.Add(30, "Dreißig");
    ZahlenDict.Add(70, "Siebzig");
}

public void ZahlenInWorten(int number)
{
    int erste = number / 100;
    int zweite = number / 100 % 10;
    int dritte = number % 10;

    string ersteS, zweiteS, dritteS;
}

public static string HunderterString(int ziffer)
{
    string value;
    if (ZahlenDict.ContainsKey(ziffer))
        return ZahlenDict.GetValueOrDefault(ziffer).ToLower() + "hundert";
    return "";
}
}