namespace P04_SammlungenUndGenerik;

internal class Rechnung<x> where x : Kontakt
{
    public x Kontakt { get; set; }
    public Rechnung(x kontakt)
    {
        Kontakt = kontakt;
    }

    public string KontaktAusgeben()
    {
        return Kontakt.Nachname;
    }
}
