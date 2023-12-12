namespace Verwaltungskonsole;

internal class Kunde
{
    private int iD = 0;
    public int ID { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public DateOnly Geburtsdatum { get; set; }
    public string Telefonnummer { get; set; }

    public override string ToString()
    {
        return $"ID: {ID} Vorname: {Vorname} Nachname: {Nachname}";
    }

    public string Ausgabe()
    {
        return $"{ID}: {Vorname} {Nachname}, {Geburtsdatum}, {Telefonnummer}";
    }
}
