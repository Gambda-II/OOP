namespace P08_Delegaten;

internal static class AusgabenAlogrithmen
{
    public static void NurID(Kunde kunde)
    {
        Console.WriteLine(kunde.ID);
    }

    public static void NurVorname(Kunde kunde)
    {
        Console.WriteLine(kunde.Vorname);
    }

    public static void NurNachname(Kunde kunde)
    {
        Console.WriteLine(kunde.Nachname);
    }

    public static void NurVorUndNachname(Kunde kunde)
    {
        Console.WriteLine($"{kunde.Vorname} {kunde.Nachname}");
    }

    public static void Alles(Kunde kunde)
    {
        Console.WriteLine($"{kunde.ID} {kunde.Vorname} {kunde.Nachname}");
    }
}